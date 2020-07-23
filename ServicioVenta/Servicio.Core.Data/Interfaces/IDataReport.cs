using Servicio.Core.Entity.DTO.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Data.Interfaces
{
    public interface IDataReport
    {
        IList<DtoRptVenta> GetRptVenta(int pIdVenta);
        IList<DtoRptVentasHoy> GetRptVentasHoy();
        IList<DtoRptVentasPorMes> GetRptVentasPorMes();
        DtoRptProductoMasVendido GetRptProductoMasVendido();
        DtoRptProductoMenosVendido GetRptProductoMenosVendido();
    }
}
