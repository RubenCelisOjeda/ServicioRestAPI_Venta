using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Venta.Utils
{
    public class Constantes
    {
        public enum CodigoResultados
        {
            Correcto = 0,
            Error = 1
        }

        public static string CadenaDeConexion { get; set; }

        public enum CodigoCultura
        {
            Peru_es_PE = 0,
            UnitedStates_es_US = 1,
            UnitedStates_en_US = 2
        }
    }
}
