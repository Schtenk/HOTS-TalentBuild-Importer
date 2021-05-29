using HOTS_TalentBuild_Importer.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using static HOTS_TalentBuild_Importer.Models.Versions;

namespace HOTS_TalentBuild_Importer
{
    public class HOTSTalentBuildContext : DbContext
    {
        public DbSet<MajorVersion> MajorVersions { get; set; }
        public DbSet<MinorVersion> MinorVersions { get; set; }
        public DbSet<GeneralData> GeneralDatas { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<TalentBuild> TalentBuilds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=steinwalls.synology.me;user id=root;persistsecurityinfo=True;port=3307;database=HOTSTalentBuildData;password=FktP^7Ls^pa!J4^!2TYJ;"
                , ServerVersion.AutoDetect("server=steinwalls.synology.me;user id=root;persistsecurityinfo=True;port=3307;database=HOTSTalentBuildData;password=FktP^7Ls^pa!J4^!2TYJ;"));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TalentBuild>().HasKey(t => new { t.HeroID, t.Ranks, t.Version, t.BuildNumber });
            base.OnModelCreating(modelBuilder);
        }

    }
}
