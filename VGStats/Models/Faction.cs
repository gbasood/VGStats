using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VGStats.Models
{
    /// <summary>
    /// Factions are groups of antag roles which usually share a common goal.
    /// 
    /// This entity has a conjugate primary key, consisting of their string ID and their Match ID.
    /// </summary>
    public class Faction
	{
		public string Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }

		public List<Role> Roles { get; set; }
		[Required]
		public string FactionName { get; set; }
		[Required]
		public string FactionType { get; set; }
		// New to this version of the statistics viewer; wins are defined by the game, not us
		public bool Won { get; set; }
	}
}
