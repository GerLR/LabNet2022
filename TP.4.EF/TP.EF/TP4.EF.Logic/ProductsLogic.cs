using System;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Entities;

namespace TP4.EF.Logic
{
    class ProductsLogic : BaseLogic

    {
        public List<Products> Busqueda(int idSupplier)
        {
            List<Products> products = context.Products.ToList();
            List<Products> productosConCoincidencia = new List<Products>();
            try
            {
                foreach (Products p in products)
                {
                    if (p.SupplierID == idSupplier)
                        productosConCoincidencia.Add(p);
                }
            }
            catch
            {
                throw new Exception("Id del shipper no encontrado");
            }
            return productosConCoincidencia;

        }

    }
}
