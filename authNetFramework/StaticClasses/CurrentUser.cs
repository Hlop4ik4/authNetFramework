using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authNetFramework.StaticClasses
{
    internal class CurrentUser
    {
        public static string Name { get; set; }
        public static bool IsAuthorized { get; set; }
        public static bool IsAdmin { get; set; }
        public static int PasswordMinLength { get; set; }
        public static bool PasswordIsRestricted { get; set; }
    }
}
