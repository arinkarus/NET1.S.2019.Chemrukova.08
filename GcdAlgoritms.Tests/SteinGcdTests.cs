using GCDAlgorithms;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace GcdAlgoritms.Tests
{
    public class SteinGcdTests
    {
        [Test]
        public void Calculate_TwoZeroesGiven_ThrowArgumentException() =>
           Assert.Throws<ArgumentException>(() =>
           {
               var stopwatch = new Stopwatch();
               IGcdAlgorithm gcdAlgorithm = new BinaryGcdAlgorithm();
               gcdAlgorithm.CalculateGcdWithTime(0, 0, new StopwatchAdapter(stopwatch), out _);
           }
           );      

        [Test]
        public void Calculate_TwoIntegerMinValues_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var stopwatch = new Stopwatch();
                IGcdAlgorithm gcdAlgorithm = new BinaryGcdAlgorithm();
                gcdAlgorithm.CalculateGcdWithTime(int.MinValue, int.MinValue, new StopwatchAdapter(stopwatch), out _);
            }
           );

        [TestCase(18, 48, ExpectedResult = 6)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(int.MinValue, 1, ExpectedResult = 1)]
        [TestCase(1, int.MinValue, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Calculate_TwoIntegersGiven_ReturnGCD(int first, int second)
        {
            var stopwatch = new Stopwatch();
            IGcdAlgorithm gcdAlgorithm = new BinaryGcdAlgorithm();
            return gcdAlgorithm.CalculateGcdWithTime(first, second, new StopwatchAdapter(stopwatch), out _);
        }
    }
}
