

using Formula.Cryptography.Hashing;
using Formula.Cryptography.Hashing.Algorithms;
using System;
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
            const string expectedHash = "88D4266FD4E6338D13B845FCF289579D209C897823B9217DA3E161936F031589";
            Hasher hasher = new Hasher();

            // ACT
            string resultHash = hasher.Hash(testData);

            // ASSERT
            Assert.True(string.Equals(expectedHash, resultHash));   
        }

        // Add a test to hash various sizes of input
        // Add static method to set default HashAlgorithm
        // Hasher.DefaultAlgorithm = new Sha256HasherAlgorithm();


    }
}
