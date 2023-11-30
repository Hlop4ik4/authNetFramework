using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using authNetFramework.StaticClasses;
using authNetFramework.Constant;
using authNetFramework.Hash;
using System.Text.RegularExpressions;

namespace authNetFramework
{
    public partial class FormAuth : Form
    {
        private int wrongPasswordCount = 0;
        private bool userEnterExpiredPassword = false;

        public FormAuth()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentUser.Name))
            {
                if (!string.IsNullOrEmpty(textBoxLogin.Text))
                {
                    bool loginExist = false;
                    foreach (var user in UsersControl.Users)
                    {
                        if (user.Name == textBoxLogin.Text)
                        {
                            if(user.IsBlocked != "true")
                            {
                                loginExist = true;
                                textBoxLogin.Visible = false;
                                labelLogin.Visible = false;
                                textBoxPassword.Visible = true;
                                labelPassword.Visible = true;
                                CurrentUser.Name = user.Name;
                                CurrentUser.PasswordMinLength = Convert.ToInt32(user.PasswordMinLength);
                                CurrentUser.PasswordIsRestricted = user.PasswordIsRestricted == "true";
                                CurrentUser.IsAdmin = CurrentUser.Name == "ADMIN";
                                CurrentUser.PasswordExpiredAt = user.PasswordExpiredAt;
                                CurrentUser.PasswordValidityPeriod = user.PasswordValidityPeriod;
                                if (string.IsNullOrEmpty(user.Password))
                                {
                                    textBoxPassword2.Visible = true;
                                    labelPassword2.Visible = true;
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Пользователь с данным логином заблокирован", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (!loginExist)
                    {
                        MessageBox.Show("Логин не найден! Повторите снова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var userPassword = UsersControl.Users.FirstOrDefault(x => x.Name == CurrentUser.Name).Password;

                if (string.IsNullOrEmpty(userPassword))
                {
                    SaveUserPassword();
                }
                else
                {
                    if (userEnterExpiredPassword)
                    {
                        SaveUserPassword();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(textBoxPassword.Text))
                        {
                            if (Hash.Hash.CreateSHA256(textBoxPassword.Text) == userPassword)
                            {
                                if (DateTime.Now >= CurrentUser.PasswordExpiredAt)
                                {
                                    MessageBox.Show("Срок действия Вашего пароля истек! Введите новый пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    labelPassword2.Visible = true;
                                    textBoxPassword2.Visible = true;
                                    userEnterExpiredPassword = true;
                                    textBoxPassword.Text = string.Empty;
                                    textBoxPassword2.Text = string.Empty;
                                    return;
                                }
                                CurrentUser.IsAuthorized = true;
                                MessageBox.Show("Авторизация прошла успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                wrongPasswordCount += 1;
                                textBoxPassword.Text = string.Empty;
                                MessageBox.Show("Пароль введен неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (wrongPasswordCount == 3)
                                {
                                    MessageBox.Show("Превышено количество попыток ввода пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    Application.Exit();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if(CurrentUser.IsAuthorized)
                {
                    this.Close();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveUserPassword()
        {
            if (!string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxPassword2.Text))
            {
                if (textBoxPassword.Text == textBoxPassword2.Text)
                {
                    if (textBoxPassword.Text.Length >= CurrentUser.PasswordMinLength)
                    {
                        if (CurrentUser.PasswordIsRestricted && !Regex.IsMatch(textBoxPassword.Text, @"^((?=\S*?[A-ZА-Я])(?=\S*?[a-zа-я]).{0,})\S$"))
                        {
                            MessageBox.Show("Пароль должен содержать строчные и прописные буквы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UsersControl.Users
                                .FirstOrDefault(x => x.Name == CurrentUser.Name)
                                .Password = Hash.Hash.CreateSHA256(textBoxPassword.Text);

                            if(CurrentUser.PasswordExpiredAt != null)
                            {
                                UsersControl.Users
                                .FirstOrDefault(x => x.Name == CurrentUser.Name)
                                .PasswordExpiredAt = DateTime.Now.AddMonths(CurrentUser.PasswordValidityPeriod);
                            }

                            UsersControl.Save();

                            CurrentUser.IsAuthorized = true;

                            MessageBox.Show("Пароль успешно создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Длина пароля должна быть больше {CurrentUser.PasswordMinLength}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароли должны совпадать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
