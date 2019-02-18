using System;
using System.Security.Cryptography;
using System.Text;

namespace MyPet.Utils
{
    public static class HashHelper
    {
        public static string GetHashedData(string text)
        {
            string key = "julierich4ever";
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
                return BitConverter.ToString(hashBytes);
            }
        }

        public static bool ValidateHash(string inputData, string storedHash)
        {
            string getHashInputData = GetHashedData(inputData);
            if (string.Compare(getHashInputData, storedHash) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
