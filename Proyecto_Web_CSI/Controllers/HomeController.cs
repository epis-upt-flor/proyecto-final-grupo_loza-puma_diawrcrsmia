using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto_Web_CSI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}