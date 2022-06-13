using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionExample
{

    internal class ProductService
    {
        private readonly IProductDB _productDB;

        public ProductService(IProductDB productDB)
        {
            _productDB = productDB;
        }

        public List<string> GetProducts()
        {
            return _productDB.GetProductList();
        }
    }
}
