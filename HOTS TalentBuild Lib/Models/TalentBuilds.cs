﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HOTS_TalentBuild_Lib.Models
{
    public class TalentBuild
    {
        [Key]
        [MaxLength(100)]
        public string HeroID { get; set; }
        [MaxLength(100)]
        public string Ranks { get; set; }
        [MaxLength(50)]
        public string Version { get; set; }
        [MaxLength(50)]
        public int BuildNumber { get; set; }
        public string Build { get; set; }
        public int Wins { get; set; }
        public int TotalGames { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}