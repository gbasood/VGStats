using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGStats.Models
{
	public class IndexViewModel
	{
		/// <summary>
		/// Total logged matches
		/// </summary>
		public int MatchCount { get; set; }
		/// <summary>
		/// Total number of nuke detonations
		/// </summary>
		public int NukeCount { get; set; }
		/// <summary>
		/// Explosions per match
		/// </summary>
		public float ExplosionRate { get; set; }
		/// <summary>
		/// Deaths per match
		/// </summary>
		public float DeathRatio { get; set; }

		/// <summary>
		/// Play rates for maps, where string is the map name and float is the percentage-based play rate.
		/// </summary>
		public Tuple<string, float>[] MapPlayRates { get; set; }

		public Match LastMatch { get; set; }
	}
}
