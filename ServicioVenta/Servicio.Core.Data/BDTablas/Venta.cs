using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class Venta
    {
        public Venta()
        {
            ConceptoVenta = new HashSet<ConceptoVenta>();
        }

        public int Id { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ClienteId { get; set; }
        public int? Status { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ConceptoVenta> ConceptoVenta { get; set; }
    }
}
