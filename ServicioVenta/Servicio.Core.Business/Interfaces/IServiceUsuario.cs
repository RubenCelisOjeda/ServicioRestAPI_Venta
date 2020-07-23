using Servicio.Core.Entity.DTO;
using System.Collections.Generic;

namespace Servicio.Core.Business.Interfaces
{
    public interface IServiceUsuario
    {
        IList<DtoUsuarioGrilla> Get();
        IList<DtoUsuario> Get(int pId);
        IList<DtoUsuarioGrilla> Get(string pValor);
        bool Post(DtoUsuario pEntidad);
        bool PutAccount(DtoAccountRequest pEntidad);
        bool Delete(int pId);
        bool Existe(int pId);
        DtoLoginResponse Validar(DtoLoginRequest pEntidad);
    }
}
