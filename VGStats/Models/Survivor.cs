using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class Survivor
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		[Required]
		public string MindName { get; set; }
		[Required]
		public string MindKey { get; set; }
		[Required]
		public string MobTypepath { get; set; }
		[Required]
		public MobDamage Damage { get; set; }
		[Required]
		public Location Location { get; set; }
	}
}
