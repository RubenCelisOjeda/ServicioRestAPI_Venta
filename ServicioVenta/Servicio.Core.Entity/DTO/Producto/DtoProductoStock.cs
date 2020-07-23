namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoProductoStock
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoProductoStock()
        {
            this.Id = 0;
            this.Stock = 0;
            this.Accion = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public int? Stock { get; set; }
        public string Accion { get; set; }
    }
}
