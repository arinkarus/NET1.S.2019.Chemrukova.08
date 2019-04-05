using GCDAlgorithms;

namespace GcdAlgorthmsTimeCalculationExtension
{
    /// <summary>
    /// Determines interface for calculation of time for some gcd algorithm.
    /// </summary>
    public interface IGcdTimeCalculation
    {
        /// <summary>
        /// Calculates time and gcd for two given numbers.
        /// </summary>
        /// <param name="time">Time of execution.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="gcdAlgorithm">Selected gcd algoritm.</param>
        /// <returns>Greatest common divider.</returns>
        int CalculateGcdWithTime(out long time, int firstNumber, int secondNumber, IGcdAlgorithm gcdAlgorithm);
    }
}
