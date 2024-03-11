using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
	public class RoleClaimsDoc
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string AppRoleId { get; set; }
		[ForeignKey("AppRoleId")]
		public AppRole AppRole { get; set; }
		[Required]
		public int DocsId { get; set; }
		[ForeignKey("DocsId")]
		public Doc Docs { get; set; }
	}
}
