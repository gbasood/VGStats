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
		public List<MapPlayRate> MapPlayRates { get; set; }

		public Match LastMatch { get; set; }

        public IndexViewModel(ModelDbContext db)
        {
            MatchCount = db.Matches.Count();
            NukeCount = db.Matches.Where(m => m.Nuked).Count();
            // don't divide by 0 or get unwanted nulls
            if (MatchCount > 0)
            {
                ExplosionRate = db.Explosions.Count() / (float)MatchCount;
                DeathRatio = db.Deaths.Where(d => d.MindKey != null && d.MindName != "Manifested Ghost").Count() / (float)MatchCount;
                MapPlayRates = db.Matches.GroupBy(m => m.MapName).Select(m => new MapPlayRate { Name = m.Key, PlayRate = m.Count() / (decimal)MatchCount }).ToList();
                LastMatch = db.Matches.OrderByDescending(m => m.Id).Take(1)?.First();
            }
            else
            {
                ExplosionRate = 0f;
                DeathRatio = 0f;
                MapPlayRates = db.Matches.GroupBy(m => m.MapName).Select(m => new MapPlayRate { Name = m.Key, PlayRate = 0 }).ToList();
            }
        }

        public class MapPlayRate
        {
            public string Name { get; set; }
            public decimal PlayRate { get; set; }
        }
    }
}
