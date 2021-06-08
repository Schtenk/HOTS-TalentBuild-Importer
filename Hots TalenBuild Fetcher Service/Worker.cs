using HOTS_TalentBuild_Lib;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static SchtenksFramework.Services.Settings<HOTS_TalenBuild_Fetcher_Service.HOTSTalentbuildFetcherSettings>;

namespace HOTS_TalenBuild_Fetcher_Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            HOTSTalentBuildContext.ConnectionString = SettingsInstance.ConnectionString;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            using (var process = new Process() {
                StartInfo = new ProcessStartInfo() {
                    CreateNoWindow = true,
                    FileName = "dotnet.exe",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = "tool update --global HeroesDataParser"
                }})
            {
                _logger.LogInformation("Starting HeroesDataParser update at: {time}", DateTimeOffset.Now);
                var started = await Task.Run(process.Start);
                if (!started) { _logger.LogWarning("Could not run HeroesDataParser update process ({time})", DateTimeOffset.Now); }
                else
                {
                    process.WaitForExit();
                    var error = process.StandardError.ReadToEnd();
                    if (string.IsNullOrEmpty(error))
                    {
                        var result = process.StandardOutput.ReadToEnd();
                        _logger.LogInformation(result);
                    }
                    else { _logger.LogError(error); }
                }
            }

            using ( var process = new Process(){
                StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    FileName = "dotnet.exe",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = "tool update --global HeroesDataParser"
                }})
            {
                _logger.LogInformation("Starting heroes parsing with HeroesDataParser at: {time}", DateTimeOffset.Now);
                //if (!string.IsNullOrEmpty(SettingsInstance.HOTSPATH))
                //{
                //    var path = $"{Application.StartupPath}\\HeroesDataParser\\";
                //    var outputPath = $"{path}output\\";
                //    try
                //    {
                //        using var process = new Process();
                //        var startInfo = new ProcessStartInfo($"{path}heroesdata.exe")
                //        {
                //            Arguments = $"\"{SettingsInstance.HOTSPATH}\" -e heroesdata --json -o \"{outputPath}",
                //            UseShellExecute = true
                //        };
                //        process.StartInfo = startInfo;
                //        process.Start();
                //        process.WaitForExit();
                //        if (process.ExitCode != 0) { throw new Exception("Something Failed While Extracting Heroes Data"); }

                //    }
                //    catch (Exception e)
                //    {
                //        MessageBox.Show($"HeroesDataParser: {e} - {e.Message}");
                //        return;
                //    }

                //    var heroes = new Dictionary<string, string>();
                //    try
                //    {
                //        var filePath = Directory.GetFiles($"{outputPath}\\json\\")[0];

                //        var jsonString = File.ReadAllText(filePath);
                //        var document = JsonDocument.Parse(jsonString);
                //        foreach (var c in document.RootElement.EnumerateObject())
                //        {
                //            var heroId = c.Name;
                //            var heroName = c.Value.EnumerateObject().SingleOrDefault(e => e.Name == "name").Value.ToString(); ;
                //            heroes.Add(heroName, heroId);
                //        }
                //    }
                //    catch (Exception e)
                //    {
                //        MessageBox.Show($"JSON Data: {e} - {e.Message}");
                //        return;
                //    }
                //    if (GeneralDataHtml == null) GetGeneralData();
                //    using var db = new HOTSTalentBuildContext();
                //    var html = GeneralDataHtml;
                //    var heroesSelect = html.CssSelect("#hero");
                //    foreach (var option in heroesSelect.CssSelect("option"))
                //    {
                //        var hotsProfileName = option.GetAttributeValue("value");
                //        var name = WebUtility.UrlDecode(hotsProfileName);
                //        db.Heroes.AddIfMissing(new Hero()
                //        {
                //            HeroID = heroes[name],
                //            Name = name,
                //            HotsProfileName = hotsProfileName
                //        });
                //    }
                //    db.GeneralDatas.AddOrUpdate(new GeneralData { Name = Hero.ModelName, LastUpdated = DateTime.Now }, e => e.Name == Hero.ModelName);
                //    db.SaveChanges();
                //}
                //else
                //{
                //    MessageBox.Show("No Heroes of the Storm path set, you can ignore this option :)");
                //}
            }


            _logger.LogInformation("Worker finished at: {time}", DateTimeOffset.Now);
        }
    }
}
