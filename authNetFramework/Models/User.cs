using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authNetFramework.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string PasswordIsRestricted { get; set; }

        public string IsBlocked { get; set; }

        public string PasswordMinLength { get; set; }

        public int PasswordValidityPeriod { get; set; }

        public DateTime? PasswordExpiredAt { get; set; }
    }
}
