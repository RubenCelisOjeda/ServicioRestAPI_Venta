using Servicio.Core.Entity.DTO;
using System.Collections.Generic;

namespace Servicio.Core.Business.Interfaces
{
    public interface IServiceConceptoVenta
    {
        IList<DtoConceptoVentaGrilla> Get();
        IList<DtoConceptoVentaResponse> Get(int pId = 0);
        IList<DtoConceptoVentaDetails> GetAllByVentaId(int pId = 0);
        IList<DtoConceptoVentaGrilla> Get(string pValor  = "%");
        bool Post(DtoConceptoVenta pEntidad = null);
        bool Delete(int pId = 0);
        bool Existe(int pId = 0);
    }
}
