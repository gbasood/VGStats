using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VGStats.Models
{
    public class Match
	{
		public int Id { get; set; }
		/// <summary>
		/// An int-based value representing the format the data was given to us in.
		/// An int value is used here, as of now, because the format we are given rarely changes, so it is easier to use this simple format than over-engineer a revision format.
		/// </summary>
		public int DataRevision { get; set; }
		[Required]
		public string StationName { get; set; }
		[Required]
		public string MapName { get; set; }
		[Range(int.MinValue, int.MaxValue)]
		public int CrewScore { get; set; }
		[Range(0, int.MaxValue)]
		public int SurvivingHeads { get; set; }
		[Range(0, int.MaxValue)]
		public int SurvivingBorgs { get; set; }
		public bool Nuked { get; set; }
		[Range(0, int.MaxValue)]
		public int CratesOrdered { get; set; }
		[Range(0, int.MaxValue)]
		public int BloodSpilled { get; set; }
		[Range(0, 10000)]
		public int ArtifactsDiscovered { get; set; }
		[Range(0, 1000)]
		public int TechTotal { get; set; }

		[Required]
		public DateTime StartTime { get; set; }
		[Required]
		public DateTime EndTime { get; set; }

		public TimeSpan RoundSpan => EndTime - StartTime;

		public List<Explosion> Explosions { get; set; }
		public List<Death> Deaths { get; set; }
		public List<UplinkBuy> UplinkBuys { get; set; }
		public List<BadassBundleBuy> BadassBundles { get; set; }
		public List<PopulationSnapshot> PopulationSnapshots { get; set; }
		public List<Survivor> Survivors { get; set; }
		public List<MalfModule> MalfModules { get; set; }
		public List<Role> Roles { get; set; }

		public IEnumerable<Death> GetPlayerDeaths()
		{
			return Deaths
				.Where(d => d.MatchId == this.Id && 
							d.MindKey != null && 
							d.MindName != "Manifested Ghost");
		}

		public IEnumerable<Death> GetNpcDeaths()
		{
			return Deaths
				.Where(d => d.MatchId == this.Id &&
							d.MindKey == null);
		}

		public List<dynamic> GetUniqueAntagsByKey()
		{
			var antags = new List<dynamic>();
			//foreach (var obj in Objectives)
			//{
			//	antags.Add(new
			//	{
			//		key = obj.MindKey,
			//		name = obj.MindName,
			//		role = obj.Role
			//	});
			//}
			return antags;
		}
	}
}
