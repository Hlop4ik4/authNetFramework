using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using authNetFramework.Hash;
using authNetFramework.Constant;
using System.Xml.XPath;
using authNetFramework.StaticClasses;

namespace authNetFramework
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxNewPassword.Text) && !string.IsNullOrEmpty(textBoxNewPassword2.Text) && !string.IsNullOrEmpty(textBoxOldPassword.Text))
            {
                if (Hash.Hash.CreateSHA256(textBoxOldPassword.Text) == UsersControl.Users.FirstOrDefault(x => x.Name == CurrentUser.Name).Password)
                {
                    if(textBoxNewPassword.Text == textBoxNewPassword2.Text && textBoxNewPassword.Text.Length >= CurrentUser.PasswordMinLength)
                    {
                        if(MessageBox.Show("Вы уверены что хотите сменить пароль?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            UsersControl.Users
                            .FirstOrDefault(x => x.Name == CurrentUser.Name)
                            .Password = Hash.Hash.CreateSHA256(textBoxNewPassword.Text);

                            UsersControl.Save();

                            MessageBox.Show("Смена пароля прошла успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Пароли должны совпадать и иметь длину больше {CurrentUser.PasswordMinLength}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Старый пароль введен неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
