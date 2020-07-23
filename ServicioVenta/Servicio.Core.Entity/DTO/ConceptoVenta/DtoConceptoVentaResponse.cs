namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoConceptoVentaResponse
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoConceptoVentaResponse()
        {
            this.Id = 0;
            this.ProductoId = 0;
            this.ClienteId = 0;
            this.PrecioUnitario = 0.00m;
            this.Cantidad = 0;
            this.Importe = 0.00m;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int? Id { get; set; }
        public int? ProductoId { get; set; }
        public int? ClienteId { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Importe { get; set; }
    }
}
