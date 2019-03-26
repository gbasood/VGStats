using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VGStats.Models
{
	public class ModelDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DbSet<Match> Matches { get; set; }
		public DbSet<Explosion> Explosions { get; set; }
		public DbSet<Death> Deaths { get; set; }
		public DbSet<UplinkBuy> UplinkBuys { get; set; }
		public DbSet<BadassBundleBuy> BadassBundles { get; set; }
		public DbSet<PopulationSnapshot> PopulationSnapshots { get; set; }
		public DbSet<Survivor> Survivors { get; set; }
		public DbSet<MalfModule> MalfModules { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Faction> Factions { get; set; }
		public DbSet<RoleObjective> Objectives { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Role>().HasKey(r => new {r.MatchRoleId, r.MatchId});
			modelBuilder.Entity<RoleObjective>().HasKey(ro => new {ro.Id, ro.MatchId, ro.RoleId});
		}
	}

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

		public IQueryable<Death> GetPlayerDeaths()
		{
			return new ModelDbContext().Deaths
				.Where(d => d.MatchId == this.Id && 
						    d.MindKey != null && 
							d.MindName != "Manifested Ghost");
		}

		public IQueryable<Death> GetNpcDeaths()
		{
			return new ModelDbContext().Deaths
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

	public class Explosion
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public int EpicenterX { get; set; }
		public int EpicenterY { get; set; }
		public int EpicenterZ { get; set; }
		public int LightImpactRange { get; set; }
		public int HeavyImpactRange { get; set; }
		public int DevestationRange { get; set; }
	}

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

		public int DeathX { get; set; }
		public int DeathY { get; set; }
		public int DeathZ { get; set; }

		public int DamageBrute { get; set; }
		public int DamageFire { get; set; }
		public int DamageToxin { get; set; }
		public int DamageOxygen { get; set; }
		public int DamageClone { get; set; }
		public int DamageBrain { get; set; }
	}

	public class UplinkBuy
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string MindName { get; set; }
		public string MindKey { get; set; }
		/// <summary>
		/// Was the buyer of the uplink item a traitor?
		/// </summary>
		public string BuyerRole { get; set; }
		// Either one or the other will be set, not both.
		// TODO maybe make this not stupid huh?
		public string BundlePath { get; set; }
		public string ItemPath { get; set; }
		/// <summary>
		/// Uplink cost can vary depending on the purchaser's job.
		/// </summary>
		public int ItemCost { get; set; }
	}

	public class BadassBundleBuy
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string MindName { get; set; }
		public string MindKey { get; set; }
		/// <summary>
		/// Was the buyer of the uplink item a traitor?
		/// </summary>
		public string BuyerRoleType { get; set; }

		public List<BadassBundleItem> Items { get; set; }
	}

	public class BadassBundleItem
	{
		public int Id { get; set; }
		[Required]
		public int BadassBundleId { get; set; }
		public BadassBundleBuy BadassBundle { get; set; }
		public string ItemPath { get; set; }
	}

	public class PopulationSnapshot
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public int PopCount { get; set; }
		public DateTime Time { get; set; }
	}

	public class Survivor
	{
		public int Id { get; set; }
		[Required]
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string MindName { get; set; }
		public string MindKey { get; set; }
		public string MobTypepath { get; set; }
		public int DamageBrute { get; set; }
		public int DamageFire { get; set; }
		public int DamageToxin { get; set; }
		public int DamageOxygen { get; set; }
		public int DamageClone { get; set; }
		public int DamageBrain { get; set; }
	}

	public class MalfModule
	{
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string ModuleBuyerKey { get; set; }
		public string ModuleName { get; set; }
	}

	public class RoleObjective
	{
		public int Id { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }
		public int MatchId { get; set; }
		public Match Match { get; set; }

		/// <summary>
		/// Typepath of the objective.
		/// </summary>
		[Required]
		public string ObjectiveType { get; set; }
		[Required]
		public string ObjectiveDescription { get; set; }
		[Required]
		public bool ObjectiveSuccessful { get; set; }
	}


	/// <summary>
	/// A RoleObjective that targets a specific player or item(s).
	/// </summary>
	public class RoleObjectiveTargeted : RoleObjective
	{
		[Required]
		public string TargetName { get; set; }
	}

	/// <summary>
	/// A theft-based RoleObjective. Child of RoleObjectiveTargeted.
	/// </summary>
	public class TheftObjective : RoleObjectiveTargeted
	{
		[Required]
		public int RequiredAmount { get; set; }
		[Required]
		public int FoundAmount { get; set; }
	}

	/// <summary>
	/// Antag role. Has composite primary key. Does not necessarily belong to a faction.
	/// </summary>
	public class Role
	{
		/// <summary>
		/// The ID assigned to this role instance for the game round.
		/// </summary>
		public int MatchRoleId { get; set; }
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public int? FactionId { get; set; }
		public Faction Faction { get; set; }

		public string RoleName { get; set; }
		public string MindName { get; set; }
		public string MindKey { get; set; }
	}

	/// <summary>
	/// Factions are groups of antag roles which usually share a common goal.
	/// </summary>
	public class Faction
	{
		public int Id { get; set; }
		public int MatchId { get; set; }
		public Match Match { get; set; }

		public List<Role> Roles { get; set; }
		// TODO fill out

		[Required]
		public int RoundFactionId { get; set; }
		[Required]
		public string FactionName { get; set; }
		[Required]
		public string FactionType { get; set; }
	}
}
