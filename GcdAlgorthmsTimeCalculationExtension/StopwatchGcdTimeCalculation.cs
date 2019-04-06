using GCDAlgorithms;
using System.Diagnostics;
using System;

namespace GcdAlgorthmsTimeCalculationExtension
{
    /// <summary>
    /// Calculates time of execution of method that calculates gcd and gcd for two numbers.
    /// </summary>
    public class StopwatchGcdTimeCalculation : IGcdTimeCalculation
    {
        /// <summary>
        /// Calculates time and gcd for two given numbers using an instance of Stopwatch
        /// class.
        /// </summary>
        /// <param name="time">Time of execution.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="gcdAlgorithm">Selected gcd algoritm.</param>
        /// <returns>Greatest common divider.</returns>
        /// <exception cref="ArgumentNullException">Thrown when gcdAlgorithm is null.</exception>
        /// <exception cref="ArgumentException">Thrown when two given numbers are zeroes.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when two numbers are int.MinValue</exception>
        public int CalculateGcdWithTime(out long time, int firstNumber, int secondNumber, IGcdAlgorithm gcdAlgorithm)
        {
            GcdValidationHelper.CheckOnNull(gcdAlgorithm);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = gcdAlgorithm.Calculate(firstNumber, secondNumber);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }
    }
}
