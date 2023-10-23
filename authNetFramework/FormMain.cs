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
using authNetFramework.User;

namespace authNetFramework
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            var authForm = new FormAuth();
            authForm.ShowDialog();

            if (CurrentUser.isAdmin)
            {
                createUserToolStripMenuItem.Visible = true;
            }
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateUser();
            form.ShowDialog();
        }
    }
}
