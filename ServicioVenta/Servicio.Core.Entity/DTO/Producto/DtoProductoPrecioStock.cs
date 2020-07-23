namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoProductoPrecioStock
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoProductoPrecioStock()
        {
            this.Precio = 0.00m;
            this.Stock = 0;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
    }
}
