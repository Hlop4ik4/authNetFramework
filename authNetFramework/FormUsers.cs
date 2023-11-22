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

        public FormUsers()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var list = new List<UserViewModel>();

            foreach (var elem in UsersControl.Users)
            {
                if(elem.Name != "ADMIN")
                {
                    list.Add(new UserViewModel
                    {
                        Name = elem.Name,
                        PasswordIsRestricted = elem.PasswordIsRestricted,
                        IsBlocked = elem.IsBlocked,
                        PasswordValidityPeriod = elem.PasswordValidityPeriod,
                        PasswordMinLength = elem.PasswordMinLength
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
                var selectedUserIsBlock = UsersControl.Users.FirstOrDefault(x => x.Name == selectedUserName).IsBlocked == "true";
                var blockUnblockString = selectedUserIsBlock ? "разблокировать" : "заблокировать";

                if (MessageBox.Show($"Вы уверены что хотите {blockUnblockString} этого пользователя?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsersControl.Users.FirstOrDefault(x => x.Name == selectedUserName).IsBlocked = selectedUserIsBlock ? "false" : "true";

                    UsersControl.Save();

                    LoadData();
                }
            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string selectedUserName = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[0].Value);

            if (UsersControl.Users.FirstOrDefault(x => x.Name == selectedUserName).IsBlocked == "true")
            {
                buttonBlock.Text = "Разблокировать";
            }
            else
            {
                buttonBlock.Text = "Заблокировать";
            }
            if (UsersControl.Users.FirstOrDefault(x => x.Name == selectedUserName).PasswordIsRestricted == "true")
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
                var selectedUserPasswordIsRestricted = UsersControl.Users.FirstOrDefault(x => x.Name == selectedUserName).PasswordIsRestricted == "true";
                var setUnsetString = selectedUserPasswordIsRestricted ? "убрать" : "установить";

                if (MessageBox.Show($"Вы уверены что хотите {setUnsetString} ограничение на пароль для этого пользователя?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsersControl.Users.FirstOrDefault(x => x.Name == selectedUserName).PasswordIsRestricted = selectedUserPasswordIsRestricted ? "false" : "true";

                    UsersControl.Save();

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
