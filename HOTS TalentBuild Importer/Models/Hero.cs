using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HOTS_TalentBuild_Importer.Models
{
    public class Hero
    {
        public const string ModelName = "Hero";
        [Key]
        [MaxLength(100)]
        public string HeroID { get; set; }
        public string Name { get; set; }
        public string HotsProfileName { get; set; }
        public List<TalentBuild> TalentBuilds { get; set; }
    }
}
