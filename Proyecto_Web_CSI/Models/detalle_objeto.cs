namespace Proyecto_Web_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class detalle_objeto
    {
        [Key]
        public int detalle_id { get; set; }

        public int objeto_id { get; set; }

        public DateTime? fecha { get; set; }

        public int cantidad { get; set; }

        public decimal peso { get; set; }

        public decimal precio { get; set; }

        public virtual Objetos Objetos { get; set; }
    }
}
