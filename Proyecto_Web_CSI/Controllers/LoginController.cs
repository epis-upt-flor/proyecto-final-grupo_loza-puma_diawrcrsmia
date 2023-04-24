using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Proyecto_Web_CSI.Models;

namespace Proyecto_Web_CSI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CerrarSesion()
        {

            Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Index(string nombre, string clave)
        {
            Usuario objUsuario = new Usuario().autenticar(nombre, clave);
            if (objUsuario != null)
            {
                
                Session["Usuario"] = objUsuario;
                Session["nombre"] = objUsuario.usuario1.ToString();
                Session["idusuario"] = objUsuario.usuario_id;
                Session["id_empleado"] = objUsuario.empleado_id;
                Session["rol"] = objUsuario.Rol.descripcion;


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mesnaje"] = "Usuario incorrecto!";
                return View();
            }

        }
    }
}