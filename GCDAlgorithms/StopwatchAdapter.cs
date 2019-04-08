using System.Diagnostics;

namespace GCDAlgorithms
{
    public class StopwatchAdapter : ITimeCalculator
    {
        private Stopwatch stopwatch;

        public StopwatchAdapter(Stopwatch stopwatch)
        {
            this.stopwatch = stopwatch;
        }

        public long TimeInMilliseconds => stopwatch.ElapsedMilliseconds;

        public void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
    }
}
