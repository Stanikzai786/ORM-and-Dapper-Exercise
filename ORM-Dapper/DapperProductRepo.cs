using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class DapperProductRepo : IProductRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepo(IDbConnection connection)
        { 
            _connection = connection; 
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO product (Name, price, CategoryID) VALUES (@name, @price, @categoryID);",
             new { name = name, price = price, categoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Departments;");
        }
    }
}
