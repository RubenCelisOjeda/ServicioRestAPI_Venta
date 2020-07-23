using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceEmpleado : IServiceEmpleado
    {
        private readonly IDataEmpleado _IDataEmpleado;

        //inyeccion de dependencias
        public ServiceEmpleado(IDataEmpleado dataEmpleado)
        {
            _IDataEmpleado = dataEmpleado;
        }

        public IList<DtoEmpleadoGrilla> Get()
        {
            return _IDataEmpleado.Get();
        }

        public IList<DtoEmpleadoCombo> GetCombo(int pIdCombo = 0, int pIdUsuario = 0)
        {
            return _IDataEmpleado.GetCombo(pIdCombo, pIdUsuario);
        }

        public IList<DtoEmpleado> Get(int pId = 0)
        {
            return _IDataEmpleado.Get(pId);
        }

        public IList<DtoEmpleadoGrilla> Get(string pValor = "")
        {
            return _IDataEmpleado.Get(pValor);
        }

        public bool Post(DtoEmpleado pEntidad)
        {
            return _IDataEmpleado.Post(pEntidad);
        }

        public bool Delete(int pId = 0)
        {
            return _IDataEmpleado.Delete(pId);
        }
        public bool Existe(int pId = 0)
        {
            return _IDataEmpleado.Existe(pId);
        }
    }
}
