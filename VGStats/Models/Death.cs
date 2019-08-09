using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    public class Death
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string MindKey { get; set; }
		public string MindName { get; set; }
		public string TypePath { get; set; }
		/// <summary>
		/// Antag role assigned according to game data.
		/// </summary>
		public string SpecialRole { get; set; }
		/// <summary>
		/// Job role assigned according to game data.
		/// </summary>
		public string AssignedRole { get; set; }

		public bool From_Suicide { get; set; }
		
		public Location DeathLocation { get; set; }
		public MobDamage Damage { get; set; }
	}
}
