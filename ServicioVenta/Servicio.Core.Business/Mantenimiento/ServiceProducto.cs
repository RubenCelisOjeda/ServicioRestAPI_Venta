using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceProducto : IServiceProducto
    {
        private readonly IDataProducto _IDataProducto;

        //inyeccion de dependencias
        public ServiceProducto(IDataProducto dataProducto)
        {
            _IDataProducto = dataProducto;
        }

        public IList<DtoProductoGrilla> Get()
        {
            return _IDataProducto.Get();
        }

        public IList<DtoProducto> Get(int pId)
        {
            return _IDataProducto.Get(pId);
        }

        public IList<DtoProductoPrecioStock> GetPrecioStock(int pId)
        {
            return _IDataProducto.GetPrecioStock(pId);
        }

        public IList<DtoProductoCombo> GetCombo()
        {
            return _IDataProducto.GetCombo();
        }

        public IList<DtoProductoGrilla> Get(string pValor)
        {
            return _IDataProducto.Get(pValor);
        }

        public bool Post(DtoProducto pEntidad)
        {
            return _IDataProducto.Post(pEntidad);
        }

        public bool PutStock(DtoProductoStock pEntidad)
        {
            return _IDataProducto.PutStock(pEntidad);
        }

        public bool Delete(int pId)
        {
            return _IDataProducto.Delete(pId);
        }
        public bool Existe(int pId)
        {
            return _IDataProducto.Existe(pId);
        }
    }
}
