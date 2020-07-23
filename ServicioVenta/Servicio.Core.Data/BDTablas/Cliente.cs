using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public int? Status { get; set; }
        public string Celular { get; set; }
        public string NombreFacebook { get; set; }
        public string DireccionLugarEntrega { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
