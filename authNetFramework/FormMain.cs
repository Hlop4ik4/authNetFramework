using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using authNetFramework.StaticClasses;

namespace authNetFramework
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            var authForm = new FormAuth();
            authForm.ShowDialog();

            if (CurrentUser.IsAdmin)
            {
                createUserToolStripMenuItem.Visible = true;
                usersToolStripMenuItem.Visible = true;
            }
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateUser();
            form.ShowDialog();
        }

        private void chanhePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormChangePassword();
            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUsers();
            form.ShowDialog();
        }
    }
}
