using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyPractices
{
    class Program
    {
        static string YesOrNo()
        {
            string resp;
            do
            {
                resp = Console.ReadLine().ToLower();
                if (resp != "y" && resp != "n")
                {
                    Console.WriteLine("Please respond with Y/N.");
                }
            } while (resp != "y" && resp != "n");

            return resp;
        }



        static void Main(string[] args)
        {
            #region Config
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion

            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            DapperProductRepository prod = new DapperProductRepository(conn);

            Console.WriteLine("Current Departments:");
            var depos = repo.GetAllDepartments();
            var products = prod.GetAllProducts();

            foreach (var dept in depos)
            {
                Console.WriteLine($" ID: {dept.DepartmentID} Name: {dept.Name}");
            }

            Console.WriteLine("Would you like to add a department? Y/N ");
            string response;
            response = Program.YesOrNo();

            if (response == "y")
            {
                Console.WriteLine("What is the new department name?");
                response = Console.ReadLine();
                repo.InsertDepartment(response);
                repo.GetAllDepartments();
            }

            Console.WriteLine("Thanks for your input.");

            Console.WriteLine("would you like to see all products?");
            response = Program.YesOrNo();
            if (response == "y")
            {

                foreach (var item in products)
                {
                    if (item.OnSale == 1)
                    {
                        Console.WriteLine($"{item.ProductID}, {item.Name}, Category: {item.CategoryID}, Price: {item.Price}, Stock Total: {item.StockLevel} ON SALE!");
                    }
                    else
                    {
                        Console.WriteLine($"{item.ProductID}, {item.Name}, Category: {item.CategoryID}, Price: {item.Price}, Stock Total: {item.StockLevel}");
                    }
                }

            }

            Console.WriteLine("would you like to add a product?");
            response = Program.YesOrNo();
            if (response == "y")
            {
                Console.WriteLine("What is the Product's Name?");
                string prodName = Console.ReadLine();
                Console.WriteLine("What is the Product's Price?");
                double prodPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("What is the Product's Category ID Number?");
                int prodCatID = int.Parse(Console.ReadLine());

                prod.CreateProduct(prodName, prodPrice, prodCatID);


            }

            Console.WriteLine("Thanks for your input.");


        }
    }
}
