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
        public string SelectedVersion { get; set; }
        public string[] SelectedRanks { get; set; }
        public int SelectedNumberOfBuilds {get; set; }

        public override void SetDefaults()
        {
            ConnectionString = "server=steinwalls.synology.me;user id=root;persistsecurityinfo=True;port=3307;database=HOTSTalentBuildData;password=FktP^7Ls^pa!J4^!2TYJ;";
            SelectedHeroes = new string[] { "ALL" };
            SelectedVersion = "Minor";
            SelectedRanks = new string[] { "Master", "Diamond", "Platinum" };
            SelectedNumberOfBuilds = 3;
        }
    }
}
