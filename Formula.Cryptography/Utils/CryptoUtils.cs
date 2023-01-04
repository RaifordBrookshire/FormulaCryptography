using Formula.Cryptography.Hashing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Formula.Cryptography.Utils
{
    public class CryptoUtils
    {
        public static byte[] GetRandomBytes(int bufferSize)
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            byte[] byteBuffer = new byte[bufferSize];
            random.GetBytes(byteBuffer);
            return byteBuffer;
        }
		public static byte[] StringToBytes(string text)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			return bytes;
		}

		public static string BytesToString(byte[] bytes)
		{
			string text = Encoding.UTF8.GetString(bytes); ;
			return text;
		}
		static public string ToHashString(byte[] bytes)
		{
			// Convert bytes to string. NOTE: the string will contain dashes whihich we wil remove
			string hash = BitConverter.ToString(bytes);

			// Remove the dashes
			return hash.Replace("-", "");
		}

	}
}
