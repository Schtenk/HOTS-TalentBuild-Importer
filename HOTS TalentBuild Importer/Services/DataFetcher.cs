using HOTS_TalentBuild_Importer.Extensions;
using HOTS_TalentBuild_Importer.Models;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ScrapySharp.Extensions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static HOTS_TalentBuild_Importer.Extensions.DbSetExtension;
using static SchtenksFramework.Services.Settings<HOTS_TalentBuild_Importer.HOTSTalentBuildSettings>;

namespace HOTS_TalentBuild_Importer.Services
{
    public static class DataFetcher
    {
        static HtmlNode GeneralDataHtml;
        private static void GetGeneralData()
        {
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load("https://www.heroesprofile.com/Global/Talents/?hero=Abathur");
            GeneralDataHtml = doc.DocumentNode;
        }
        public static void FetchVersions()
        {
            if (GeneralDataHtml == null) GetGeneralData();

            using var db = new HOTSTalentBuildContext();
            var html = GeneralDataHtml;
            var timeframeSelect = html.CssSelect("#major_timeframe");
            var options = timeframeSelect.CssSelect("option");
            foreach (var option in options)
            {
                var version = new Versions.MajorVersion { MajorVersionID = option.GetAttributeValue("value") };
                db.MajorVersions.UpdateIfOrAdd(version, e => e.MajorVersionID == version.MajorVersionID); // e => e.MajorVersionID == version.MajorVersionID && e.ExistsOnHotsProfile == false
            }
            db.SaveChanges();
            timeframeSelect = html.CssSelect("#minor_timeframe");
            options = timeframeSelect.CssSelect("option");
            foreach (var option in options)
            {
                var value = option.GetAttributeValue("value");
                var majorVersion = string.Join(".", value.Split('.').Take(2));
                var version = new Versions.MinorVersion
                {
                    VersionID = value,
                    MajorVersionID = majorVersion
                };
                if (!db.MajorVersions.Any(v => v.MajorVersionID == majorVersion && v.ExistsOnHotsProfile))
                {
                    db.MajorVersions.AddIfMissing(new Versions.MajorVersion { MajorVersionID = majorVersion, ExistsOnHotsProfile = false });
                }

                db.MinorVersions.AddIfMissing(version);

            }
            db.GeneralDatas.AddOrUpdate(new GeneralData { Name = Versions.ModelName, LastUpdated = DateTime.Now }, e => e.Name == Versions.ModelName);
            db.SaveChanges();
        }
        public static void FetchHeroes()
        {
            if (!string.IsNullOrEmpty(SettingsInstance.HOTSPATH))
            {
                var path = $"{Application.StartupPath}\\HeroesDataParser\\";
                var outputPath = $"{path}output\\";
                try
                {
                    using var process = new Process();
                    var startInfo = new ProcessStartInfo($"{path}heroesdata.exe")
                    {
                        Arguments = $"\"{SettingsInstance.HOTSPATH}\" -e heroesdata --json -o \"{outputPath}",
                        UseShellExecute = true
                    };
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    if (process.ExitCode != 0) { throw new Exception("Something Failed While Extracting Heroes Data"); }

                }
                catch (Exception e)
                {
                    MessageBox.Show($"HeroesDataParser: {e} - {e.Message}");
                    return;
                }

                var heroes = new Dictionary<string, string>();
                try
                {
                    var filePath = Directory.GetFiles($"{outputPath}\\json\\")[0];

                    var jsonString = File.ReadAllText(filePath);
                    var document = JsonDocument.Parse(jsonString);
                    foreach (var c in document.RootElement.EnumerateObject())
                    {
                        var heroId = c.Name;
                        var heroName = c.Value.EnumerateObject().SingleOrDefault(e => e.Name == "name").Value.ToString(); ;
                        heroes.Add(heroName, heroId);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"JSON Data: {e} - {e.Message}");
                    return;
                }
                if (GeneralDataHtml == null) GetGeneralData();
                using var db = new HOTSTalentBuildContext();
                var html = GeneralDataHtml;
                var heroesSelect = html.CssSelect("#hero");
                foreach (var option in heroesSelect.CssSelect("option"))
                {
                    var hotsProfileName = option.GetAttributeValue("value");
                    var name = WebUtility.UrlDecode(hotsProfileName);
                    db.Heroes.AddIfMissing(new Hero()
                    {
                        HeroID = heroes[name],
                        Name = name,
                        HotsProfileName = hotsProfileName
                    });
                }
                db.GeneralDatas.AddOrUpdate(new GeneralData { Name = Hero.ModelName, LastUpdated = DateTime.Now }, e => e.Name == Hero.ModelName);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("No Heroes of the Storm path set, you can ignore this option :)");
            }
        }

