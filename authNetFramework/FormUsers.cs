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
using authNetFramework.Models;

namespace authNetFramework
{
    public partial class FormUsers : Form
    {
        private XDocument xDoc;

        public FormUsers()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            xDoc = XDocument.Load(Options.FilePath);

            var xElements = xDoc.Root.Elements("user");

            var list = new List<User>();

            foreach (var elem in xElements)
            {
                if(elem.Element("name").Value != "ADMIN")
                {
                    list.Add(new User
                    {
                        Name = elem.Element("name").Value,
                        PasswordIsRestricted = elem.Element("passwordisrestricted").Value,
                        IsBlocked = elem.Element("isblocked").Value,
                        PasswordValidityPeriod = elem.Element("passwordvalidityperiod").Value,
                        PasswordMinLength = elem.Element("passwordminlength").Value
                    });
                }
            }

            if (list.Count > 0)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonBlock_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 1)
            {
                string selectedUserName = Convert.ToString(dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex].Cells[0].Value);
                var selectedUserIsBlock = xDoc.XPathSelectElement($"//user[name='{selectedUserName}']").Element("isblocked").Value == "true";
                var blockUnblockString = selectedUserIsBlock ? "разблокировать" : "заблокировать";

                if (MessageBox.Show($"Вы уверены что хотите {blockUnblockString} этого пользователя?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    xDoc.XPathSelectElement($"//user[name='{selectedUserName}']").Element("isblocked").Value = selectedUserIsBlock ? "false" : "true";

                    xDoc.Save(Options.FilePath);

                    LoadData();
                }
            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string selectedUserName = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[0].Value);

            if (xDoc.XPathSelectElement($"//user[name='{selectedUserName}']").Element("isblocked").Value == "true")
            {
                buttonBlock.Text = "Разблокировать";
            }
            else
            {
                buttonBlock.Text = "Заблокировать";
            }
            if (xDoc.XPathSelectElement($"//user[name='{selectedUserName}']").Element("passwordisrestricted").Value == "true")
            {
                buttonSetPasswordRestriction.Text = "Убрать ограничение на пароль";
            }
            else
            {
                buttonSetPasswordRestriction.Text = "Установить ограничение на пароль";
            }
        }

        private void buttonSetPasswordRestriction_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 1)
            {
                string selectedUserName = Convert.ToString(dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex].Cells[0].Value);
                var selectedUserPasswordIsRestricted = xDoc.XPathSelectElement($"//user[name='{selectedUserName}']").Element("isblocked").Value == "true";
                var setUnsetString = selectedUserPasswordIsRestricted ? "убрать" : "установить";

                if (MessageBox.Show($"Вы уверены что хотите {setUnsetString} ограничение на пароль для этого пользователя?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    xDoc.XPathSelectElement($"//user[name='{selectedUserName}']").Element("passwordisrestricted").Value = selectedUserPasswordIsRestricted ? "false" : "true";

                    xDoc.Save(Options.FilePath);

                    LoadData();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
