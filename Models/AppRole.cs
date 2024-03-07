﻿using Microsoft.AspNetCore.Identity;

namespace FlightDocsSystem.Models
{
	public class AppRole : IdentityRole
	{
		public ICollection<RoleClaimsType>? RoleClaimsTypes { get; set; }
		public ICollection<RoleClaimsDocs>? RoleClaimsDocs { get; set; }
	}
}