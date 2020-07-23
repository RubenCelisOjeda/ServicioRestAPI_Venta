using System;

namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoUsuarioGrilla
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoUsuarioGrilla()
        {
            this.Id = 0;
            this.UsuarioName = string.Empty;
            this.Password = string.Empty;
            this.Email = string.Empty;
            this.RolUsuario = string.Empty;
            this.Estado = string.Empty;
            this.FechaRegistro = DateTime.Now;
            this.Email = string.Empty;
            this.Empleado = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string UsuarioName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RolUsuario { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string Empleado { get; set; }
    }
}
