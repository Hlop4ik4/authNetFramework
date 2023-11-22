using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using authNetFramework.Constant;

namespace authNetFramework.StaticClasses
{
    public static class DESEncryptor
    {
        private readonly static string passPhrase = "PASSWORD";

        private static DES CreateDESProvider()
        {
            byte[] salt = new byte[] { 134, 77, 21, 3, 83, 52, 16, 117 };

            Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(passPhrase, salt, 100);

            byte[] key = keyGenerator.GetBytes(8);

            DES provider = DES.Create();
            provider.Mode = CipherMode.CBC;
            provider.Key = key;

            return provider;
        }

        private static byte[] EncryptDES(byte[] data)
        {
            var provider = CreateDESProvider();

            var transform = provider.CreateEncryptor();

            using (var encryptedStream = new MemoryStream())
            {
                using(var cryptoStream = new CryptoStream(encryptedStream, transform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    
                    return encryptedStream.ToArray();
                }
            }
        }

        private static byte[] DecryptDES(byte[] data)
        {
            var provider = CreateDESProvider();

            var transform = provider.CreateDecryptor();

            using(var decryptedStream = new MemoryStream())
            {
                using(var cryptoStream = new CryptoStream(decryptedStream, transform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);

                    cryptoStream.FlushFinalBlock();

                    return decryptedStream.ToArray();
                }
            }
        }

        public static void EncryptFile(string dataString)
        {
            byte[] data = Encoding.ASCII.GetBytes(dataString);
            byte[] encryptedData = EncryptDES(data);

            using(var fs = new FileStream(Options.FilePath, FileMode.OpenOrCreate))
            {
                fs.Write(encryptedData, 0, encryptedData.Length);
            }
        }

        public static string DecryptFile()
        {
            using (var fs = File.OpenRead(Options.FilePath))
            {
                byte[] data = new byte[fs.Length];

                fs.Read(data, 0, data.Length);

                byte[] decryptedData = DecryptDES(data);

                return Encoding.ASCII.GetString(decryptedData);
            }
        }
    }
}
