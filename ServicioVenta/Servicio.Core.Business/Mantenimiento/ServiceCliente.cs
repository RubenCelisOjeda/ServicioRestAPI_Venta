using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System.Collections.Generic;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IDataCliente _IDataCliente;

        //inyeccion de dependencias
        public ServiceCliente(IDataCliente dataCliente)
        {
            _IDataCliente = dataCliente;
        }

        public IList<DtoClienteGrilla> Get()
        {
            return _IDataCliente.Get();
        }

        public IList<DtoClienteCombo> GetCombo()
        {
            return _IDataCliente.GetCombo();
        }

        public IList<DtoCliente> Get(int pId)
        {
            return _IDataCliente.Get(pId);
        }

        public IList<DtoClienteGrilla> Get(string pValor)
        {
            return _IDataCliente.Get(pValor);
        }

        public bool Post(DtoCliente pEntidad)
        {
            return _IDataCliente.Post(pEntidad);
        }

        public bool Delete(int pId)
        {
            return _IDataCliente.Delete(pId);
        }
        public bool Existe(int pId)
        {
            return _IDataCliente.Existe(pId);
        }
    }
}
