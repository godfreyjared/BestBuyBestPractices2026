using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BestBuyBestPractices2026
{
    public class DapperRepositoryClass : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperRepositoryClass(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingleOrDefault<Product>("SELECT * FROM products WHERE ProductID = @id;",
            new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products " +
                            "SET Name = @name, " +
                            "Price = @price, " +
                            "CategoryID = @catID, " +
                            "OnSale = @onSale, " +
                            "StockLevel = @stock " +
                            "WHERE ProductID = @id;",
                            new
                            {
                                id = product.productID,
                                name = product.Name,
                                price = product.Price,
                                catID = product.CategoryID,
                                onSale = product.OnSale,
                                stock = product.StockLevel
                            });

        }
    }
}
