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
            { "Kaelthas", "86D5ADE0AD03FB" },
            { "Varian", "AA275A0AF3C560" },
            { "Malfurion", "7781E303AB0A91" },
            { "Amazon", "9060F0E64787D1" },
            { "Lucio", "F6500D17E7C2ED" },
            { "Probius", "66B18B01F8404F" },
            { "Butcher", "DF98C6D64368F0" },
            { "Rexxar", "BA923C83C84BDF" },
            { "Auriel", "A04BEEE3A385CF" },
            { "Alarak", "F985B31D7FABEB" },
            { "Guldan", "56E31DB2259923" },
            { "Stitches", "38C553327AA23D" },
            { "Raynor", "008B32EF2A4753" },
            { "Azmodan", "A094E2C9693649" },
            { "Crusader", "3D102ED8AA4BA6" },
            { "Wizard", "2EF65E909A6D57" },
            { "Jaina", "2E70D0062730D1" },
            { "Zarya", "4B7644B01C0D73" },
            { "Medivh", "0DBEFB89992388" },
            { "Tyrande", "3ED0CEF0B2CAEC" },
            { "Barbarian", "FB7F0C970D4ACF" },
            { "Tyrael", "ADAC2D621B5233" },
            { "Uther", "1D6D8C321DCAB9" },
            { "Murky", "4D425DC9FD4704" },
            { "Leoric", "EA433C82F7FAE1" },
            { "Diablo", "3941B97EA2E595" },
            { "Kerrigan", "435B884F2D9DA7" },
            { "Tassadar", "30575D7BBA845D" },
            { "Ragnaros", "5FF5F209412408" },
            { "Nova", "B6DCD69BB65CB3" },
            { "Arthas", "8D6C2BF5F13792" },
            { "Chromie", "5DB6BEAC15AD92" },
            { "SgtHammer", "92F99B7B94806D" },
            { "Medic", "A24CDEAAE39884" },
            { "Anubarak", "B81CD68F6E2368" },
            { "Dehaka", "06C0E298235A7F" },
            { "Tracer", "535AAB74DDF33C" },
            { "Abathur", "2E6BA0C7F0945B" },
            { "LiLi", "C9BC9E3413AF26" },
            { "Monk", "8792B53BC067B7" },
            { "FaerieDragon", "F64470EAB69ECD" },
            { "Artanis", "3BB4C09A5C9BC7" },
            { "Rehgar", "BB3B03750091EB" },
            { "Muradin", "56E389BDE9B9D7" },
            { "Tinker", "F786564B3D0FB2" },
            { "LostVikings", "E8ED96ED1EB6DC" },
            { "WitchDoctor", "463F6BF63C89A6" },
            { "Falstad", "94CDE438D6A38D" },
            { "Tychus", "12997027DE48F1" },
            { "Illidan", "381B814CED9831" },
            { "Chen", "70BC42AD71FA48" },
            { "Sylvanas", "06BC297F581C10" },
            { "Thrall", "555674B4D06C49" },
            { "Zagara", "FCCE7E80F03E90" },
            { "L90ETC", "6C3CE237A080F7" },
            { "Zeratul", "88C16EE24C8E67" },
            { "Valeera", "A65F0404129175" },
            { "DemonHunter", "FA928E199C01F5" },
            { "Dryad", "810F87C97D694D" },
            { "Greymane", "75D5054268A86F" },
            { "Zuljin", "BE6661C5340EF7" },
            { "Necromancer", "B4166E5BDF2286" },
            { "Samuro", "217255C2AACF88" },
            { "Alexstrasza", "C4218A71921173" },
            { "Ana", "5550BAD54C623B" },
            { "Anduin", "E77A91608DC45A" },
            { "Firebat", "3B5384AE5EAB7D" },
            { "Cho", "FE188EF13759A6" },
            { "Deathwing", "52A50F3DC087E6" },
            { "Deckard", "D7FBF3345949E5" },
            { "DVa", "B056CD4F470A77" },
            { "Fenix", "EF8E692F946CD7" },
            { "Gall", "F232B21302004B" },
            { "Garrosh", "EB47C966E95D78" },
            { "Genji", "FB8261B915F803" },
            { "Hanzo", "1FD40C129CC38A" },
            { "Hogger", "B2772400A12093" },
            { "Imperius", "22B0D7408A65C1" },
            { "Junkrat", "EF123CCC79D7B6" },
            { "KelThuzad", "C8890FAF580844" },
            { "Maiev", "2B7EAA4539C3F7" },
            { "MalGanis", "42EF14DFF879D6" },
            { "Malthael", "8FA21E3D7FD6EB" },
            { "MeiOW", "7AE74832BACE98" },
            { "Mephisto", "B7E55A546498DA" },
            { "Orphea", "E34F3E36ED9CED" },
            { "NexusHunter", "B6987184816E2F" },
            { "Stukov", "EBF5F07690FE8E" },
            { "Whitemane", "43E85D1E92E92B" },
            { "Yrel", "C0CA56FA10CAB5" }
        };
    }
}
