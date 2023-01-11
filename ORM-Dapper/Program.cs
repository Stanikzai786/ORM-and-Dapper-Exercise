using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            #region Department
            var departmentRepo = new DapperDepartment(conn);
            departmentRepo.InsertDepartment("Fun Department");
            var allDepartments = departmentRepo.GetAllDepartments();
            foreach (Department item in allDepartments)
            {
                Console.WriteLine($"Department ID: {item.DepartmentID}");
                Console.WriteLine($"Department Name: {item.Name}");
            }

            #endregion

            #region product

            var productRepo = new DapperProductRepo(conn);
            productRepo.CreateProduct("IFun", 9.99, 10);
            var allProduct = productRepo.GetAllProducts();

            foreach (var item in allProduct)
            {
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"{item.Price}");
                Console.WriteLine($"{item.CategoryID}");
            }
        }
        #endregion

    }

}