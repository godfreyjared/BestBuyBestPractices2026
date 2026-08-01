using BestBuyBestPractices2026;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

#region Department Section
//var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("Jared's New Department");


//var departments = departmentRepo.GetAllDepartments(); 

//foreach (var department in departments)
//{
//    Console.WriteLine($"Department ID: {department.DepartmentID}");
//    Console.WriteLine($"Name: {department.Name}");
//    Console.WriteLine();
//    Console.WriteLine();
//}
#endregion

var productRepository = new DapperRepositoryClass(conn);

var productToUpdate = productRepository.GetProduct(941);

productToUpdate.Name = "UPDATED!!!";
productToUpdate.Price = 12.99;
productToUpdate.CategoryID = 1;
productToUpdate.OnSale = false;
productToUpdate.StockLevel = 1000;

productRepository.UpdateProduct(productToUpdate);


var products = productRepository.GetAllProducts();

foreach (var product in products)
{ 

Console.WriteLine(product.productID);
Console.WriteLine(product.Name);
Console.WriteLine(product.Price);
Console.WriteLine(product.CategoryID);
Console.WriteLine(product.OnSale);
Console.WriteLine(product.StockLevel);
Console.WriteLine();
Console.WriteLine();
}