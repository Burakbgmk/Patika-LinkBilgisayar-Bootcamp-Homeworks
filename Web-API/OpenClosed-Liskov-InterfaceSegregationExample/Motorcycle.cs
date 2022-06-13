using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal class Motorcycle : Vehicle, IGroundedRidable
    {
        public void RidingOnRoad()
        {
            Console.WriteLine("Motorcycle is going on road..");
        }

        public override double speedFactor()
        {
            return 2;
        }
    }
}
