using System;

namespace GCDAlgorithms
{
    /// <summary>
    /// Static class for validation numbers given for gcd algorithms.
    /// </summary>
    public static class GcdValidationHelper
    {
        /// <summary>
        /// Checks numbers that are given for gcd algorithms.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <exception cref="ArgumentException">Thrown when two numbers are 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when two numbers
        /// are int.MinValue.
        /// </exception>
        public static void CheckNumbers(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException($"GCD cannot be calculated for both zero args: {nameof(a)} and {nameof(b)}");
            }

            if (a == int.MinValue && b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"GCD for {nameof(a)} and {nameof(b)} can't be calculated within integer range");
            }
        }
    }
}
