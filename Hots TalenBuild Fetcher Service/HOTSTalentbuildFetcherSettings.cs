using SchtenksFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HOTS_TalenBuild_Fetcher_Service
{
    public class HOTSTalentbuildFetcherSettings : Settings<HOTSTalentbuildFetcherSettings>
    {
        public string HOTSPATH { get; set; }
        public string ConnectionString { get; set;
        }
        public override void SetDefaults()
        {
            HOTSPATH = "G:\\Heroes of the Storm\\";
            ConnectionString = "server=steinwalls.synology.me;user id=root;persistsecurityinfo=True;port=3307;database=HOTSTalentBuildData;password=FktP^7Ls^pa!J4^!2TYJ;";
        }
    }
}
