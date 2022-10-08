using System;
using System.Web.Mvc;
using TP4.EF.MVC.Models;

namespace TP4.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string error)
        {
            ErrorView errorView = new ErrorView();
            errorView.listadoDeErrores.Add(error);
            return View(errorView);
        }
    }
}