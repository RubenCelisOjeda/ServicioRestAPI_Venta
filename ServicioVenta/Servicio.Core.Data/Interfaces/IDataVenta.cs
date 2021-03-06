﻿using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataVenta
    {
        IList<DtoVentaGrilla> Get();
        IList<DtoVenta> Get(int pId);
        IList<DtoVentaGrilla> Get(string pValor);
        DtoVenta Post(DtoVenta pEntidad);
        bool Delete(int pId);
        bool Existe(int pId);
    }
}
