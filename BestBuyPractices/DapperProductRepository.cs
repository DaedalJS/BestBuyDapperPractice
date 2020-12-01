using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var prods = _connection.Query<Product>("SELECT * FROM products");
            return prods;

        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);", new { name = name, price = price, categoryID = categoryID });
        }

      
    }
}
