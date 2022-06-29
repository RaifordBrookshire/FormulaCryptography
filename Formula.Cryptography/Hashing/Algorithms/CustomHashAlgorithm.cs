using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Formula.Cryptography.Hashing.Algorithms
{
    public class CustomHashAlgorithm : HashAlgorithm
    {
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new NotImplementedException();
        }
    }
}
