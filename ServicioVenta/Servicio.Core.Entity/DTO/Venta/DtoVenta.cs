using System;
using System.Collections.Generic;

namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoVenta
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoVenta()
        {
            this.Id = 0;
            this.Total = 0.00m;
            this.Fecha = DateTime.UtcNow;
            this.ClienteId = 0;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ClienteId { get; set; }

        public IList<DtoConceptoVenta> DtoConceptoVenta { get; set; }
    }
}
