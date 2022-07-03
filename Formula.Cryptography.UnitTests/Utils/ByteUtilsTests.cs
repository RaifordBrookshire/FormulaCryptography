using Formula.Cryptography.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Xunit;

namespace Formula.Cryptography.UnitTests.Utils
{
    public class ByteUtilsTests
    {
        [Fact]
        public void CompareBytesTest()
        {
            // ARRANGE
            ///////////////////////////////////////////////
            const string testData = "abcd";
            byte[] testBytes1 = Encoding.UTF8.GetBytes(testData);
            byte[] testBytes2 = Encoding.UTF8.GetBytes(testData + "additional text");
            byte[] testBytes3 = Encoding.UTF8.GetBytes(testData);

            // ACT
            ///////////////////////////////////////////////
            bool equalityTestSuccess = ByteUtils.CompareBytes(testBytes1, testBytes3);
            bool equalityTestFail = ByteUtils.CompareBytes(testBytes1, testBytes2);

            // ASSERT
            ///////////////////////////////////////////////
            // Test 1 - Success
            Assert.True(equalityTestSuccess, "ByteUtils.CompareBytes() - success compare FAILED test");

            // Test 2 - Not Equal
            Assert.True(equalityTestFail, "ByteUtils.CompareBytes() - fail compare FAILED test");
        }

        [Fact]
        public void BytesToStringTest()
        {
            // ARRANGE
            const string testData = "abcd";
            byte[] testBytes = Encoding.UTF8.GetBytes(testData);

            // ACT
            string result = ByteUtils.BytesToString(testBytes); 

            // ASSERT
            Assert.True(string.Equals(result, testData));
        }     
    }
}
