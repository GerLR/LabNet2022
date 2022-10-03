using Practica_LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_LINQ.Logic
{
    public class CustomerLogic:BaseLogic
    {
        public List<Customers> CustomerWA()
        {
            return context.Customers.Where(c => c.Region == "WA").ToList();
        }

        public List<Customers> CustomerWA2()
        {
            var Query = from customer in context.Customers
                        where customer.Region == "WA"
                        select customer;

            return Query.ToList();
        }
        
       
        public List<Customers> NombresMayuscula()
        {
            List<Customers> lista = context.Customers.ToList();
            var updatedItems = lista.Select(p => new Customers
            {
                ContactName = p.ContactName.ToUpper(),

                
            })
                         .ToList();


            return updatedItems;
        }
        public List<Customers> NombresMinuscula()
        {
            List<Customers> lista = context.Customers.ToList();
            var updatedItems = lista.Select(p => new Customers
            {
                ContactName = p.ContactName.ToLower(),


            })
                         .ToList();


            return updatedItems;
        }

        
        public List<Customers> CustomerWA3()
        {
            var Query = (from customer in context.Customers
                        where customer.Region == "WA"
                        select customer).Take(3);

            return Query.ToList();
        }

        public List<Customers> CustomerOrder()
        {
            return context.Customers.Where(c => c.Region == "WA").ToList();
        }

    }
}
