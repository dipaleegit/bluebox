using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class Utility
    {
        public static string CalculateHash(string input)
        {
            //Convert the input to a byte array using specified encoding
            var InputBuffer = Encoding.Unicode.GetBytes(input);
            //Hash the input
            byte[] HashedBytes;
            using (var Hasher = new SHA256Managed())
            {
                HashedBytes = Hasher.ComputeHash(InputBuffer);
            }
            //Return
            return BitConverter.ToString(HashedBytes).Replace("-", string.Empty);
        }

        public static string GetRandomPassword()
        {
            var passLength = 7;
            const string specialChar = "!@#$%";
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" + specialChar;
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < passLength--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            res.Append(specialChar[rnd.Next(specialChar.Length)]);
            return res.ToString();
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }
            return value.ToString();
        }
    }
}
