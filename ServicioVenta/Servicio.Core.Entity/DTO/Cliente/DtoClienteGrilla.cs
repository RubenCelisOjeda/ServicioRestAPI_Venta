namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoClienteGrilla
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoClienteGrilla()
        {
            this.Id = 0;
            this.Nombres = string.Empty;
            this.ApellidoPaterno = string.Empty;
            this.ApellidoPaterno = string.Empty;
            this.Dni = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
    }
}
