using HOTS_TalentBuild_Lib;
using HOTS_TalentBuild_Lib.Models;
using System;
using System.Collections.Generic;
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
                where = (tb => tb.GameType == "ARAM"),
                orderBy = (tb => tb.Wins)
            } },
            {"ARAM - Highest Win Percentage", new TalentBuildSelector{
                where = tb => tb.GameType == "ARAM",
                orderBy = tb => tb.Wins/tb.TotalGames
            } },
            {"ARAM - Popularity", new TalentBuildSelector{
                where = tb => tb.GameType == "ARAM",
                orderBy = tb => tb.TotalGames
            } },
            {"Normal - Most Wins", new TalentBuildSelector{
                where = tb => tb.GameType == "ARAM",
                orderBy = tb => tb.Wins
            } },
            {"Normal - Highest Win Percentage", new TalentBuildSelector{
                where = tb =>  tb.GameType == "ARAM",
                orderBy = tb => tb.Wins/tb.TotalGames
            } },
            {"Normal - Popularity", new TalentBuildSelector{
                where =  tb => tb.GameType == "ARAM",
                orderBy = tb => tb.TotalGames
            } },
            {Constants.Unchanged, null }
        };

        public static List<TalentBuild> FetchTalentBuilds(string buildSelector, List<string> Heroes, List<string> Ranks)
        {
            using var db = new HOTSTalentBuildContext();
            var selector = BuildSelectors[buildSelector];
            if (selector == null) return null;
            var TalentBuilds = db.Heroes
                .Where(h => Heroes.Contains(h.Name))
                .Select(h => h.TalentBuilds
                    .Where(t => Ranks.Contains(t.Rank))
                    .AsEnumerable()
                    .AsQueryable()
                    .Where(selector.where)
                    .Select(t => t)
                        .OrderByDescending(selector.orderBy).First()).AsEnumerable().Where(b => b != null).ToList();
            

            return TalentBuilds;
        }

        public class TalentBuildSelector
        {
            
            public Expression<Func<TalentBuild, bool>> where;
            public Expression<Func<TalentBuild, double>> orderBy;
        }
    }
}
