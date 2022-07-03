using Formula.Cryptography.Hashing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Formula.Cryptography.Utils
{
    public class EntropyUtils
    {
        /// <summary>
        /// Generates random entropy byte array based on the parameters passed it.
        /// </summary>
        /// <param name="size">the size of bytes you want to generate</param>
        /// <param name="paranoid">if you need extra efficiently set this to false to bypass the hardware based data</param>
        /// <returns>Returns a beautifully crafted random byte array that is truely unique.</returns>
        public byte[] GenerateBytes(int size = 256, bool paranoid = true)
        {
            Hasher hasher512 = new Hasher(SHA512.Create());
            StringBuilder paranoidBuffer = new StringBuilder();
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();


            // Provide some simple entropy for faster but still very strong entropy
            paranoidBuffer.Append(Environment.MachineName);
            paranoidBuffer.Append(Environment.TickCount);
            paranoidBuffer.Append(Environment.CurrentManagedThreadId);

            // Provide more entropy if 'paranoid' for less efficient but rediculously strong entropy
            if (paranoid)
            {
                // Process information
                Process proc = Process.GetCurrentProcess();
                paranoidBuffer.Append(proc.Id);
                paranoidBuffer.Append(proc.MachineName);
                paranoidBuffer.Append(proc.PeakVirtualMemorySize64);
                paranoidBuffer.Append(proc.PrivateMemorySize64);
                paranoidBuffer.Append(proc.StartTime.Ticks);
                paranoidBuffer.Append(proc.TotalProcessorTime);
                paranoidBuffer.Append(proc.WorkingSet64);

                // Network Card
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                var stats = properties.GetTcpIPv4Statistics();
                paranoidBuffer.Append(stats.SegmentsSent);
                paranoidBuffer.Append(stats.MaximumTransmissionTimeout);
            }

            // Hash the ParanoidBuffer back to bytes
            byte[] paranoidBytes = ByteUtils.StringToBytes(hasher512.Hash(paranoidBuffer.ToString()));

            // Fill with Crypto Random Bytes
            byte[] byteBuffer = new byte[size];
            random.GetBytes(byteBuffer);

            // Prepend the paranoid buffer
            byteBuffer = ByteUtils.Combine(paranoidBytes, byteBuffer);

            // trim the size and return 
            return byteBuffer.Take(size).ToArray();
        }
    }
}
