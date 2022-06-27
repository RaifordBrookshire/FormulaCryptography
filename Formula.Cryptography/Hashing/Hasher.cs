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
        private IHasherAlgorithm _algorithm = null;

        public Sha256HasherAlgorithm Sha256HasherAlgorithm { get; set; }


        public Hasher() : this(new Sha256HasherAlgorithm())
        {
        }
        public Hasher(IHasherAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

      
        /// <summary>
        /// Hashes the inputString and returns the hashed results using the assigned IHasherAlgorithm.
        /// If the Hasher was create using the default constructor the hasher will use the Sha256HasherAlgorithm by default
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>the Hash string</returns>
        public string Hash(string inputString)
        { 
            byte[] inputBytes = ByteUtils.StringToBytes(inputString);
            byte[] hashBytes = _algorithm.HashBytes(inputBytes);
            string result = ByteUtils.ToHashString(hashBytes);
            return result;
        }
    }
}
