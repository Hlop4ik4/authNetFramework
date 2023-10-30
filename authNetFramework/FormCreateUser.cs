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
using System.Xml.XPath;
using authNetFramework.Constant;

namespace authNetFramework
{
    public partial class FormCreateUser : Form
    {
        public FormCreateUser()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrEmpty(textBoxPasswordMinLength.Text) && !string.IsNullOrEmpty(textBoxPasswordValidityPeriod.Text))
            {
                var xDoc = XDocument.Load(Options.FilePath);

                if(xDoc.XPathSelectElements("//user").FirstOrDefault(x => x.Element("name").Value == textBoxName.Text) == null)
                {
                    xDoc.Element("users")
                        .Add(new XElement("user",
                        new XElement("name", textBoxName.Text),
                        new XElement("password", ""),
                        new XElement("passwordminlength", textBoxPasswordMinLength.Text),
                        new XElement("passwordvalidityperiod", textBoxPasswordValidityPeriod.Text),
                        new XElement("passwordisrestricted", checkBox.Checked),
                        new XElement("isblocked", "false")));

                    xDoc.Save(Options.FilePath);

                    MessageBox.Show("Создание пользователя прошло успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBoxName.Text = string.Empty;
                    textBoxPasswordMinLength.Text = string.Empty;
                    textBoxPasswordValidityPeriod.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxPasswordMinLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBoxPasswordValidityPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
