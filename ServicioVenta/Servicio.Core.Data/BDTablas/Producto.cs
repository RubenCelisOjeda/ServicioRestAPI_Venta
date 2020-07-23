using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class Producto
    {
        public Producto()
        {
            ConceptoVenta = new HashSet<ConceptoVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Costo { get; set; }
        public int? Stock { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<ConceptoVenta> ConceptoVenta { get; set; }
    }
}
