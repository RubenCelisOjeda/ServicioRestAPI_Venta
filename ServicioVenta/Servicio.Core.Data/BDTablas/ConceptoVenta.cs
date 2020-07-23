using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class ConceptoVenta
    {
        public int Id { get; set; }
        public int? VentaId { get; set; }
        public int? ProductoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Importe { get; set; }
        public int? Status { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