        public class FetchTalentBuildsArgs
        {
            public List<string> Heroes;
            public List<string> Ranks;
            public string Version;
        }
        public static void FetchTalentBuilds(object sender, DoWorkEventArgs we)
        {
            var BgWorker = (BackgroundWorker)sender;
            var args = (FetchTalentBuildsArgs)we.Argument;
            var heroes = args.Heroes;
            var ranks = args.Ranks;
            var version = args.Version;
            try
            {
                var heroesToUpdate = new List<Hero>();
                var versionString = "";
                var ranksString = "";
                using (var db = new HOTSTalentBuildContext())
                {
                    ranksString = string.Join(",", ranks);
                    if (version == "Minor")
                    {
                        versionString = string.Join(",", db.MinorVersions.OrderByDescending(v => v.VersionID).Take(2).Select(v => v.VersionID).ToArray());
                    }
                    else
                    {
                        versionString = string.Join(",", (from mv in db.MajorVersions.OrderByDescending(v => v.MajorVersionID).Take(1)
                                                          join v in db.MinorVersions on mv.MajorVersionID equals v.MajorVersionID
                                                          select v.VersionID).ToArray());
                    }

                    heroesToUpdate = (from h in db.Heroes
                                      where heroes.Contains(h.Name)
                                        && (h.TalentBuilds.Count == 0 ||
                                            h.TalentBuilds
                                                .Any(t => (t.Ranks == ranksString && t.Version == version && t.LastUpdated <= DateTime.Now.AddDays(-7))))
                                      select h).ToList();

                }


                if (heroesToUpdate.Count > 0)
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    using var service = ChromeDriverService.CreateDefaultService();
                    service.HideCommandPromptWindow = true;

                    using var driver = new ChromeDriver(service, options);
                    using var db = new HOTSTalentBuildContext();
                    double total = heroesToUpdate.Count;
                    double count = 1;
                    foreach (var hero in heroesToUpdate)
                    {
                        if (BgWorker.CancellationPending)
                            return;
                        BgWorker.ReportProgress((int)Math.Round((count / total) * 100.0), $"{Constants.FetchingTalenBuildStatus} - {hero.Name} ({count}/{total})");

                        var arguments = $"{hero.HotsProfileName}&timeframe_type=minor&timeframe={versionString}&type=win_rate&game_type=sl&league_tier={ranksString.ToLower()}";
                        var url = "https://www.heroesprofile.com/Global/Talents/?hero=" + arguments;
                        driver.Navigate().GoToUrl(url);
                        WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                        driverWait.Until(ExpectedConditions.ElementExists(By.CssSelector("table#popularbuilds")));
                        var popularBuilds = driver.FindElementByCssSelector("table#popularbuilds");
                        var buildCodes = popularBuilds.FindElements(By.ClassName("build-code"));
                        var totalGamesCells = popularBuilds.FindElements(By.ClassName("games_played_cell"));
                        var winsCells = popularBuilds.FindElements(By.ClassName("wins_cell"));
                        var builds = new List<string>();
                        var totalGames = new List<int>();
                        var wins = new List<int>();

                        foreach (var buildCode in buildCodes)
                        {
                            var buildText = buildCode.GetAttribute("textContent");
                            var buildValue = Regex.Match(buildText, "([\\d]+)").Value;
                            var build = string.Join("", buildValue.AsEnumerable().Select(c => c.ToString()).ToList().Select(s => s.Replace(s, Constants.TalentIdLookup[s])));
                            builds.Add(build);
                        }
                        foreach (var totalGamesCell in totalGamesCells)
                        {
                            totalGames.Add(int.Parse(totalGamesCell.GetAttribute("textContent")));
                        }
                        foreach (var winsCell in winsCells)
                        {
                            wins.Add(int.Parse(winsCell.GetAttribute("textContent")));
                        }
                        for (int i = 0; i < buildCodes.Count; ++i)
                        {
                            var talentBuild = new TalentBuild
                            {
                                HeroID = hero.HeroID,
                                Ranks = ranksString,
                                Version = version,
                                BuildNumber = i,
                                Build = builds[i],
                                TotalGames = totalGames[i],
                                Wins = wins[i],
                                LastUpdated = DateTime.Now
                            };
                            db.TalentBuilds
                                .AddOrUpdate(talentBuild
                                    , t => t.HeroID == talentBuild.HeroID
                                    && t.Ranks == talentBuild.Ranks
                                    && t.Version == talentBuild.Version
                                    && t.BuildNumber == talentBuild.BuildNumber);
                        }
                        db.SaveChanges();
                        ++count;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Fetch TalentBuilds: {e} - {e.Message}");
            }
        }
    }
}
