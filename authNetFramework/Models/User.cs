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
        [DisplayName("Логин")]
        public string Name { get; set; }

        private string passwordIsRestricted;

        [DisplayName("Ограничение на пароль")]
        public string PasswordIsRestricted
        {
            get
            {
                return passwordIsRestricted == "true" ? "Да" : "Нет";
            }
            set 
            { 
                passwordIsRestricted = value; 
            }
        }

        private string isBlocked;

        [DisplayName("Заблокирован")]
        public string IsBlocked
        {
            get
            {
                return isBlocked == "true" ? "Да" : "Нет";
            }
            set
            {
                isBlocked = value;
            }
        }

        private string passwordValidityPeriod;

        [DisplayName("Срок действия пароля")]
        public string PasswordValidityPeriod
        {
            get
            {
                return passwordValidityPeriod == "0" ? "Нет" : passwordValidityPeriod;
            }
            set 
            {
                passwordValidityPeriod = value;
            }
        }

        private string passwordMinLength;

        [DisplayName("Минимальная длина пароля")]
        public string PasswordMinLength
        {
            get
            {
                return passwordMinLength == "0" ? "Нет" : passwordMinLength;
            }
            set
            {
                passwordMinLength = value;
            }
        }
    }
}
