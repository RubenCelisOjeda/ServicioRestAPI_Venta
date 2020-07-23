namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoUsuarioCombo
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoUsuarioCombo()
        {
            this.Id = 0;
            this.Usuario = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Usuario { get; set; }
    }
}
