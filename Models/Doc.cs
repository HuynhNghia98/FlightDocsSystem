using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Models
{
	public class Doc
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public double Version { get; set; }
		public string? File { get; set; } = string.Empty;
		public string? Note { get; set; } = string.Empty;
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime UpdateDate { get; set; } = DateTime.Now;

		[Required]
		public int FlightId { get; set; }
		[ForeignKey("FlightId")]
		public Flight Flight { get; set; }
		[Required]
		public int TypeId { get; set; }
		[ForeignKey("TypeId")]
		public DocType Type { get; set; }

		public ICollection<RoleClaimsDoc>? RoleClaimsDocs { get; set; }
	}
}
