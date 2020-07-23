namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoLoginResponse
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoLoginResponse()
        {
            this.Id = 0;
            this.Usuario = string.Empty;
            this.Rol = string.Empty;
            this.Status = string.Empty;
            this.Email = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
    }
}
