using SchtenksFramework.Services;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace HOTS_TalentBuild_Importer
{
    public class HOTSTalentBuildSettings: Settings<HOTSTalentBuildSettings>
    {
        //public readonly static HOTSTalentBuildSettings SettingsInstance = SettingsService<HOTSTalentBuildSettings>.Instance;
        
        public string HOTSPATH { get; set; }
        public string[] SelectedHeroes { get; set; }
        public string SelectedVersion { get; set; }
        public string[] SelectedRanks { get; set; }
        public int SelectedNumberOfBuilds {get; set; }
      

        public override void SetDefaults()
        {
            HOTSPATH = "";
            SelectedHeroes = new string[] { "ALL" };
            SelectedVersion = "Minor";
            SelectedRanks = new string[] { "Master", "Diamond", "Platinum" };
            SelectedNumberOfBuilds = 3;
        }
    }
}
