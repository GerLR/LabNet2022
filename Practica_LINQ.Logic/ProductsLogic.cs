using Practica_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_LINQ.Logic
{
    public class ProductsLogic:BaseLogic
    {
        public List<Products>SinStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }
        public List<Products> ConStock3()
        {
            return context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice >3).ToList();
            
        }
        public List<Products> SinStock2()
        {

            var Query = from productos in context.Products
                        where productos.UnitsInStock == 0
                        select productos;

            return Query.ToList();

        }        

        public List<Products> OrderName()
        {
            return context.Products.OrderBy(p => p.ProductName).ToList();

        }
        public List<Products> OrderUnitDesc()
        {
            return context.Products.OrderByDescending(p => p.UnitsInStock).ToList();

        }

        
        public List<Products> PrimerElemento()
        {
            var Query = (from products in context.Products
                         
                         select products).Take(1);

            return Query.ToList();
        }
    }
}
