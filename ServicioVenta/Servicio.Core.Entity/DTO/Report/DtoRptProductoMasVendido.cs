using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Entity.DTO.Report
{
    public class DtoRptProductoMasVendido
    {
        public DtoRptProductoMasVendido()
        {
            this.Id = 0;
            this.Producto = string.Empty;
            this.TotalCantidad = 0;
        }

        public int? Id { get;set; }
        public string Producto { get; set; }
        public int? TotalCantidad { get; set; }
    }
}
