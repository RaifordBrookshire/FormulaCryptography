

using Formula.Cryptography.Hashing;
using Formula.Cryptography.Hashing.Algorithms;
using System;
using System.Security.Cryptography;
using Xunit;

namespace Formula.Cryptography.UnitTests.Hashing
{
    public class HasherTests
    {
     
        [Fact]
        public void Hasher_Basic_Usage()
        {         
            // ARRANGE
            const string testData = "abcd";
            const string expectedHash = "88d4266fd4e6338d13b845fcf289579d209c897823b9217da3e161936f031589";
            Hasher hasher = new Hasher(SHA256.Create());

            // ACT
            string resultHash = hasher.Hash(testData); 

            // ASSERT
            Assert.True(string.Equals(expectedHash, resultHash));        
        }

		[Fact]
		public void Hasher_Using_Iterations()
		{
			// ARRANGE
			const string testData = "abcd";
			const int iterations = 4;
			// use online tool to generate this
			const string expectedHash = "98f498e6cff18a9e470321448ebc7865b560ed4df2babf604ef9130aaf5acd52"; 
			Hasher hasher = new Hasher(SHA256.Create());

			// ACT
			string resultHash = hasher.Hash(testData, iterations);

			// ASSERT
			Assert.True(string.Equals(expectedHash, resultHash));
		}

		[Fact]
		public void Hasher_Using_Secret()
		{
			// ARRANGE
			const string input = "abcd";
			const string secret = "secret";   // secret is known as a Salt value
			const string inputHash = "88d4266fd4e6338d13b845fcf289579d209c897823b9217da3e161936f031589";
			const string secretHash = "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b";
			const string combinedHashInput = $"{inputHash}{secretHash}";			
			const string expectedHash = "24c2af3dde773931d71fdf67581028d76d5b3811e4b7b2f207ed76dc2f15dfed";			
			Hasher hasher = new Hasher(SHA256.Create());

			// ACT
			string resultHash = hasher.Hash(input, secret);

			// ASSERT
			//NOTE: To test properly you should independently generate a expected Hash since
			//		using the same algorithm by hand and use an online generator to generate expected hash.
					
			Assert.True(string.Equals(expectedHash, resultHash));
		
		}	
	}
}