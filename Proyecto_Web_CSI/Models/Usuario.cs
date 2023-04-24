namespace Proyecto_Web_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int empleado_id { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(50)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(100)]
        public string clave { get; set; }

        public int rol_id { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Rol Rol { get; set; }




        public List<Usuario> ListarTodo()
        {
            var usuarios = new List<Usuario>();

            try
            {
                using (var db = new Model1())
                {
                    usuarios = db.Usuario.Include("Rol").Include("Empleado").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public void Guardar()
        {
            using (var db = new Model1())
            {
                if (this.usuario_id > 0)
                {
                    db.Entry(this).State = EntityState.Modified;
                }
                else
                {
                    db.Entry(this).State = EntityState.Added;
                }
                db.SaveChanges();
            }
        }

        public void Eliminar()
        {


            try
            {
                using (var db = new Model1())
                {
                    if (this.usuario_id > 0)
                    {
                        db.Entry(this).State = EntityState.Deleted;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Habilitar()
        {

            try
            {
                using (var db = new Model1())
                {
                    if (this.usuario_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Usuario ObtenerUsuario(int id)
        {
            var usuario = new Usuario();

            try
            {
                using (var db = new Model1())
                {
                    usuario = db.Usuario.Include("Rol")
                        .Where(x => x.usuario_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }


        public Usuario autenticar(string nombre, string clave)
        {
            var objusuario = new Usuario();
            try
            {
                using (var db = new Model1())
                {
                    objusuario = db.Usuario.Include("Rol").Include("Empleado").Where(x => x.usuario1 == nombre && x.clave == clave).SingleOrDefault();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return objusuario;

        }


        public List<Usuario> ListarPerfil(string nombre)
        {
            var objusuario = new List<Usuario>();

            try
            {
                using (var db = new Model1())
                {
                    objusuario = db.Usuario.Include("Empleado").Where(x => x.usuario1 == nombre).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return objusuario;
        }




    }
}
