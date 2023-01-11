using Formula.Cryptography.Hashing.Algorithms;
using Formula.Cryptography.Utils;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Formula.Cryptography.Hashing
{
	public class MapHasher
	{
		private IMapHashAlgorithm _algorithm = null;
		public MapHasher() : this(new FnvMapHashAlgorithm())
		{
		}
		public MapHasher(IMapHashAlgorithm algorithm)
		{
			_algorithm = algorithm;
		}

		public int Hash(string input, int min, int max)
		{
			return HashBytes(CryptoUtils.StringToBytes(input), min, max);
		}
		public int Hash(string input, int size)
		{
			return HashBytes(CryptoUtils.StringToBytes(input), size);
		}
		public int HashBytes(byte[] bytes, int size)
		{
			return HashBytes(bytes, 0, size - 1);
		}
		public int HashBytes2(byte[] bytes, int min, int max)
		{
			int hash = 0;
			foreach (var b in bytes)
			{
				hash += (int)b;
			}

			int range = max - min + 1;
			return (hash % range) + min;
		}
		public int HashBytes(byte[] bytes, int min, int max)
		{
			return _algorithm.HashBytes(bytes, min, max);

		}
	}
}
