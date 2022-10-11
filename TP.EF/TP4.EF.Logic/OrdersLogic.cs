using System;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Entities;

namespace TP4.EF.Logic
{
    public class OrdersLogic :BaseLogic
    {
           public List<Orders> Busqueda(int idShipper)
        {
            List<Orders> orders = context.Orders.ToList();
            List<Orders> ordenesConCoincidencia = new List<Orders>();
            try
            {
                foreach(Orders o in orders)

                {
                    if (o.ShipVia == idShipper)
                    ordenesConCoincidencia.Add(o);
                }
            }
            catch
            {
                throw new Exception("Id del shipper no encontrado");
            }
            return ordenesConCoincidencia;
        }

    }
}
