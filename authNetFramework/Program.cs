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
                var users = new XElement("users");

                users.Add(new XElement("user",
                    new XElement("name", "ADMIN"),
                    new XElement("password", ""),
                    new XElement("passwordminlength", 0),
                    new XElement("passwordvalidityperiod", 0),
                    new XElement("passwordisrestricted", "false"),
                    new XElement("isblocked", "false")));

                var xDocument = new XDocument(users);
                /*xDocument.Save(Options.FilePath);*/

                DESEncryptor.EncryptFile(xDocument);
            }
            else
            {
                var s = DESEncryptor.DecryptFile();
            }
        }
    }
}
