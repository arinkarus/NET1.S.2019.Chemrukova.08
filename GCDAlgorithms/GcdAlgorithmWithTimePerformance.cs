namespace GCDAlgorithms
{
    /// <summary>
    /// Extends basic gcd algorithm with the opportunity to count time
    /// for algorithm's method execution. Implemented with decorator pattern.
    /// </summary>
    public class GcdAlgorithmWithTimePerformance: IGcdAlgorithm
    {
        /// <summary>
        /// Selected gcd algorithm which functionality has to be extended.
        /// </summary>
        private readonly IGcdAlgorithm algorithm;
        
        /// <summary>
        /// Stores instance of some util to calculate time of algorithm's execution.
        /// </summary>
        private readonly ITimeCalculator timeCalculator;

        /// <summary>
        /// Time of method's execution.
        /// </summary>
        public long Milliseconds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GcdAlgorithmWithTimePerformance"/> class.
        /// </summary>
        /// <param name="algorithm">Selected gcd algorithm.</param>
        /// <param name="timeCalculator">Util for calculating time.</param>
        public GcdAlgorithmWithTimePerformance(IGcdAlgorithm algorithm, ITimeCalculator timeCalculator)
        {
            algorithm.CheckOnNull();
            timeCalculator.CheckOnNull();
            this.timeCalculator = timeCalculator;
            this.algorithm = algorithm;
        }

        /// <summary>
        /// Calculates gcd of two number and time of execution of calculations.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Calculated gcd.</returns>
        public int Calculate(int first, int second)
        {
            timeCalculator.Start();
            int gcd = this.algorithm.Calculate(first, second);
            timeCalculator.Stop();
            this.Milliseconds = this.timeCalculator.TimeInMilliseconds;
            return gcd;
        }
    }

    /// <summary>
    /// Static class that provides methods for expending gcd algorithm's functionality.
    /// </summary>
    public static class GcdAlgortithmWithTimePerformanceStatic
    {
        /// <summary>
        /// Calculates gcd and time of algorithm's execution.
        /// </summary>
        /// <param name="gcdAlgorithm">Gcd algorithm.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="timeCalculator">Util for time calculation.</param>
        /// <param name="timeForCalculations">Result time of algorithm's execution.</param>
        /// <returns></returns>
        public static int CalculateGcdWithTime(this IGcdAlgorithm gcdAlgorithm, int first, int second, 
            ITimeCalculator timeCalculator, out long timeForCalculations)
        {
            gcdAlgorithm.CheckOnNull();
            timeCalculator.CheckOnNull();
            timeCalculator.Start();
            int gcd = gcdAlgorithm.Calculate(first, second);
            timeCalculator.Stop();
            timeForCalculations = timeCalculator.TimeInMilliseconds;
            return gcd;
        }
    }
}
