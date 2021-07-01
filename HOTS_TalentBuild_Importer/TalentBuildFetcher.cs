using HOTS_TalentBuild_Lib;
using HOTS_TalentBuild_Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HOTS_TalentBuild_Importer
{
    public class TalentBuildFetcher
    {
        public static Dictionary<string, TalentBuildSelector> BuildSelectors = new Dictionary<string, TalentBuildSelector>
        {
            {"ARAM - Most Wins", new TalentBuildSelector{
                WhereFunc = (TalentBuild tb) => { return tb.GameType == "ARAM"; },
                OrderByFunc = (TalentBuild tb ) => {return tb.Wins; }
            } },
            
            {"ARAM - Highest Winrate", new TalentBuildSelector{
                WhereFunc = (TalentBuild tb) => { return tb.GameType == "ARAM"; },
                OrderByFunc = (TalentBuild tb) => {return tb.Wins/tb.TotalGames; }
            } },
            {"ARAM - Popularity", new TalentBuildSelector{
                WhereFunc = (TalentBuild tb) => { return tb.GameType == "ARAM"; },
                OrderByFunc = (TalentBuild tb) => { return tb.TotalGames; }
            } },
            {"Normal - Most Wins", new TalentBuildSelector{
                WhereFunc = (TalentBuild tb) => { return tb.GameType == "Normal"; },
                OrderByFunc = (TalentBuild tb ) => {return tb.Wins; }
            } },
            {"Normal - Highest Winrate", new TalentBuildSelector{
                WhereFunc = (TalentBuild tb) => { return tb.GameType == "Normal"; },
                OrderByFunc = (TalentBuild tb) => {return tb.Wins/tb.TotalGames; }
            } },
            {"Normal - Popularity", new TalentBuildSelector{
                WhereFunc = (TalentBuild tb) => { return tb.GameType == "Normal"; },
                OrderByFunc = (TalentBuild tb) => { return tb.TotalGames; }
            } },
            {Constants.Unchanged, null }
        };

        public static List<TalentBuild> FetchTalentBuilds(BackgroundWorker worker, string buildSelector, List<string> Heroes, List<string> Ranks)
        {
            using var db = new HOTSTalentBuildContext();
            var selector = BuildSelectors[buildSelector];
            if (selector == null) return null;
            var heroes = (from hero in db.Heroes
                          where Heroes.Contains(hero.Name)
                          select hero).ToList();
            List<TalentBuild> talentBuilds = new List<TalentBuild>();
            int count = 0;
            heroes.ForEach((h) =>
            {
                worker.ReportProgress((count*100/heroes.Count), null);
                var builds = (from tb in db.TalentBuilds.AsEnumerable()
                             where tb.HeroID == h.HeroID
                                 && Ranks.Contains(tb.Rank)
                                 && selector.WhereFunc(tb)
                             select tb).ToList();
                if(builds.Count > 0)
                {

                    var talentBuild = (from tb in builds
                                    group tb by tb.Build into grp
                                    select new TalentBuild()
                                    {
                                        HeroID = h.HeroID,
                                        Build = grp.Key,
                                        Wins = grp.Sum(t => t.Wins),
                                        TotalGames = grp.Sum(t => t.TotalGames)
                                    }).OrderByDescending(selector.OrderByFunc).First();
                    talentBuilds.Add(talentBuild);
                }
                count++;
            });
            return talentBuilds;
        }

        public class TalentBuildSelector
        {
            
            public Func<TalentBuild, bool> WhereFunc;
            public Func<TalentBuild, double> OrderByFunc;
        }
    }
}
