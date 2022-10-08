using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP4.EF.Logic;
using TP4.EF.Entities;
using TP4.EF.MVC.Models;

namespace TP4.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shippersLogic = new ShippersLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            List<ShippersView> shippersViews = new List<ShippersView>();
            try
            {
                List<Shippers> shippers = shippersLogic.GetAll();
                shippersViews = shippers.Select(s => new ShippersView
                {
                    ShipperID = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone
                }).ToList();
                return View(shippersViews);
            }


            catch(Exception ex) 
            {
                string error = ex.Message.ToString();
                return RedirectToAction("Index", "Error", new { error });
            }
            
        }


        [HttpGet]
        public ActionResult InsertUpdate(ShippersView shippersView)
        {
             return View(shippersView);
        }
       
        [HttpPost]
        public ActionResult InsertUpdate(ShippersView shippersView, string insertUpdate)
        {
            if(shippersView.Modificar=="Mod")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                    Shippers shipperEntity = new Shippers
                    {
                        ShipperID=shippersView.ShipperID,
                        CompanyName = shippersView.CompanyName,
                        Phone = shippersView.Phone
                    };
                    shippersLogic.Update(shipperEntity);
                    return RedirectToAction("Index");
                    }
                }
                catch
                {
                    return RedirectToAction("Index", "Error");
                }
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Shippers shipperEntity = new Shippers
                        {
                            CompanyName = shippersView.CompanyName,
                            Phone = shippersView.Phone
                        };

                        shippersLogic.Add(shipperEntity);

                        return RedirectToAction("Index");

                    }
                }
                catch
                {
                    return RedirectToAction("Index", "Error");
                }

            }

            return View(shippersView);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                shippersLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (NullReferenceException)
            {
                return new HttpNotFoundResult();
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return RedirectToAction("Index", "Error", new { error });
            }
            
        }
    }
}