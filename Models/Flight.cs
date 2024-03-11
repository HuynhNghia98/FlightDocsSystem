using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
	public class Flight
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string FlightNo { get; set; } = string.Empty;
		[Required]
		public string Route { get; set; } = string.Empty;
		[Required]
		public DateTime Date { get; set; }
		[Required]
		public string PointOfLoading { get; set; } = string.Empty;
		[Required]
		public string PointOfUnLoading { get; set; } = string.Empty;

		public ICollection<Doc>? Docs { get; set; }
	}
}
