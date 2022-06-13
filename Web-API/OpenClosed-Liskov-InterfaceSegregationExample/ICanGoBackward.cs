using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed_Liskov_InterfaceSegregationExample
{
    internal interface ICanGoBackward
    {
        public void Backward()
        {
            Console.WriteLine("Going backwards..");
        }
    }
}
