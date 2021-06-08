using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HOTS_TalentBuild_Lib.Models
{
    public static class  Versions
    {
        public const string ModelName = "Versions";
        public class MajorVersion
        {
            public MajorVersion()
            {
                ExistsOnHotsProfile = true;
            }
            [Key]
            public string MajorVersionID { get; set; }
            public bool ExistsOnHotsProfile { get; set; }
            public virtual List<MinorVersion> MinorVersions { get; set; }
        }

        public class MinorVersion
        {

            [Key]
            public string VersionID { get; set; }
            public string MajorVersionID { get; set; }
        }
    }

}
