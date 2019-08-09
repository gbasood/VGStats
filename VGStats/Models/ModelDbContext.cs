using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public DbSet<RoleObjective> Objectives { get; set; }
        public DbSet<Faction> Factions { get; set; }

        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {
            // if we don't manually pass options to the base constructor it won't be passed at all
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(r => new { r.MatchRoleId, r.MatchId });
            modelBuilder.Entity<RoleObjective>().HasKey(ro => new { ro.Id, ro.MatchId, ro.RoleId });
            modelBuilder.Entity<Faction>().HasKey(f => new { f.Id, f.MatchId });
        }
    }
}
