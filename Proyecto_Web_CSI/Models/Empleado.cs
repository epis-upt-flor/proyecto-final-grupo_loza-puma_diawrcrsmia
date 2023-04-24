namespace Proyecto_Web_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int empleado_id { get; set; }

        [Required]
        [StringLength(10)]
        public string documento { get; set; }

        [Required]
        [StringLength(150)]
        public string apellidos { get; set; }

        [Required]
        [StringLength(150)]
        public string nombres { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        [Required]
        [StringLength(9)]
        public string celular { get; set; }

        [Required]
        [StringLength(150)]
        public string direccion { get; set; }

        [Required]
        [StringLength(1)]
        public string genero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
