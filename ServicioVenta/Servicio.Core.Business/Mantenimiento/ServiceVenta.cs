using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceVenta : IServiceVenta
    {
        private readonly IDataVenta _IDataVenta;

        //inyeccion de dependencias
        public ServiceVenta(IDataVenta dataVenta)
        {
            _IDataVenta = dataVenta;
        }

        public IList<DtoVentaGrilla> Get()
        {
            return _IDataVenta.Get();
        }

        public IList<DtoVenta> Get(int pId)
        {
            return _IDataVenta.Get(pId);
        }

        public IList<DtoVentaGrilla> Get(string pValor)
        {
            return _IDataVenta.Get(pValor);
        }

        public DtoVenta Post(DtoVenta pEntidad)
        {
            return _IDataVenta.Post(pEntidad);
        }

        public bool Delete(int pId)
        {
            return _IDataVenta.Delete(pId);
        }

        public bool Existe(int pId)
        {
            return _IDataVenta.Existe(pId);
        }
    }
}
