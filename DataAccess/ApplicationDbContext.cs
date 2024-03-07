﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
		public DbSet<AppRole> AppRoles { get; set; }
		public DbSet<Docs> Docs { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<RoleClaimsDocs> RoleClaimsDocs { get; set; }
		public DbSet<RoleClaimsType> RoleClaimsTypes { get; set; }
		public DbSet<Models.Type> Types { get; set; }


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
