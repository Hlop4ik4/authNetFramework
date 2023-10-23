using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace authNetFramework.Hash
{
    internal static class Hash
    {
        public static string CreateSHA256(string input)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(input)));
            } 
        }
    }
}
