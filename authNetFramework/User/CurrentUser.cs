using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authNetFramework.User
{
    internal static class CurrentUser
    {
        public static string Name { get; set; }
        public static string Password { get; set; }
        public static bool isAuthorized { get; set; }
        public static bool isAdmin { get; set;}
    }
}
