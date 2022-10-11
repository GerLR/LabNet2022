using System;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Entities;

namespace TP4.EF.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {
        public List<Shippers> GetAll()
        {
            try
            {
                return context.Shippers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Se ha encontrado la siguiente excepción del tipo {e.GetType()}: {e.Message}");
            }
        }

        public void Add(Shippers newShipper)
        {
            try
            {
                context.Shippers.Add(newShipper);
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
                Shippers shipperAEliminar = context.Shippers.Find(id);

                context.Shippers.Remove(shipperAEliminar);

                if (context.Orders.ToList().Count>0)
                {
                    foreach (Orders o in context.Orders.ToList())
                    {
                        if(o.ShipVia==id)
                        o.ShipVia = null;
                    }
                }
                 context.SaveChanges();
            }
            
            catch (ArgumentNullException )
            {
                throw new Exception ("No existe el shipper indicado");
            }
         
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public void Update(Shippers shipper)
        {
            try
            {
                Shippers shipperUpdate = context.Shippers.Find(shipper.ShipperID);
                shipperUpdate.CompanyName = shipper.CompanyName;
                shipperUpdate.Phone = shipper.Phone;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Shippers Busqueda(int id)
        {
            Shippers shipper = context.Shippers.Find(id);
            if (shipper == null)
            {
                throw new Exception("Id no encontrado");
            }
            return shipper;
        }
    }
}

