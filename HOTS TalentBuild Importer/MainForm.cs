using HOTS_TalentBuild_Importer.Models;
using HOTS_TalentBuild_Importer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SchtenksFramework.Services.Settings<HOTS_TalentBuild_Importer.HOTSTalentBuildSettings>;

namespace HOTS_TalentBuild_Importer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void ImportBtn_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void Import()
        {
            EnableButtons(false);
            var heroes = HeroesBox.CheckedItems.Cast<string>().ToList();
            var ranks = RanksBox.CheckedItems.Cast<string>().ToList();
            var version = VersionTypeBox.Text;
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
            StatusLbl.Text = Constants.FetchingTalenBuildStatus;
            TalentBuildBgWorker.RunWorkerAsync(new DataFetcher.FetchTalentBuildsArgs
            {
                Heroes = heroes,
                Ranks = ranks,
                Version = version
            });
        }

        private void TalentBuildBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataFetcher.FetchTalentBuilds(sender, e);
        }
        private void TalentBuildBgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            ProgressBar.Update();
            StatusLbl.Text = e.UserState.ToString();
        }

        private void TalentBuildBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Value = 0;
            EnableButtons(false);
            var heroes = HeroesBox.CheckedItems.Cast<string>().ToList();
            StatusLbl.Text = "Generating TalentBuilds.txt";
            using (var db = new HOTSTalentBuildContext())
            {
                var talentBuilds = db.Heroes.Where(h => heroes.Contains(h.Name)).Select(h => h.TalentBuilds).ToList();
                var talentBuildsString = string.Join(Environment.NewLine, talentBuilds.Select(t =>
                {
                    var list = t.OrderByDescending(b => b.Wins).ThenByDescending(b => b.TotalGames).Take(SettingsInstance.SelectedNumberOfBuilds).ToList();
                    var heroID = list[0].HeroID;
                    return $"{heroID}=Build1|{list[0].Build}" +
                    $"|{(list.ElementAtOrDefault(1) == null ? "\"\"" : list[1].Build)}" +
                    $"|{(list.ElementAtOrDefault(2) == null ? "\"\"" : list[2].Build)}" +
                    $"|{Constants.HeroStringLookup[heroID]}";
                }));

                foreach (var account in Directory.GetDirectories(Constants.HOTSDocumentPath))
                {
                    using var stream = new StreamWriter($"{account}\\TalentBuilds.txt", false);
                    stream.Write(talentBuildsString); 
                }
            }
            StatusLbl.Text = Constants.DefaultStatus;
            EnableButtons(true);
        }
        private void EnableButtons(bool enable)
        {
            ImportBtn.Enabled = enable;
            CancelBtn.Enabled = !enable;
            if (!string.IsNullOrEmpty(SettingsInstance.HOTSPATH))
            {
                HeroUpdateBtn.Enabled = enable;
            }
        }

        private void RanksBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chkListBox = (CheckedListBox)sender;
            AllRanksChkBox.CheckedChanged -= AllRanksChkBox_CheckedChanged;
            AllRanksChkBox.Checked = (chkListBox.CheckedItems.Count == chkListBox.Items.Count);
            AllRanksChkBox.CheckedChanged += AllRanksChkBox_CheckedChanged;
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



        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SettingsInstance.HOTSPATH))
            {
                HeroUpdateBtn.Enabled = true;
                HeroUpdateBtn.Visible = true;
            }

            var lastUpdated = DateTime.MinValue;
            using (var db = new HOTSTalentBuildContext())
            {
                db.Database.EnsureCreated();
                lastUpdated = db.GeneralDatas.Where(g => g.Name == Versions.ModelName).Select(d => d.LastUpdated).FirstOrDefault();
            }
            if (lastUpdated.AddDays(7) < DateTime.Now) DataFetcher.FetchVersions();

            using (var db = new HOTSTalentBuildContext())
            {
                var versions = db.MinorVersions.Select(v => v.VersionID).OrderByDescending(v => v).ToArray();
                var heroes = db.Heroes.Select(h => h.Name).OrderBy(h => h).ToArray();
                HeroesBox.Items.AddRange(heroes);
            }
            LoadSettings();
        }

        private void HeroUpdateBtn_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            StatusLbl.Text = "Extracting Hero Data (See Command Prompt For Progress)";
            DataFetcher.FetchHeroes();
            StatusLbl.Text = Constants.DefaultStatus;
            using (var db = new HOTSTalentBuildContext())
            {
                HeroesBox.Items.Clear();
                var heroes = db.Heroes.Select(h => h.Name).OrderBy(h => h).ToArray();
                HeroesBox.Items.AddRange(heroes);
            }
            AllHeroesChkBox.Checked = true;
            EnableButtons(true);
        }

        private void AllHeroesChkBox_CheckedChanged(object sender, EventArgs e)
        {
            var chkBox = (CheckBox)sender;
            SelectAllHeroes(chkBox.Checked);
            SettingsInstance.SelectedHeroes = (HeroesBox.CheckedItems.Count == HeroesBox.Items.Count) ? new string[] { "ALL" } : HeroesBox.CheckedItems.Cast<string>().ToArray();
        }

        private void HeroesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chkListBox = (CheckedListBox)sender;
            AllHeroesChkBox.CheckedChanged -= AllHeroesChkBox_CheckedChanged;
            AllHeroesChkBox.Checked = (chkListBox.CheckedItems.Count == chkListBox.Items.Count);
            AllHeroesChkBox.CheckedChanged += AllHeroesChkBox_CheckedChanged;
            SettingsInstance.SelectedHeroes = (HeroesBox.CheckedItems.Count == HeroesBox.Items.Count) ? new string[] { "ALL" } : HeroesBox.CheckedItems.Cast<string>().ToArray();
        }

        private void BackupBtn_Click(object sender, EventArgs e)
        {
            BackupTalentBuilds();
        }
        private void BackupTalentBuilds()
        {
            StatusLbl.Text = "Backing Up TalentBuild.txt";
            foreach (var account in Directory.GetDirectories(Constants.HOTSDocumentPath))
            {
                if (File.Exists($"{account}\\TalentBuilds.txt"))
                {
                    File.Copy($"{account}\\TalentBuilds.txt", $"{account}\\TalentBuilds.backup-{DateTime.Now:yyyyMMddHHmmss}.txt");
                }
            }
            StatusLbl.Text = Constants.DefaultStatus;
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
            VersionTypeBox.Text = SettingsInstance.SelectedVersion;
            for (var i = 0; i < RanksBox.Items.Count; ++i)
            {
                if (SettingsInstance.SelectedRanks.Contains(RanksBox.Items[i].ToString()))
                {
                    RanksBox.SetItemChecked(i, true);
                }
            }
            NrBuildsBox.Text = SettingsInstance.SelectedNumberOfBuilds.ToString();
        }

        private void VersionTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsInstance.SelectedVersion = VersionTypeBox.Text;
        }

        private void NrBuildsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsInstance.SelectedNumberOfBuilds = int.Parse(NrBuildsBox.Text);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            StatusLbl.Text += " - Cancelling...";
            TalentBuildBgWorker.CancelAsync();
        }
    }
}
