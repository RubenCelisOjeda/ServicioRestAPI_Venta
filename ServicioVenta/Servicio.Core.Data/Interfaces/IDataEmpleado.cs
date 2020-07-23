using Servicio.Core.Entity.DTO;
using System.Collections.Generic;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataEmpleado
    {
        IList<DtoEmpleadoGrilla> Get();
        IList<DtoEmpleado> Get(int pId = 0);
        IList<DtoEmpleadoCombo> GetCombo(int pIdCombo = 0, int pIdUsuario = 0);
        IList<DtoEmpleadoGrilla> Get(string pValor = "");
        bool Post(DtoEmpleado pEntidad);
        bool Delete(int pId = 0);
        bool Existe(int pId = 0);
    }
}
