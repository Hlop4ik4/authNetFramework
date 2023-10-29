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
using authNetFramework.Constant;
using authNetFramework.Models;

namespace authNetFramework
{
    public partial class FormUsers : Form
    {
        private XDocument xDoc = XDocument.Load(Options.FilePath);
        private List<User> Users = new List<User>();

        public FormUsers()
        {
            InitializeComponent();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            var xElements = xDoc.Root.Elements("user");

            foreach(var elem in xElements)
            {
                Users.Add(new User
                {
                    Name = elem.Element("name").Value
                });
            }

            if(Users.Count > 0)
            {
                dataGridView.DataSource = Users;
            }
        }
    }
}
