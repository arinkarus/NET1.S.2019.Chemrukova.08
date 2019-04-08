using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDAlgorithms
{
    public interface ITimeCalculator
    {
        void Start();

        void Stop();

        long TimeInMilliseconds { get; }
    }
}
