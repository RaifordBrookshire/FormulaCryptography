using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula.Cryptography.Utils
{
    public class ByteUtils
    {
        static public bool CompareBytes(byte[] bytes1, byte[] bytes2)
        {
            // This might not be needed and based on performace could be refactored out
            if(bytes1.Length != bytes2.Length)
                return false;

            return bytes1.SequenceEqual(bytes2);            
        }

        static public string ToHashString(byte[] bytes)
        {
            // Convert bytes to string. NOTE: the string will contain dashes whihich we wil remove
            string hash = BitConverter.ToString(bytes);

            // Remove the dashes
            return hash.Replace("-", "");
        }

        static public byte[] StringToBytes(string input)
        {           
            return Encoding.UTF8.GetBytes(input);
        }

        static public string BytesToString(byte[] bytes)
        {           
            string result = BitConverter.ToString(bytes);
            result = BytesToString(bytes);
            return result;
        }


        //
        //public static byte[] GenerateRandomByteHash(bool bruteForceMode = false)
        //{
        //    byte[] bytes = new byte[32];
        //    return bytes;
        //}

        //// Needs Testing and refactoring
        //public static void PrintByteArray(byte[] array)
        //{
        //    int i;
        //    for (i = 0; i < array.Length; i++)
        //    {
        //        Console.Write(String.Format("{0:X2}", array[i]));
        //        if ((i % 4) == 3) Console.Write(" ");
        //    }
        //    Console.WriteLine();
        //}

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] buffer = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, buffer, 0, first.Length);
            Buffer.BlockCopy(second, 0, buffer, first.Length, second.Length);
            return buffer;
        }
    }
}
