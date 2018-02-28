using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace PlayYourCV.Models
{
    public static class Codifica
    {
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();  //o SHA512, o MD5
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string ConverteixPassword(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }

}