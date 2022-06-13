using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal class Plane : Vehicle, IFlying
    {
        public void Fly()
        {
            Console.WriteLine("Plane is flying");
        }

        public override double speedFactor()
        {
            return 10;
        }
    }
}
