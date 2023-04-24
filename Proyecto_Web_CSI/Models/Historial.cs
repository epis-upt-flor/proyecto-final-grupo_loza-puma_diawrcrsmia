namespace Proyecto_Web_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historial")]
    public partial class Historial
    {
        [Key]
        public int historial_id { get; set; }

        public int estado_id { get; set; }

        public DateTime? fecha { get; set; }

        [Required]
        [StringLength(100)]
        public string error { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Estado_equipo Estado_equipo { get; set; }
    }
}
