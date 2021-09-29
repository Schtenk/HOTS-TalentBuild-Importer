using HOTS_TalentBuild_Lib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace HOTS_TalentBuild_Lib
{
    public class HeroData
    {
        public static List<Hero> Heroes { get; set; }
        public static void FetchData()
        {
            var client = new WebClient();
            var result = client.DownloadString("https://schtenk.github.io/HOTS-TalentBuild-Importer-Data/");
            Heroes = JsonSerializer.Deserialize<List<Hero>>(result);
        }
    }
}
