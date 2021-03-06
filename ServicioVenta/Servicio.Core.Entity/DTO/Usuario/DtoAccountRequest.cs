﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Entity.DTO
{
    /// <summary>
    /// Entidad
    /// </summary>
    public class DtoAccountRequest
    {
        /// <summary>
        /// Contructor inicializa las propiedades
        /// </summary>
        public DtoAccountRequest()
        {
            this.Id = 0;
            this.Usuario = string.Empty;
            this.Email = string.Empty;
        }

        /// <summary>
        /// Propiedades
        /// </summary>
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
    }
}
