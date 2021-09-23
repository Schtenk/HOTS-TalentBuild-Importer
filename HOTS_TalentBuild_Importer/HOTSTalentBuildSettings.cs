﻿using HOTS_TalentBuild_Lib;
using SchtenksFramework.Services;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace HOTS_TalentBuild_Importer
{
    public class HOTSTalentBuildSettings: Settings<HOTSTalentBuildSettings>
    {
        public string ConnectionString { get; set; }
        public string[] SelectedHeroes { get; set; }
        public string[] SelectedRanks { get; set; }
        public string[] Builds {get; set; }


        public override void SetDefaults()
        {
            ConnectionString = "server=schtenks.synology.me;user id=ImporterUser;persistsecurityinfo=True;port=3307;database=HOTSTalentBuildData;password=ag@R5uCieq&%ENcC5Ehs;";
            SelectedHeroes = new string[] { "ALL" };
            SelectedRanks = new string[] { "Master", "Diamond", "Platinum" };
            Builds = new string[] { Constants.Unchanged,
                Constants.Unchanged,
                Constants.Unchanged };
        }
    }
}
