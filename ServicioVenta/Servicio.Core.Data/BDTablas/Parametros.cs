using System;
using System.Collections.Generic;

namespace Servicio.Core.Data.BDTablas
{
    public partial class Parametros
    {
        public int Id { get; set; }
        public int? NroGrupo { get; set; }
        public string Nombre { get; set; }
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public bool? Estado { get; set; }
    }
}
