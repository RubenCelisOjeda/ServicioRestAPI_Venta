using Servicio.Core.Entity.DTO.Parametro;
using System.Collections.Generic;

namespace Servicio.Core.Business.Interfaces
{
    public interface IServiceParametro
    {
        IList<DtoParametroGrilla> Get(int pId, int pNroGrupo, bool pPrevaleGrupo = true);
    }
}
