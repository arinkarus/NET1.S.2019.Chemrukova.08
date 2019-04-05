using GCDAlgorithms;
using NUnit.Framework;
using System;

namespace GcdAlgoritms.Tests
{
    public class EuclidieanGcdTests
    {
        [Test]
        public void Calculate_TwoZeroesGiven_ThrowArgumentException() =>
           Assert.Throws<ArgumentException>(() =>
           {
               IGcdAlgorithm algorithm = new EuclideanGcdAlgorithm();
               algorithm.Calculate(0, 0);
           });

        [Test]
        public void Calculate_TwoIntegerMinValues_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IGcdAlgorithm algorithm = new EuclideanGcdAlgorithm();
                algorithm.Calculate(int.MinValue, int.MinValue);
            } );

        [TestCase(18, 48, ExpectedResult = 6)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(int.MinValue, 1, ExpectedResult = 1)]
        [TestCase(1, int.MinValue, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int Calculate_TwoIntegersGiven_ReturnGCD(int first, int second)
        {
            IGcdAlgorithm algorithm = new EuclideanGcdAlgorithm();
            return algorithm.Calculate(first, second);
        }
    }  
}
