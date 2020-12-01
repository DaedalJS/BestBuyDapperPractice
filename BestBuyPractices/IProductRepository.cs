using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);
    }
}
