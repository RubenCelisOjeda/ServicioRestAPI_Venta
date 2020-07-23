using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class Empleado
    {
        public Empleado()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
