using Formula.Cryptography.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Formula.Cryptography.UnitTests.Utils
{
    public class EntropyUtilsTests
    {

        [Fact]
        public void GenerateBytes_Basic()
        {
            // ARRANGE
            var entropy = new EntropyUtils();
            int expectedSize = 255;

            // ACT
            byte[] chaos = entropy.GenerateBytes(255);

            // ASSERT
            Assert.Equal(expectedSize, chaos.Length);   
        }

        [Fact]
        public void GenerateBytes_Iterative()
        {
            // ARRANGE
            var entropy = new EntropyUtils();
            int expectedSize = 1;
            int iterations = 1000;
            int expectedSizeMinSize = 10;
            int expectedSizeMaxSize = 100; 
            byte[] bytesTest;

            // ACT
            for(int i = 0; i < iterations; i++)
            {
                bytesTest = entropy.GenerateBytes(expectedSize);

                // ASSERT
                Assert.Equal(expectedSize, bytesTest.Length);

                // Adjust data for next round
                var random = new Random(i);
                expectedSize = random.Next(expectedSizeMinSize, expectedSizeMaxSize);
            }

        }
    }
}
