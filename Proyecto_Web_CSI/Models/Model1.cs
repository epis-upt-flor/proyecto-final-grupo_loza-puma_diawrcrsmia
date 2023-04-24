using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Proyecto_Web_CSI.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<detalle_objeto> detalle_objeto { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Estado_equipo> Estado_equipo { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Objetos> Objetos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tipo_objeto> Tipo_objeto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<detalle_objeto>()
                .Property(e => e.peso)
                .HasPrecision(18, 0);

            modelBuilder.Entity<detalle_objeto>()
                .Property(e => e.precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.documento)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.genero)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado_equipo>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_equipo>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estado_equipo>()
                .Property(e => e.error)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_equipo>()
                .HasMany(e => e.Historial)
                .WithRequired(e => e.Estado_equipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.error)
                .IsUnicode(false);

            modelBuilder.Entity<Historial>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Objetos>()
                .Property(e => e.peso_total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Objetos>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Objetos>()
                .HasMany(e => e.detalle_objeto)
                .WithRequired(e => e.Objetos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_objeto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_objeto>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_objeto>()
                .HasMany(e => e.Objetos)
                .WithRequired(e => e.Tipo_objeto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
