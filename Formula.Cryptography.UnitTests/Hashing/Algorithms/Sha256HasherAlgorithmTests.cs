using Formula.Cryptography.Hashing.Algorithms;
using Formula.Cryptography.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Formula.Cryptography.UnitTests.Hashing.Algorithms
{
    public class Sha256HasherAlgorithmTests : TestBase
    {
        [Fact]
        public void Sha256Algorithm_BasicUsage()
        {
            // ARRANGE
            // Test Data was generated from a known SHA265 online generator and its put in expectedHash
            const string testData = "abcd";
            byte[] testBytes = ByteUtils.StringToBytes(testData);
            const string expectedHash = "88D4266FD4E6338D13B845FCF289579D209C897823B9217DA3E161936F031589";
         
            // ACTION
            Sha256HasherAlgorithm sha = new Sha256HasherAlgorithm();
            byte[] resultBytes = sha.HashBytes(testBytes);
            string resultHash = ByteUtils.ToHashString(resultBytes);

            // ASSERT
            Assert.Equal(expectedHash, resultHash);
        }
    }
}
