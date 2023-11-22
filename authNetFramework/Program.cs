using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using authNetFramework.Constant;
using System.Security.Cryptography;
using authNetFramework.StaticClasses;
using System.Xml;
using System.Text;
using authNetFramework.Models;

namespace authNetFramework
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateFile();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        private static void CreateFile()
        {
            if (!File.Exists(Options.FilePath))
            {
                string initString = "12345678name:ADMIN;password:;passwordminlength:0;passwordvalidityperiod:0;passwordisrestricted:false;isblocked:false;";

                DESEncryptor.EncryptFile(initString);

                UsersControl.Load();
            }
            else
            {
                UsersControl.Load();
            }
        }
    }
}
