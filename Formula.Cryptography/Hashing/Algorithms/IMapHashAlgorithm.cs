using System;
using System.Collections.Generic;
using System.Text;

namespace Formula.Cryptography.Hashing.Algorithms
{
	public interface IMapHashAlgorithm
	{
		string AlgorithmName { get; set; }
		public int HashBytes(byte[] bytes, int size);
		public int HashBytes(byte[] bytes, int min, int max);

	}
}
