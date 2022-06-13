using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionExample
{
    internal class MovieDB : IProductDB
    {

        public List<string> GetProductList()
        {
            return new List<string>() { "Interstellar", "Pulp Fiction", "Avengers" };
        }
    }
}
