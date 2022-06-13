using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal class Car : Vehicle, IGrounded, ICanGoBackward
    {
        public void DrivingOnRoad()
        {
            Console.WriteLine("Car is going on the road");
        }

        public override double speedFactor()
        {
            return 2.5;
        }
    }
}
