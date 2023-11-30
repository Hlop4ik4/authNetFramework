using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authNetFramework.Models
{
    public class UserViewModel
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

        private DateTime? passwordExpiredAt;

        [DisplayName("Дата окончания действия пароля")]
        public string PasswordExpiredAt
        {
            get
            {
                return passwordExpiredAt == null ? "Никогда" : Convert.ToString(passwordExpiredAt);
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    passwordExpiredAt = null;
                else
                    passwordExpiredAt = DateTime.Parse(value);
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
