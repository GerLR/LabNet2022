using Practica_LINQ.Data;
using Practica_LINQ.Entities;
using Practica_LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Practica_LINQ.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var db = new NorthwindContext();

            Console.WriteLine("1.Query para devolver objeto customer");
            Console.WriteLine();
            var Query1 = from customer in db.Customers
                         select customer;

            foreach (var item in Query1)
            {
                Console.WriteLine($"{item.CustomerID}---{ item.CompanyName}---{item.CompanyName}");
            }
            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();
            Console.WriteLine("2. Query para devolver todos los productos sin stock");
            Console.WriteLine();
            var Query2= from productos in db.Products
                        where productos.UnitsInStock == 0
                        select productos;

            foreach (var item in Query2)
            {
                Console.WriteLine($"{item.ProductID}---{item.ProductName}---{item.UnitsInStock}");
            }
            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();
            Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            Console.WriteLine();
            var Query3= db.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);

            foreach (var item in Query3)
            {
                Console.WriteLine($"{item.ProductID}---{item.ProductName}---{item.UnitsInStock}---{item.UnitPrice}");
            }
            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("4. Query para devolver todos los customers de Washington");
            Console.WriteLine();
            var Query4= db.Customers.Where(c => c.Region == "WA");

            foreach (var item in Query4)
            {
                Console.WriteLine($"{item.CustomerID}---{ item.Region}");
            }
            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine();
            var Query5= db.Products.Where(p => p.ProductID == 789).FirstOrDefault();

            if (Query5 != null)
            {
                Console.WriteLine($"{Query5.ProductID}---{Query5.ProductName}");
            }
            else
                Console.WriteLine("El ProductID no se encuentra en la base de datos");
            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
            List<Customers> lista = db.Customers.ToList();
            var Query6a = lista.Select(p => new Customers
            {
                CustomerID= p.CustomerID,
                ContactName = p.ContactName.ToLower(),
                CompanyName= p.CompanyName
            })
                         .ToList();

            foreach (var item in Query6a)
            {
                Console.WriteLine($"{item.CustomerID}---{ item.ContactName}---{item.CompanyName}");
            }
            Console.WriteLine();
            Console.WriteLine();

            var Query6b = lista.Select(p => new Customers
            {
                CustomerID = p.CustomerID,
                ContactName = p.ContactName.ToUpper(),
                CompanyName = p.CompanyName
            })
                         .ToList();

            foreach (var item in Query6b)
            {
                Console.WriteLine($"{item.CustomerID}---{ item.ContactName}---{item.CompanyName}");
            }
            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de Washington\n" +
                "y la fecha de orden sea mayor a 1 / 1 / 1997.");
            Console.WriteLine();
            DateTime fecha = DateTime.Parse("1/1/1997");
            var Query7= from customer in db.Customers
                        join orders in db.Orders
                        on new { customer.CustomerID }
                        equals new { CustomerID = orders.CustomerID }
                        where customer.Region == "WA" && orders.OrderDate > fecha
                        select new
                        {
                            customer.CustomerID,
                            orders.OrderDate
                        };
            foreach (var item in Query7)
            {
                Console.WriteLine($"{item.CustomerID}---{ item.OrderDate}");
            }


            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("8. Query para devolver los primeros 3 Customers de Washington");
            Console.WriteLine();
            var Query8 = (from customer in db.Customers
                          where customer.Region == "WA"
                          select customer).Take(3);

            foreach (var item in Query8)
            {
                Console.WriteLine($"{item.CustomerID}---{ item.Region}");
            }

            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("9. Query para devolver lista de productos ordenados por nombre");
            Console.WriteLine();

            var Query9= db.Products.OrderBy(p => p.ProductName);

            foreach (var item in Query9)
            {
                Console.WriteLine($"{item.ProductID}---{item.ProductName}");
            }

            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine();

            var Query10 = db.Products.OrderByDescending(p => p.UnitsInStock);

            foreach (var item in Query10)
            {
                Console.WriteLine($"{item.ProductID}---{item.ProductName}---{item.UnitsInStock}");
            }

            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("11. Query para devolver las distintas categorías asociadas a los productos");
            Console.WriteLine();

            var Query11 = db.Products.Join(db.Categories,
                sc => sc.CategoryID,
                soc => soc.CategoryID,
                (sc, soc) => new
                {
                    sc.ProductID,
                    sc.ProductName,
                    soc.CategoryName
                }).Distinct();                  
            

            foreach (var item in Query11)
            {
                Console.WriteLine($"{item.ProductID}---{item.ProductName}---{item.CategoryName}");
            }

            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("12. Query para devolver el primer elemento de una lista de productos");
            Console.WriteLine();


            var Query12 = (from products in db.Products

                         select products).First();

            Console.WriteLine($"{Query12.ProductID}---{Query12.ProductName}");

            Console.WriteLine("---------------Presione enter para proxima query-----------------");
            Console.ReadLine();

            Console.WriteLine("13. Query para devolver los customer con la cantidad de ordenes asociadas");
            Console.WriteLine();

            var Query13 = from p in db.Orders.GroupBy(p => p.CustomerID)
                        select new
                        {
                            count = p.Count(),
                            p.FirstOrDefault().CustomerID,
                        };
                        
            foreach (var item in Query13)
            {
                Console.WriteLine($"{item.CustomerID}--{item.count}");
            }

            Console.WriteLine("---------------Presione enter para terminar-----------------");
            Console.ReadLine();
        }
    }
}
