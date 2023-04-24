namespace Proyecto_Web_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_objeto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_objeto()
        {
            Objetos = new HashSet<Objetos>();
        }

        [Key]
        public int tipo_id { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objetos> Objetos { get; set; }
    }
}
