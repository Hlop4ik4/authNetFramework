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

            if(CurrentUser.IsAuthorized == false)
            {
                chanhePasswordToolStripMenuItem.Visible = false;
                buttonLogIn.Visible = true;
            }
            else
            {
                chanhePasswordToolStripMenuItem.Visible = true;
                buttonLogIn.Visible = false;
            }

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

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormAboutProgram();
            form.ShowDialog();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            var form = new FormAuth();
            form.ShowDialog();

            if (CurrentUser.IsAuthorized == false)
            {
                chanhePasswordToolStripMenuItem.Visible = false;
                buttonLogIn.Visible = true;
            }
            else
            {
                chanhePasswordToolStripMenuItem.Visible = true;
                buttonLogIn.Visible = false;
            }

            if (CurrentUser.IsAdmin)
            {
                createUserToolStripMenuItem.Visible = true;
                usersToolStripMenuItem.Visible = true;
            }
        }
    }
}
