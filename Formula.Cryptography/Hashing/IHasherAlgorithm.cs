using System;
using System.Collections.Generic;
using System.Text;

namespace Formula.Cryptography.Hashing
{
    /// <summary>
    /// IHasherAlgorithm specifies what hashing algorithm will be used to compute the hash. The default
    /// value if NOT specified will use the Sha256HasherAlorithm
    /// </summary>
    public interface IHasherAlgorithm
    {
        byte[] HashBytes(byte[] bytes);
    }
}
