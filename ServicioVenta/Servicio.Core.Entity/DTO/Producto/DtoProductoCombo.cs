namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoProductoCombo
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoProductoCombo()
        {
            this.Id = 0;
            this.Producto = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Producto { get; set; }
    }
}
