using Servicio.Core.Entity.DTO.Parametro;
using System.Collections.Generic;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataParametro
    {
        IList<DtoParametroGrilla> Get(int pId);
        IList<DtoParametroGrilla> Get(int pId, int pNroGrupo, bool pPrevaleGrupo = true);
    }
}
