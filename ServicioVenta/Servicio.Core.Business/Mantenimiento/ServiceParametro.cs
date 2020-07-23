using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO.Parametro;
using System.Collections.Generic;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceParametro : IServiceParametro
    {
        private readonly IDataParametro _IDataParametro;

        //inyeccion de dependencias
        public ServiceParametro(IDataParametro dataParametro)
        {
            _IDataParametro = dataParametro;
        }

        public IList<DtoParametroGrilla> Get(int pId, int pNroGrupo, bool pPrevaleGrupo = true)
        {
            return _IDataParametro.Get(pId,pNroGrupo,pPrevaleGrupo);
        }
    }
}
