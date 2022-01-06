using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MovieLibrary_v2._5.Models
{
    public static class CryptEm
    {
        public static string Gloria(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));

            byte[] result = md5.Hash;

            StringBuilder buildString = new StringBuilder();

            for (int f = 0; f < result.Length; f++)
            {
                buildString.Append(result[f].ToString("x2"));
            }

            return buildString.ToString();
        }
    }
}