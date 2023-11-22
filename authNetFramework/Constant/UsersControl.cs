using authNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using authNetFramework.StaticClasses;

namespace authNetFramework.Constant
{
    public static class UsersControl
    {
        public static List<User> Users { get; } = new List<User>();

        public static void Save()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var user in Users)
            {
                sb.AppendLine($"12345678name:{user.Name};password:{user.Password};passwordminlength:{user.PasswordMinLength};passwordvalidityperiod:{user.PasswordValidityPeriod};passwordisrestricted:{user.PasswordIsRestricted};isblocked:{user.IsBlocked}");
            }

            DESEncryptor.EncryptFile(sb.ToString());
        }

        public static void Load()
        {
            var s = DESEncryptor.DecryptFile();

            string[] stringSeparators = new string[] { "\r\n" };
            foreach (var subStr in s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries))
            {
                User user = new User();
                foreach (var item in subStr.Split(';'))
                {
                    string[] optionValue = item.Split(':');

                    switch (optionValue[0])
                    {
                        case "name":
                            user.Name = optionValue[1];
                            break;
                        case "password":
                            user.Password = optionValue[1];
                            break;
                        case "passwordminlength":
                            user.PasswordMinLength = optionValue[1];
                            break;
                        case "passwordvalidityperiod":
                            user.PasswordValidityPeriod = optionValue[1];
                            break;
                        case "passwordisrestricted":
                            user.PasswordIsRestricted = optionValue[1];
                            break;
                        case "isblocked":
                            user.IsBlocked = optionValue[1];
                            break;
                        default:
                            if (optionValue[0].Contains("name"))
                            {
                                user.Name = optionValue[1];
                                break;
                            }
                            break;
                    }
                }
                Users.Add(user);
            }
        }
    }
}
