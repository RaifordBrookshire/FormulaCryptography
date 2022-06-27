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

            // This could also be done with a for loop
            return bytes1.SequenceEqual(bytes2);            
        }

        static public string ToHashString(byte[] bytes)
        {
            // Convert bytes to string. NOTE: the string will contain dashes whihich we wil remove
            string hash = BitConverter.ToString(bytes);

            // Remove the dashes
            string resultHash = hash.Replace("-", "");
            return resultHash;
        }

        static public byte[] StringToBytes(string input)
        {
            // This should be the SINGLE place to do this conversion so its
            // done uniformily. Should we every need to change it we do it here.
            return Encoding.UTF8.GetBytes(input);
        }

        static public string BytesToString(byte[] bytes)
        {
            // This should be the SINGLE place to do this conversion so its
            // done uniformily. Should we every need to change it we do it here.
            string result = BitConverter.ToString(bytes);
            result = BytesToString(bytes);
            return result;
        }


    }
}
