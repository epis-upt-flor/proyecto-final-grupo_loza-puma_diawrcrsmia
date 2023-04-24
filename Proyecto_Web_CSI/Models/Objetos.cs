namespace Proyecto_Web_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Objetos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Objetos()
        {
            detalle_objeto = new HashSet<detalle_objeto>();
        }

        [Key]
        public int objeto_id { get; set; }

        public int tipo_id { get; set; }

        public int cantidad_total { get; set; }

        public decimal peso_total { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_objeto> detalle_objeto { get; set; }

        public virtual Tipo_objeto Tipo_objeto { get; set; }
    }
}
