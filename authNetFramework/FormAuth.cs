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
using authNetFramework.User;
using authNetFramework.Constant;
using authNetFramework.Hash;

namespace authNetFramework
{
    public partial class FormAuth : Form
    {
        private XDocument xDoc = XDocument.Load(Options.FilePath);

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
                    foreach (var user in xDoc.XPathSelectElements("//user"))
                    {
                        if (user.Element("name").Value == textBoxLogin.Text)
                        {
                            loginExist = true;
                            textBoxLogin.Visible = false;
                            labelLogin.Visible = false;
                            textBoxPassword.Visible = true;
                            labelPassword.Visible = true;
                            CurrentUser.Name = user.Element("name").Value;
                            CurrentUser.isAdmin = CurrentUser.Name == "ADMIN" ? true : false;
                            if (string.IsNullOrEmpty(user.Element("password").Value))
                            {
                                textBoxPassword2.Visible = true;
                                labelPassword2.Visible = true;
                            }
                            break;
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
                var userPasswordXDoc = xDoc.XPathSelectElements("//user")
                                           .FirstOrDefault(x => x.Element("name").Value == CurrentUser.Name)
                                           .Element("password")
                                           .Value;
                if (string.IsNullOrEmpty(userPasswordXDoc))
                {
                    if(!string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxPassword2.Text))
                    {
                        if(textBoxPassword.Text == textBoxPassword2.Text)
                        {
                            xDoc.XPathSelectElements("//user")
                                .FirstOrDefault(x => x.Element("name").Value == CurrentUser.Name)
                                .Element("password").Value = Hash.Hash.CreateSHA256(textBoxPassword.Text);

                            xDoc.Save(Options.FilePath);

                            CurrentUser.Password = textBoxPassword.Text;
                            CurrentUser.isAuthorized = true;

                            MessageBox.Show("Пароль успешно создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
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
                else
                {
                    if (!string.IsNullOrEmpty(textBoxPassword.Text))
                    {
                        if(Hash.Hash.CreateSHA256(textBoxPassword.Text) == userPasswordXDoc)
                        {
                            CurrentUser.isAuthorized = true;
                            MessageBox.Show("Авторизация прошла успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(CurrentUser.isAuthorized)
                {
                    this.Close();
                }
            }
        }
    }
}
