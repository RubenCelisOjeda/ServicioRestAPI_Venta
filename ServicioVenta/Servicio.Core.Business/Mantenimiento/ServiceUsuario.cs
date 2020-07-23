using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System.Collections.Generic;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IDataUsuario _IDataUsuario;

        //inyeccion de dependencias
        public ServiceUsuario(IDataUsuario dataUsuario)
        {
            _IDataUsuario = dataUsuario;
        }

        public IList<DtoUsuarioGrilla> Get()
        {
            return _IDataUsuario.Get();
        }

        public IList<DtoUsuario> Get(int pId)
        {
            return _IDataUsuario.Get(pId);
        }

        public IList<DtoUsuarioGrilla> Get(string pValor)
        {
            return _IDataUsuario.Get(pValor);
        }

        public bool Post(DtoUsuario pEntidad)
        {
            return _IDataUsuario.Post(pEntidad);
        }

        public bool PutAccount(DtoAccountRequest pEntidad)
        {
            return _IDataUsuario.PutAccount(pEntidad);
        }

        public bool Delete(int pId)
        {
            return _IDataUsuario.Delete(pId);
        }

        public bool Existe(int pId)
        {
            return _IDataUsuario.Existe(pId);
        }

        public DtoLoginResponse Validar(DtoLoginRequest pEntidad)
        {
            return _IDataUsuario.Validar(pEntidad);
        }
    }
}
