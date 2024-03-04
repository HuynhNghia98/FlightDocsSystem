using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			foreach (var e in modelBuilder.Model.GetEntityTypes())
			{
				var tableName = e.GetTableName();
				if (tableName.StartsWith("AspNet"))
				{
					e.SetTableName(tableName.Substring(6));
				}
			}

		}

	}
}
