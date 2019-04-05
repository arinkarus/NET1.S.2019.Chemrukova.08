namespace GCDAlgorithms
{
    /// <summary>
    /// Determines method for calculation of gcd for two given numbers.
    /// </summary>
    public interface IGcdAlgorithm
    {
        /// <summary>
        /// Calculates gcd for two numbers.
        /// </summary>
        /// <param name="first">First given number.</param>
        /// <param name="second">Second given number.</param>
        /// <returns>Calculated value.</returns>
        int Calculate(int first, int second);
    }
}
