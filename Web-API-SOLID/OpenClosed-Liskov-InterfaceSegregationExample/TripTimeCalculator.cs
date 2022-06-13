using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal class TripTimeCalculator
    {
        public double Calculate(double tripDistanceKm, double speed)
        {
            return tripDistanceKm / speed;
        }
    }
}
