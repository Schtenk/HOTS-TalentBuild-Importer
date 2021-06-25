﻿using System;
using System.Collections.Generic;

namespace HOTS_TalentBuild_Lib
{
    public static class LibConstants
    {
        public static readonly string HOTSDocumentPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Heroes of the Storm\\Accounts\\";
        public static readonly List<string> GameTypes = new List<string>
        {
            "Normal",
            "ARAM"
        };
        public static readonly Dictionary<string, string> GameTypesHP = new Dictionary<string, string>
        {
            { "Normal", "sl" },
            { "ARAM", "ar" }
        };
        //public static readonly List<string> VersionCategories = new List<string>
        //{
        //    "Major",
        //    "Minor",
        //};
        public static readonly List<string> Ranks = new List<string>
        {
            "Master",
            "Diamond",
            "Platinum",
            "Gold",
            "Silver",
            "Bronze",
            "Wood"
        };
        public static readonly Dictionary<string, string> TalentIdLookup = new Dictionary<string, string>
        {
            { "0" , "00" },
            { "1" , "01" },
            { "2" , "02" },
            { "3" , "04" },
            { "4" , "08" },
            { "5" , "10" },
            { "6" , "20" },
            { "7" , "40" },
            { "8" , "80" },
            { "9" , "00" }
        };

        public static readonly Dictionary<string, string> HeroStringLookup = new Dictionary<string, string>
        {
            { "Abathur", "2E6BA0C7F0945B" },
            { "Alarak", "F985B31D7FABEB" },
            { "Alexstrasza", "C4218A71921173" },
            { "Amazon", "9060F0E64787D1" },
            { "Ana", "5550BAD54C623B" },
            { "Anduin", "727A32608DC64A" },
            { "Anubarak", "B81CD68FCC23B4" },
            { "Artanis", "3BB45C9A5C9BC7" },
            { "Arthas", "8D6C2BF5F13792" },
            { "Auriel", "C54BEEE3A385CF" },
            { "Azmodan", "A094E2C9693649" },
            { "Barbarian", "FB7F0C970D4ACF" },
            { "Butcher", "DF98C6D64368F0" },
            { "Chen", "70BC42AD71FA48" },
            { "Cho", "FE188EF13759A6" },
            { "Chromie", "5DB6BEAC15AD92" },
            { "Crusader", "D9A216D8AAC2A6" },
            { "DVa", "B056CD4F470A77" },
            { "Deathwing", "52A50F3DC087E6" },
            { "Deckard", "D7FBF3345949E5" },
            { "Dehaka", "06C0E298A75ADE" },
            { "DemonHunter", "6C2A92199CE15F" },
            { "Diablo", "3941B97EA2E595" },
            { "Dryad", "810F87C97D694D" },
            { "FaerieDragon", "F64470EAB69ECD" },
            { "Falstad", "6FCDE43847A38D" },
            { "Fenix", "EF8E692F946CD6" },
            { "Firebat", "3B5322AE84AB7D" },
            { "Gall", "F232B21302004B" },
            { "Garrosh", "EB47F766E95D78" },
            { "Genji", "FB82B8B915F803" },
            { "Greymane", "75D5054268A86F" },
            { "Guldan", "56E31DB2259923" },
            { "Hanzo", "1FD40C129CC38A" },
            { "Hogger", "B2772400A12093" },
            { "Illidan", "38811B4CED9831" },
            { "Imperius", "22B0D7408A65C1" },
            { "Jaina", "2E70D0062730D1" },
            { "Junkrat", "EF120FCC93D7B6" },
            { "Kaelthas", "86D5ADE0AD03FB" },
            { "KelThuzad", "C8890FAF580844" },
            { "Kerrigan", "435B884F2D9DA7" },
            { "L90ETC", "6C3CE237A080F7" },
            { "Leoric", "EA433C82F7FAD4" },
            { "LiLi", "CF25F23462AF26" },
            { "LostVikings", "E8ED96ED1EB6DC" },
            { "Lucio", "F6500D17E7C2ED" },
            { "Maiev", "2B7EAA4539C3F7" },
            { "MalGanis", "42EF14DFF879D6" },
            { "Malfurion", "8127E303AB0A91" },
            { "Malthael", "8FA21E3D7FD6EB" },
            { "Medic", "A24CDEAA299868" },
            { "Medivh", "0DBEFB89992388" },
            { "MeiOW", "7AE74832BACE98" },
            { "Mephisto", "B7E55A546498DA" },
            { "Monk", "8792B53BC067EA" },
            { "Muradin", "56E389BD80B9D7" },
            { "Murky", "4D425DC9FD4704" },
            { "Necromancer", "B4166E5BDF2286" },
            { "NexusHunter", "B6987184816E2F" },
            { "Nova", "B6DCD69BB65CB3" },
            { "Orphea", "E34F3E36ED9CED" },
            { "Probius", "66B18B01F8404F" },
            { "Ragnaros", "5FF5F209412408" },
            { "Raynor", "728B6EEF48568E" },
            { "Rehgar", "CF7C9F75BD91BC" },
            { "Rexxar", "BA923C83C84BDF" },
            { "Samuro", "217255C2AACF88" },
            { "SgtHammer", "92F99B7B94806D" },
            { "Stitches", "F4176A32FBEEBE" },
            { "Stukov", "D7F5F076D1FE8E" },
            { "Sylvanas", "06BC297F581C10" },
            { "Tassadar", "30575D7BBA845D" },
            { "Thrall", "555674B4D06CE5" },
            { "Tinker", "F786564B3D0FB2" },
            { "Tracer", "535AAB74DDF33C" },
            { "Tychus", "03991F27DE48F1" },
            { "Tyrael", "ADAC2D621B5233" },
            { "Tyrande", "3ED0CEF0B2CAEC" },
            { "Uther", "1D6D8C321DCAB9" },
            { "Valeera", "A65F0404129175" },
            { "Varian", "AA275A0AF3C560" },
            { "Whitemane", "43E85D1E92E92B" },
            { "WitchDoctor", "463F6BF63C8912" },
            { "Wizard", "2EF65E909A6D57" },
            { "Yrel", "C0CA56FA10CAB5" },
            { "Zagara", "FCCE7E80F03E2E" },
            { "Zarya", "4B767AB01C0D73" },
            { "Zeratul", "88C16EE24C8E67" },
            { "Zuljin", "BE6661C5340EF7" }
        };

    }
}