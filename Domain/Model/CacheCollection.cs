using System;
using System.Collections.Generic;

namespace Domain
{
    public static class CacheCollection
    {
        public static void Init()
        {
            UserNames = new List<string>();
            BusinessIdentifiers = new List<string>();
            RoleNames = new Dictionary<string, string>();
        }
        public static List<string> UserNames { get; set; }
        public static List<string> BusinessIdentifiers { get; set; }
        public static Dictionary<string, string> RoleNames { get; set; }
    }
}
