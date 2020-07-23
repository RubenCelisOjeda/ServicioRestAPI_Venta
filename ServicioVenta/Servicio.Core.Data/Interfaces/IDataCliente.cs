using Servicio.Core.Entity.DTO;
using System.Collections.Generic;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataCliente
    {
        IList<DtoClienteGrilla> Get();
        IList<DtoClienteCombo> GetCombo();
        IList<DtoCliente> Get(int pId);
        IList<DtoClienteGrilla> Get(string pValor);
        bool Post(DtoCliente pEntidad);
        bool Delete(int pId);
        bool Existe(int pId);
    }
}
