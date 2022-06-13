using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal class SpeedCalculator
    {
        public double Calculate(Vehicle vehicle)
        {
            return vehicle.Speed * vehicle.speedFactor();
        }
    }
}
