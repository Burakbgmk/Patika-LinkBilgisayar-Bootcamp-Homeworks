using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal class Boat : Vehicle, IFloating
    {
        public void Float()
        {
            Console.WriteLine("Boat is floating in the sea");
        }

        public override double speedFactor()
        {
            return 1.5;
        }
    }
}
