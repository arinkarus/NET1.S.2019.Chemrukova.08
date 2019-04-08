using System;

namespace GCDAlgorithms
{
    /// <summary>
    /// Class for calculation of gcd.
    /// </summary>
    public class EuclideanGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Calculates gcd of two numbers using euclidiean algorithm.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Returns gcd.</returns>
        /// <exception cref="ArgumentException">Thrown if two numbers are 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when two numbers
        /// are int.MinValue.
        /// </exception>
        public int Calculate(int first, int second)
        {
            GcdValidationHelper.CheckNumbers(first, second);
            while (second != 0)
            {
                int temp = first % second;
                first = second;
                second = temp;
            }

            return first;
        }
    }
}
