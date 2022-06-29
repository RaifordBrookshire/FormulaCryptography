using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Formula.Cryptography.Hashing.Algorithms
{

    [Obsolete("This is an example of how to create an older style algorithm. Today you must derive from HashAlgorithm")]
    public class Sha256HasherAlgorithm : IHasherAlgorithm
    { 

        public byte[] HashBytes(byte[] bytes)
        {
            SHA256 sha = SHA256.Create();
            byte[] resultBytes = sha.ComputeHash(bytes);   
            return resultBytes;
        }
    }
}
