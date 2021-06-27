using HOTS_TalentBuild_Lib.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace HOTS_TalentBuild_Lib
{
    public class HOTSTalentBuildContext : DbContext
    {
        public static string ConnectionString;
        public HOTSTalentBuildContext ()
        {
        }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<TalentBuild> TalentBuilds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString
                , ServerVersion.AutoDetect(ConnectionString));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TalentBuild>().HasKey(t => new { t.HeroID, t.GameType, t.Rank, t.Build });
            base.OnModelCreating(modelBuilder);
        }

    }
}
