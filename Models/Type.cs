﻿using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
	public class Type
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Note { get; set; } = string.Empty;

		public ICollection<Docs>? Docs { get; set; }
		public ICollection<RoleClaimsType>? RoleClaimsTypes { get; set; }
	}
}