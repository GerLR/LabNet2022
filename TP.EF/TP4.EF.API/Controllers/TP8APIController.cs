using System;
using System.Collections.Generic;
using System.Web.Http;
using TP4.EF.API.Models;
using TP4.EF.Entities;
using TP4.EF.Logic;

namespace TP4.EF.API.Controllers
{
    public class TP8APIController : ApiController
    {
        ShippersLogic shippersLogic = new ShippersLogic();

        public IHttpActionResult GetAllShippers()
        {
            try
            {
                List<Shippers> shippers = shippersLogic.GetAll();
                List<ShippersView> shippersView = new List<ShippersView>();

                foreach (Shippers s in shippers)
                {
                    shippersView.Add(new ShippersView
                    {
                        ShipperID = s.ShipperID,
                        CompanyName = s.CompanyName,
                        Phone = s.Phone
                    });
                }

                if (shippersView.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(shippersView);
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
         }

        public IHttpActionResult AddNewShipper(ShippersView shipper)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                shippersLogic.Add(new Shippers
                {
                    CompanyName = shipper.CompanyName,
                    Phone = shipper.Phone
                });
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }

        public IHttpActionResult DeleteShipper(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                shippersLogic.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }

        public IHttpActionResult PutShipper(ShippersView shipperView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            try
            {
                Shippers shipper = new Shippers
                {
                    ShipperID = shipperView.ShipperID,
                    CompanyName = shipperView.CompanyName,
                    Phone = shipperView.Phone
                };

                if (shippersLogic.Busqueda(shipper.ShipperID) == null)
                {
                    return NotFound();
                }
                else
                {
                    shippersLogic.Update(shipper);
                }
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

    }
}
