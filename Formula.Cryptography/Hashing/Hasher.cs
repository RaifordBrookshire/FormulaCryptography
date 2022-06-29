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

        public Sha256HasherAlgorithm Sha256HasherAlgorithm { get; set; }


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
            byte[] hashBytes = _hashAlgorithm.ComputeHash(inputBytes);
            string result = ByteUtils.ToHashString(hashBytes);
            return result;

        }
    }
}
