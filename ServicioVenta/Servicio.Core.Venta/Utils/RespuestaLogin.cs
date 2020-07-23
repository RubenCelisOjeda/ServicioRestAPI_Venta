﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Venta.Utils
{
    public class RespuestaLogin<T> where T : class, new()
    {
        public RespuestaLogin()
        {
            this.Dto = null;
            this.Mensaje = string.Empty;
            this.Count = 0;
        }

        public string Mensaje { get; set; }
        public int Count { get; set; }
        public T Dto { get; set; }
    }
}
