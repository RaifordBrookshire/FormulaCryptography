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
            byte[] inputBytes = CryptoUtils.StringToBytes(inputString);
            byte[] hashBytes = HashBytes(inputBytes);
            string result = CryptoUtils.ToHashString(hashBytes);
            return result;
        }

		public string Hash(string input, int iterations)
		{  
            string prevInput = input;
            string newHash = "";

			for(int i=0; i<iterations; i++) 
            {
                newHash = Hash(prevInput);
                prevInput = newHash;
            }
            return newHash;
		}

		public string Hash(string input, string secret)
		{
            // NOTE:    Combining the input and secret is using a very simple algorithm of 
            //          hashing each individual component, combine the string and rehash.
            //          This 'algorithm' could be changed or even abstracted in the future.
            //          But simplicity is hard to beat and several other apps use this as well.
            string h1 = Hash(input);
            string h2 = Hash(secret);
            string combined = $"{h1}{h2}";
            string newHash = Hash(combined);
            return newHash;
		}
        
		public byte[] HashBytes(byte[] bytes)
        {
            byte[] hashBytes = _hashAlgorithm.ComputeHash(bytes);
            return hashBytes;
        }
    }
}
