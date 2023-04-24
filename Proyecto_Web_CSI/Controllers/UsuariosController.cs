using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Web_CSI.Models;

namespace Proyecto_Web_CSI.Controllers
{
    public class UsuariosController : Controller
    {
        Usuario objUsuario = new Usuario();
        Empleado objEmpleado = new Empleado();
        Rol objRol = new Rol();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(objUsuario.ListarTodo());
        }
        public ActionResult Usuario()
        {
            return View(objUsuario.ListarTodo());
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0
                ? new Usuario()
                : objUsuario.ObtenerUsuario(id)
                );

        }

        public ActionResult Guardar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Guardar();
                return Redirect("~/Usuarios/Index");
            }
            else
            {
                return View("~/Usuarios/Index");
            }
        }

        public ActionResult Edituser(int id = 0)
        {
            return View(id == 0 ? new Usuario() : objUsuario.ObtenerUsuario(id));
        }

        public ActionResult Eliminar(int id)
        {
            objUsuario.usuario_id = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario/Usuario");
        }

        public ActionResult Habilitar(int id)
        {
            objUsuario.usuario_id = id;
            objUsuario.Habilitar();
            return Redirect("~/Usuario/Usuario");
        }

        public ActionResult Buscar_Perfil()
        {
            string nombres = Session["nombre"].ToString();
            return View(objUsuario.ListarPerfil(nombres));
        }


    }
}