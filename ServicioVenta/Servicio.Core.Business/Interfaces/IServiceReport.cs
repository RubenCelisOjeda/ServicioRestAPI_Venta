using Servicio.Core.Entity.DTO.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Business.Interfaces
{
    public interface IServiceReport
    {
        IList<DtoRptVenta> GetRptVenta(int pIdVenta);
        IList<DtoRptVentasHoy> GetRptVentasHoy();
        IList<DtoRptVentasPorMes> GetRptVentasPorMes();
        DtoRptProductoMasVendido GetRptProductoMasVendido();
        DtoRptProductoMenosVendido GetRptProductoMenosVendido();
    }
}
