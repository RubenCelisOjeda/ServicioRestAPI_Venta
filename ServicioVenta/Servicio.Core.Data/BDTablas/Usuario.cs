using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class Usuario
    {
        public Usuario()
        {
            ConceptoVenta = new HashSet<ConceptoVenta>();
        }

        public int Id { get; set; }
        public string UsuarioName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? RoId { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdEmpleado { get; set; }
        public int? Status { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<ConceptoVenta> ConceptoVenta { get; set; }
    }
}
