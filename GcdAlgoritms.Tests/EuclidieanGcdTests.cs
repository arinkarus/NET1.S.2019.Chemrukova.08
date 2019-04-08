using GCDAlgorithms;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace GcdAlgoritms.Tests
{
    public class EuclidieanGcdTests
    {
        [Test]
        public void Calculate_TwoZeroesGiven_ThrowArgumentException() =>
           Assert.Throws<ArgumentException>(() =>
           {
               var stopwatch = new Stopwatch();
               IGcdAlgorithm algorithm = new GcdAlgorithmWithTimePerformance(new EuclideanGcdAlgorithm(), new StopwatchAdapter(stopwatch));
               algorithm.Calculate(0, 0);
           });

        [Test]
        public void Calculate_TwoIntegerMinValues_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var stopwatch = new Stopwatch();
                IGcdAlgorithm algorithm = new GcdAlgorithmWithTimePerformance(new EuclideanGcdAlgorithm(), new StopwatchAdapter(stopwatch));
                algorithm.Calculate(int.MinValue, int.MinValue);
            } );

        [TestCase(18, 48, ExpectedResult = 6)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(int.MinValue, 1, ExpectedResult = 1)]
        [TestCase(1, int.MinValue, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Calculate_TwoIntegersGiven_ReturnGCD(int first, int second)
        {
            var stopwatch = new Stopwatch();
            IGcdAlgorithm algorithm = new GcdAlgorithmWithTimePerformance(new EuclideanGcdAlgorithm(), new StopwatchAdapter(stopwatch));
            return algorithm.Calculate(first, second);
        }
    }  
}
