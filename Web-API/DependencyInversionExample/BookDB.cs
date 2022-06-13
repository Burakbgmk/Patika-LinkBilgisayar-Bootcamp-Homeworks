using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionExample
{
    public class BookDB : IProductDB
    {
        public List<string> GetProductList()
        {
            return new List<string>() { "Harry Potter", "Foreigner", "Red Monday" };
        }
    }
}
