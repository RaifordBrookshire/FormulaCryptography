using Formula.Cryptography.Hashing;
using Formula.Cryptography.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Formula.Cryptography.UnitTests.Hashing
{
	public class MapHasherTests
	{
		[Fact]
		public void Basic_Usage()
		{
			int count = 100000;
			int min = 1;
			int max = 1000;
			
			MapHasher hasher = new MapHasher();
			int index = hasher.Hash("Some Data", 5); // Return a value from 0-4

		}

		[Fact]
		public void HashBytes_Iterate_Verify_Ranges()
		{
			int count = 100000;
			int min = 1;
			int max = 1000;
			List<int> indexes = new List<int>();
			MapHasher hasher = new MapHasher();

			for (int i = 0; i < count; i++)
			{
				int index = hasher.HashBytes(Guid.NewGuid().ToByteArray(), min, max);
				indexes.Add(index);
			}

			// This code just to view the distibution of the indexes across the range
			var results = indexes.GroupBy(i => i)
								 .Select(g => new { Value = g.Key, Count = g.Count() })
								 .OrderByDescending(x => x.Count);
			results.ToList().ForEach(x => Trace.WriteLine($"{x.Value} count:{x.Count}"));

			Assert.All(indexes, i => Assert.InRange(i, min, max));
		}


		[Fact]
		public void MapHasher_MapAnyObject()
		{
			MapHasher hasher = new MapHasher();

			byte[] bytes = CryptoUtils.GetRandomBytes(100);


			int index = hasher.Hash("My Text To Hash", 0, 100);





		}
	}
}
