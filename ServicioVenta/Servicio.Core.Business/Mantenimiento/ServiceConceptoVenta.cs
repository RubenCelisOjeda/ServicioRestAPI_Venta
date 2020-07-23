using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceConceptoVenta : IServiceConceptoVenta
    {
        private readonly IDataConceptoVenta _IConceptoVenta = null;

        //inyeccion de dependencias
        public ServiceConceptoVenta(IDataConceptoVenta conceptoVenta = null)
        {
            _IConceptoVenta = conceptoVenta;
        }

        public IList<DtoConceptoVentaGrilla> Get()
        {
            return _IConceptoVenta.Get();
        }

        public IList<DtoConceptoVentaResponse> Get(int pId = 0)
        {
            return _IConceptoVenta.Get(pId);
        }

        public IList<DtoConceptoVentaDetails> GetAllByVentaId(int pId = 0)
        {
            return _IConceptoVenta.GetAllByVentaId(pId);
        }

        public IList<DtoConceptoVentaGrilla> Get(string pValor = "%")
        {
            return _IConceptoVenta.Get(pValor);
        }

        public bool Post(DtoConceptoVenta pEntidad = null)
        {
            return _IConceptoVenta.Post(pEntidad);
        }

        public bool Delete(int pId = 0)
        {
            return _IConceptoVenta.Delete(pId);
        }
        public bool Existe(int pId = 0)
        {
            return _IConceptoVenta.Existe(pId);
        }
    }
}
