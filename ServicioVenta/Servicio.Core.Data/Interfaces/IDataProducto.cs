using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataProducto
    {
        IList<DtoProductoGrilla> Get();
        IList<DtoProductoCombo> GetCombo();
        IList<DtoProducto> Get(int pId);
        IList<DtoProductoPrecioStock> GetPrecioStock(int pId);
        IList<DtoProductoGrilla> Get(string pValor);
        bool Post(DtoProducto pEntidad);
        bool PutStock(DtoProductoStock pEntidad);
        bool Delete(int pId);
        bool Existe(int pId);
    }
}
