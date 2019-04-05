using System;

namespace GCDAlgorithms
{
    /// <summary>
    /// Class for calculation of gcd.
    /// </summary>
    public class BinaryGcdAlgorithm : IGcdAlgorithm
    {
        /// <summary>
        /// Calculates gcd of two numbers using stein (binary) algorithm.
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
            int shift;
            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            uint a = (uint)first;
            uint b = (uint)second;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    uint t = b;
                    b = a;
                    a = t;
                }

                b = b - a;
            }
            while (b != 0);

            return (int)a << shift;
        }
    }
}
