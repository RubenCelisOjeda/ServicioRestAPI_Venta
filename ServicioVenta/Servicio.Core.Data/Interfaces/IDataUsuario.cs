using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataUsuario
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
