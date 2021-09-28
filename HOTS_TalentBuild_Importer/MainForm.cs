using HOTS_TalentBuild_Lib.Models;
using HOTS_TalentBuild_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SchtenksFramework.Services.Settings<HOTS_TalentBuild_Importer.HOTSTalentBuildSettings>;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Squirrel;

namespace HOTS_TalentBuild_Importer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            HOTSTalentBuildContext.ConnectionString = SettingsInstance.ConnectionString;
        }

        class Build
        {
            public string HeroID;
            public string Selected = "Build1";
            public string Build1 = "\"\"";
            public string Build2 = "\"\"";
            public string Build3 = "\"\"";
        }

        readonly Dictionary<string, List<Build>>  CurrentBuilds = new Dictionary<string, List<Build>>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates(null, null);
            Text = $"HOTS TalentBuild Importer {ProductVersion}";
            using (var db = new HOTSTalentBuildContext())
            {
                HeroesBox.Items.AddRange(db.Heroes.Select(h => h.Name).ToArray());
            }

            RanksBox.Items.AddRange(LibConstants.Ranks.ToArray());

            var Buildselectors = TalentBuildFetcher.BuildSelectors.Keys.ToArray();
            Build1Box.Items.AddRange(Buildselectors);
            Build2Box.Items.AddRange(Buildselectors);
            Build3Box.Items.AddRange(Buildselectors);

            foreach (var account in Directory.GetDirectories(LibConstants.HOTSDocumentPath))
            {
                if (File.Exists($"{account}\\TalentBuilds.txt"))
                {
                    var lines  = File.ReadAllLines($"{account}\\TalentBuilds.txt");
                    CurrentBuilds.Add(account, new List<Build>());
                    foreach (var line in lines)
                    {
                        var match = Regex.Match(line, "(\\w+)=(\\w+)\\|(\\d+)\\|(\\d+)\\|(\\d+)\\|");
                        CurrentBuilds[account].Add(new Build()
                        {
                            HeroID = match.Groups[1].Value,
                            Selected = match.Groups[2].Value,
                            Build1 = match.Groups[3].Value,
                            Build2 = match.Groups[4].Value,
                            Build3 = match.Groups[5].Value,
                        });
                    }
                }
            }

            LoadSettings();
            Build1Box.SelectedIndexChanged += BuildBox_SelectedIndexChanged;
            Build2Box.SelectedIndexChanged += BuildBox_SelectedIndexChanged;
            Build3Box.SelectedIndexChanged += BuildBox_SelectedIndexChanged;
        }

        async void CheckForUpdates(object sender, EventArgs e)
        {
            StatusLabel.Text = "Checking for updates...";
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    using (var updateManager = await UpdateManager.GitHubUpdateManager("https://github.com/Schtenk/HOTS-TalentBuild-Importer", Application.ProductName))
                    {
                        var result = await updateManager.UpdateApp((int i) =>
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                StatusLabel.Text = "Updating...";
                                ProgressBar.Value = i;
                            }));
                        });
                        if (result != null)
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                StatusLabel.Text = "Update done, please restart program!";
                                StatusLabel.ForeColor = System.Drawing.Color.Green;
                                ProgressBar.Value = 100;
                            }));
                        }
                        else
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                StatusLabel.Text = "Program is up to date.";
                                ProgressBar.Value = 0;
                            }));
                        }
                    }
                }
                catch (Exception e)
                {
                }
            });
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void Import()
        {
            var heroes = HeroesBox.CheckedItems.Cast<string>().ToList();
            var ranks = RanksBox.CheckedItems.Cast<string>().ToList();
            if (heroes.Count < 1)
            {
                MessageBox.Show("No Heroes Selected!");
                return;
            }
            if (ranks.Count < 1)
            {
                MessageBox.Show("No Ranks Selected!");
                return;
            }

            FetcherWorker.DoWork += FetcherWorker_DoWork;
            FetcherWorker.RunWorkerCompleted += FetcherWorker_RunWorkerCompleted;
            FetcherWorker.ProgressChanged += FetcherWorker_ProgressChanged;

            FetcherWorker.RunWorkerAsync( Tuple.Create(Build1Box.Text, Build2Box.Text, Build3Box.Text, heroes, ranks));
            
        }

        private void FetcherWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var argument = (Tuple<string, string ,string,List<string>, List<string>>)e.Argument;
            var heroes = argument.Item4;
            var ranks = argument.Item5;
            worker.ReportProgress(0, "Importing Build 1:");
            var builds1 = TalentBuildFetcher.FetchTalentBuilds(worker, argument.Item1, heroes, ranks);
            worker.ReportProgress(0, "Importing Build 2:");
            var builds2 = TalentBuildFetcher.FetchTalentBuilds(worker, argument.Item2, heroes, ranks);
            worker.ReportProgress(0, "Importing Build 3:");
            var builds3 = TalentBuildFetcher.FetchTalentBuilds(worker, argument.Item3, heroes, ranks);
            e.Result = Tuple.Create(builds1, builds2, builds3);
            worker.ReportProgress(100, "Import done!");
        }

        private void FetcherWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (Tuple<List<TalentBuild>, List<TalentBuild>, List<TalentBuild>>)e.Result;
            var builds1 = result.Item1;
            var builds2 = result.Item2;
            var builds3 = result.Item3;
            using var db = new HOTSTalentBuildContext();
            var HeroeIds = db.Heroes.Select(h => h.HeroID).ToList();
            foreach (var account in Directory.GetDirectories(LibConstants.HOTSDocumentPath))
            {
                string talentBuildsString = string.Join(Environment.NewLine, HeroeIds.Select(h =>
                {
                    var currentBuild = CurrentBuilds[account].Where(c => c.HeroID == h).Select(c => c).FirstOrDefault() ?? new Build
                    {
                        HeroID = h
                    };
                    var build1 = builds1 != null && builds1.Any(b => b.HeroID == h) ? builds1.Where(b => b.HeroID == h).FirstOrDefault().Build : currentBuild.Build1;
                    var build2 = builds2 != null && builds2.Any(b => b.HeroID == h) ? builds2.Where(b => b.HeroID == h).FirstOrDefault().Build : currentBuild.Build2;
                    var build3 = builds3 != null && builds3.Any(b => b.HeroID == h) ? builds3.Where(b => b.HeroID == h).FirstOrDefault().Build : currentBuild.Build3;

                    return $"{h}={currentBuild.Selected ?? "Build1"}" +
                    $"|{build1}" +
                    $"|{build2}" +
                    $"|{build3}" +
                    $"|{LibConstants.HeroStringLookup[h]}";
                }));
                using var stream = new StreamWriter($"{account}\\TalentBuilds.txt", false);
                stream.Write(talentBuildsString);
            }
        }
        private void FetcherWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null) StatusLabel.Text = e.UserState as string;
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void RanksBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chkListBox = (CheckedListBox)sender;
            CheckIfAllChecked(AllRanksChkBox, AllRanksChkBox_CheckedChanged, chkListBox);
            SettingsInstance.SelectedRanks = RanksBox.CheckedItems.Cast<string>().ToArray();
        }

        private void AllRanksChkBox_CheckedChanged(object sender, EventArgs e)
        {
            var chkBox = (CheckBox)sender;
            RanksBox.SelectedIndexChanged -= RanksBox_SelectedIndexChanged;
            for (int i = 0; i < RanksBox.Items.Count; ++i)
            {
                RanksBox.SetItemChecked(i, chkBox.Checked);
            }
            RanksBox.SelectedIndexChanged += RanksBox_SelectedIndexChanged;
            SettingsInstance.SelectedRanks = RanksBox.CheckedItems.Cast<string>().ToArray();
        }

        private void AllHeroesChkBox_CheckedChanged(object sender, EventArgs e)
        {
            var chkBox = (CheckBox)sender;
            SelectAllHeroes(chkBox.Checked);
            SettingsInstance.SelectedHeroes = (HeroesBox.CheckedItems.Count == HeroesBox.Items.Count) ? new string[] { "ALL" } : HeroesBox.CheckedItems.Cast<string>().ToArray();
        }

        private void CheckIfAllChecked(CheckBox checkBox, EventHandler checkedChanged, CheckedListBox listBox)
        {
            checkBox.CheckedChanged -= checkedChanged;
            checkBox.Checked = (listBox.CheckedItems.Count == listBox.Items.Count);
            checkBox.CheckedChanged += checkedChanged;
        }

        private void HeroesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chkListBox = (CheckedListBox)sender;
            CheckIfAllChecked(AllHeroesChkBox, AllHeroesChkBox_CheckedChanged, chkListBox);
            SettingsInstance.SelectedHeroes = (HeroesBox.CheckedItems.Count == HeroesBox.Items.Count) ? new string[] { "ALL" } : HeroesBox.CheckedItems.Cast<string>().ToArray();
        }

        private void BackupBtn_Click(object sender, EventArgs e)
        {
            BackupTalentBuilds();
        }
        private void BackupTalentBuilds()
        { 
            foreach (var account in Directory.GetDirectories(LibConstants.HOTSDocumentPath))
            {
                if (File.Exists($"{account}\\TalentBuilds.txt"))
                {
                    File.Copy($"{account}\\TalentBuilds.txt", $"{account}\\TalentBuilds.backup-{DateTime.Now:yyyyMMddHHmmss}.txt");
                }
            }
        }

        private void SelectAllHeroes(bool check)
        {
            HeroesBox.SelectedIndexChanged -= HeroesBox_SelectedIndexChanged;
            for (int i = 0; i < HeroesBox.Items.Count; ++i)
            {
                HeroesBox.SetItemChecked(i, check);
            }
            HeroesBox.SelectedIndexChanged += HeroesBox_SelectedIndexChanged;
        }

        private void LoadSettings()
        {
            if (SettingsInstance.SelectedHeroes[0] == "ALL")
            {
                SelectAllHeroes(true);
            }
            else
            {
                var heroes = SettingsInstance.SelectedHeroes;
                for (var i = 0; i < HeroesBox.Items.Count; ++i)
                {
                    if (heroes.Contains(HeroesBox.Items[i].ToString()))
                    {
                        HeroesBox.SetItemChecked(i, true);
                    }
                }
            }
            for (var i = 0; i < RanksBox.Items.Count; ++i)
            {
                if (SettingsInstance.SelectedRanks.Contains(RanksBox.Items[i].ToString()))
                {
                    RanksBox.SetItemChecked(i, true);
                }
            }
            Build1Box.Text = SettingsInstance.Builds[0];
            Build2Box.Text = SettingsInstance.Builds[1];
            Build3Box.Text = SettingsInstance.Builds[2];
            CheckIfAllChecked(AllHeroesChkBox, AllHeroesChkBox_CheckedChanged, HeroesBox);
            CheckIfAllChecked(AllRanksChkBox, AllRanksChkBox_CheckedChanged, RanksBox);
        }

        private void BuildBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsInstance.Builds = new string[] { Build1Box.Text, Build2Box.Text, Build3Box.Text};
        }
    }
}
