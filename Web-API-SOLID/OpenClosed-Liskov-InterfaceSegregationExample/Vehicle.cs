using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    public abstract class Vehicle
    {
        public int Speed { get; set; } = 10;
        public abstract double speedFactor();
        public void Start()
        {
            Console.WriteLine("Started..");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped..");
        }
        public void Forward()
        {
            Console.WriteLine("Going forwards..");
        }
        
    }
}
