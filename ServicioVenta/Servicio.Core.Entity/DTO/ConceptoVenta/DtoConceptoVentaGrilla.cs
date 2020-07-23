using System;

namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoConceptoVentaGrilla
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoConceptoVentaGrilla()
        {
            this.Id = 0;
            this.Producto = string.Empty;
            this.Cantidad = 0;
            this.PrecioUnitario = 0.00m;
            this.Importe = 0.00m;
            this.TotalVenta = 0.00m;
            this.FechaVenta = DateTime.Now;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Producto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Importe { get; set; }
        public decimal? TotalVenta { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
