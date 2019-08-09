using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class Explosion
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }

		public Location Epicenter { get; set; }
		public int LightImpactRange { get; set; }
		public int HeavyImpactRange { get; set; }
		public int DevestationRange { get; set; }
	}
}
