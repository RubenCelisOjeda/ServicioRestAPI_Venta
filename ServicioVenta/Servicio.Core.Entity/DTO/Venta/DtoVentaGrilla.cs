using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoVentaGrilla
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoVentaGrilla()
        {
            this.Id = 0;
            this.Total = 0.00m;
            this.Fecha = string.Empty;
            this.Cliente = string.Empty;
            this.Empleado = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public decimal? Total { get; set; }
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
    }
}
