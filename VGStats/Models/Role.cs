using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    /// <summary>
    /// Antag role. Has composite primary key. Does not necessarily belong to a faction.
    /// </summary>
    public class Role
	{
		/// <summary>
		/// The ID assigned to this role instance for the game round.
		/// </summary>
		public int MatchRoleId { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		[Required]
		public string FactionId { get; set; }
		public Faction Faction { get; set; }

		public string RoleName { get; set; }
		public string MindName { get; set; }
		public string MindKey { get; set; }
		// New to this version of the statistics viewer; wins are defined by the game, not us
		public bool Won { get; set; }
	}
}
