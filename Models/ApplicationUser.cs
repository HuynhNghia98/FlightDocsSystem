﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FullName { get; set; } = string.Empty;
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string PhoneNumber { get; set; } = string.Empty;
		public bool? IsAdmin { get; set; } = false;
		public bool? IsPilot { get; set; } = false;
		public bool? IsCrew { get; set; } = false;

		[NotMapped]
		public string Role { get; set; } = string.Empty;
	}
}
