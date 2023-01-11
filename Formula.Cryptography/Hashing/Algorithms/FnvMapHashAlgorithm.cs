using System;
using System.Collections.Generic;
using System.Text;

namespace Formula.Cryptography.Hashing.Algorithms
{
	public class FnvMapHashAlgorithm : IMapHashAlgorithm
	{
		public string AlgorithmName { get; set; }

		public int HashBytes(byte[] bytes, int size)
		{
			return HashBytes(bytes, 0, size - 1);
		}

		public int HashBytes(byte[] bytes, int min, int max)
		{
			//This implementation uses the FNV-1a hash function to calculate the hash
			//value of the input array, which is generally more robust than the
			//simple sum used in the original implementation.It also caches the
			//range value and uses the modulo operator more effectively to ensure
			//that the resulting hash value is always within the desired range.

			// Use the FNV-1a hash function to calculate the hash value
			const uint fnvPrime = 0x01000193;
			uint hash = 0x811C9DC5;
			foreach (var b in bytes)
			{
				hash ^= b;
				hash *= fnvPrime;
			}

			// Cache the range value
			int range = max - min + 1;

			// Use the modulo operator more effectively
			return (int)((hash % range) + min - (hash % range < 0 ? range : 0));
		}
	}
}

		//There are many different hashing algorithms that you can
		//use as alternatives to the FNV-1a hash function.Here are a few examples:

		//MurmurHash: This is a fast, non-cryptographic hash function
		//that is well-suited for hash-based data structures.It has a good
		//distribution of hash values and is relatively resistant to hash collision attacks.

		//SHA-2: This is a family of cryptographic hash functions
		//that are widely used for data integrity checks.SHA-2 functions
		//are slower than non-cryptographic hash functions, but they
		//provide a higher level of security and are suitable
		//for use in situations where data integrity is important.

		//BLAKE2: This is a cryptographic hash function that is
		//designed to be fast and secure. It has a variable-length
		//output and can be used as a drop-in replacement for
		//MD5, SHA-1, and other hash functions.

		//FarmHash: This is a fast, non-cryptographic hash function that is
		//designed for use in distributed systems. It has a
		//good distribution of hash values and is relatively resistant to hash collision attacks.
