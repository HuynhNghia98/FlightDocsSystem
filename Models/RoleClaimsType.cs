﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Models
{
	public class RoleClaimsType
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public bool IsModify { get; set; } = false;
		[Required]
		public bool IsRead { get; set; } = false;

		[Required]
		public string AppRoleId { get; set; }
		[ForeignKey("AppRoleId")]
		public AppRole AppRole { get; set; }
		[Required]
		public int TypeId { get; set; }
		[ForeignKey("TypeId")]
		public Type Type { get; set; }
	}
}