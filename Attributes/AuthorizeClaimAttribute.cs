using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using FlightDocsSystem.DataAccess.Data;
using System.Security.Claims;

namespace FlightDocsSystem.Attributes
{
	[AttributeUsage(AttributeTargets.Method)]
	public class AuthorizeClaimAttribute : Attribute, IAuthorizationFilter
	{
		private readonly List<string> _claimValueList;
		private readonly ApplicationDbContext _dbContext;

		public AuthorizeClaimAttribute(List<string> claimValueList, ApplicationDbContext dbContext)
		{
			_claimValueList = claimValueList;
			_dbContext = dbContext;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var user = context.HttpContext.User;

			if (!user.Identity.IsAuthenticated)
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			// lấy roleclaim từ token
			var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

			if (string.IsNullOrEmpty(roleClaim))
			{
				context.Result = new ForbidResult();
				return;
			}

			// Lấy docId từ RouteData
			var docIdString = context.HttpContext.Request.RouteValues["id"]?.ToString();

			if (docIdString == null || !int.TryParse(docIdString, out int docId))
			{
				context.Result = new ForbidResult();
				return;
			}

			// lấy docs từ db
			var doc = _dbContext.Docs.FirstOrDefault(d => d.Id == docId);

			if (doc == null)
			{
				context.Result = new ForbidResult();
				return;
			}
			//--------------------------RoleClaimsTypes------------------------------------

			bool IsAccess = false;

			foreach (var claimValue in _claimValueList)
			{
				// truy vấn trong cơ sở dữ liệu để kiểm tra quyền
				var hasRoleClaimsTypesAccess = _dbContext.RoleClaimsTypes
					.Any(rct => rct.Value == claimValue && rct.Id == doc.Id && rct.AppRole.Name == roleClaim);

				//--------------------------RoleClaimsDocs------------------------------------

				// truy vấn trong cơ sở dữ liệu để kiểm tra quyền
				var hasRoleClaimsDocsAccess = _dbContext.RoleClaimsDocs
					.Any(rct => rct.Value == claimValue && rct.Id == docId && rct.AppRole.Name == roleClaim);

				if (!hasRoleClaimsTypesAccess || !hasRoleClaimsDocsAccess)
				{
					IsAccess = true;
				}
			}


			if (!IsAccess)
			{
				context.Result = new ForbidResult();
				return;
			}
		}

	}
}
