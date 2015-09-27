using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace p7cSarlWF.Models.Service
{
    public class P7CUtils
    {

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string ConvertFileLengthToHuman(double length)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (length >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                length = length / 1024;
            }
            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##} {1}", length, sizes[order]);

            return result;
        }
    }
}