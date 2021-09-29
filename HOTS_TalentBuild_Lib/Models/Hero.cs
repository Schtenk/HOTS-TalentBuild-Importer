using System.Collections.Generic;
namespace HOTS_TalentBuild_Lib.Models
{
    public class Hero
    {
        public string HeroID { get; set; }
        public string Name { get; set; }
        public string HotsProfileName { get; set; }
        public List<TalentBuild> TalentBuilds { get; set; }
    }
}
