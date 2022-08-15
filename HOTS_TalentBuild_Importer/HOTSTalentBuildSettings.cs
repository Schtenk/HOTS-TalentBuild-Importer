using HOTS_TalentBuild_Lib;
using SchtenksFramework.Services;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace HOTS_TalentBuild_Importer
{
    public class HOTSTalentBuildSettings: Settings<HOTSTalentBuildSettings>
    {
        private string[] _selectedHeroes;
        public string[] SelectedHeroes { get => _selectedHeroes; set => SetProperty(ref _selectedHeroes,value); }

        private string[] _selectedRanks;
        public string[] SelectedRanks { get => _selectedRanks; set => SetProperty(ref _selectedRanks, value); }

        private string[] _builds;
        public string[] Builds { get => _builds; set => SetProperty(ref _builds, value); }

        public override void SetDefaults()
        {
            SelectedHeroes = new string[] { "ALL" };
            SelectedRanks = new string[] { "Master", "Diamond", "Platinum" };
            Builds = new string[]
            {
                Constants.Unchanged
                , Constants.Unchanged
                , Constants.Unchanged
            };
        }
    }
}
