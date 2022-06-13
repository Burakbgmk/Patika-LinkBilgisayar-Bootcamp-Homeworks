using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionExample
{
    internal interface IProductDB
    {
        List<string> GetProductList();
    }
}
