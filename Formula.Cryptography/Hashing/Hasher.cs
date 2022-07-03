using Formula.Cryptography.Hashing.Algorithms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Formula.Cryptography.Utils;

namespace Formula.Cryptography.Hashing
{
    public class Hasher
    {
        private HashAlgorithm _hashAlgorithm = null;

        public Hasher() : this(SHA256.Create())
        {
        }
        public Hasher(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm; 
        }
     
        public string Hash(string inputString)
        {
            byte[] inputBytes = ByteUtils.StringToBytes(inputString);
            byte[] hashBytes = HashBytes(inputBytes);
            string result = ByteUtils.ToHashString(hashBytes);
            return result;
        }

        public byte[] HashBytes(byte[] bytes)
        {
            byte[] hashBytes = _hashAlgorithm.ComputeHash(bytes);
            return hashBytes;
        }
    }
}
