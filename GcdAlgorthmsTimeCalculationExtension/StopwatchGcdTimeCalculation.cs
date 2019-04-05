using GCDAlgorithms;
using System.Diagnostics;

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
        public int CalculateGcdWithTime(out long time, int firstNumber, int secondNumber, IGcdAlgorithm gcdAlgorithm)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int gcd = gcdAlgorithm.Calculate(firstNumber, secondNumber);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            return gcd;
        }
    }
}
