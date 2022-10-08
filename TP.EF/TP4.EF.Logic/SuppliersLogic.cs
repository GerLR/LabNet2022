using System;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Entities;

namespace TP4.EF.Logic
{
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {      
        public List<Suppliers> GetAll()
        {
            try
            {
                return context.Suppliers.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public void Add(Suppliers newSuppliers)
        {
            try
            {
                context.Suppliers.Add(newSuppliers);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Delete(int id)
        {
            try
            {
                Suppliers supplierAEliminar = context.Suppliers.Find(id);
                context.Suppliers.Remove(supplierAEliminar);

                if (context.Products.ToList().Count>0)
                {
                    foreach (Products p in context.Products.ToList())
                    {
                        if(p.SupplierID==id)
                        p.SupplierID = null;
                    }
                }
                context.SaveChanges();
            }
         
            catch (ArgumentNullException)
            {
                throw new Exception("No existe el supplier indicado");
            }
            catch (Exception e)
            {
                throw  e;
            }

           

        }

        public void Update(Suppliers supplier)
        {
            try
            {
                Suppliers suppliersUpdate = context.Suppliers.Find(supplier.SupplierID);

                suppliersUpdate.CompanyName = supplier.CompanyName;
                suppliersUpdate.Phone = supplier.Phone;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public Suppliers Busqueda(int id)
        {
            Suppliers supplier = context.Suppliers.Find(id);
            if(supplier==null)
            {
                throw new Exception("Id no encontrado");
            }
            return supplier;
        }
    }
}
