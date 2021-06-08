using HOTS_TalentBuild_Lib.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using static HOTS_TalentBuild_Lib.Models.Versions;

namespace HOTS_TalentBuild_Lib
{
    public class HOTSTalentBuildContext : DbContext
    {
        public static string ConnectionString;
        public HOTSTalentBuildContext ()
        {
        }
        
        public DbSet<MajorVersion> MajorVersions { get; set; }
        public DbSet<MinorVersion> MinorVersions { get; set; }
        public DbSet<GeneralData> GeneralDatas { get; set; }
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
            modelBuilder.Entity<TalentBuild>().HasKey(t => new { t.HeroID, t.Ranks, t.Version, t.BuildNumber });
            base.OnModelCreating(modelBuilder);
        }

    }
}
