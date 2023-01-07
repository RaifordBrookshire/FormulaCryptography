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
			return BitConverter.ToString(bytes);
		}
		static public string HashBytesToHashString(byte[] bytes)
		{
			string hash = BytesToString(bytes);
			return hash.ToLower().Replace("-", "");
		}

	}
}
