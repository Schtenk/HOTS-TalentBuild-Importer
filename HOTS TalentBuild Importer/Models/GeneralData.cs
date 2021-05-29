using System;
using System.ComponentModel.DataAnnotations;

namespace HOTS_TalentBuild_Importer.Models
{
    public class GeneralData
    {
        [Key]
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
