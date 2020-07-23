using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicio.Core.Business.Mantenimiento
{
    public class ServiceReport : IServiceReport
    {
        private readonly IDataReport _IDataReport;

        //inyeccion de dependencias
        public ServiceReport(IDataReport dataReport)
        {
            _IDataReport = dataReport;
        }
        
        public IList<DtoRptVenta> GetRptVenta(int pIdVenta)
        {
            return _IDataReport.GetRptVenta(pIdVenta);
        }

        public IList<DtoRptVentasHoy> GetRptVentasHoy()
        {
            return _IDataReport.GetRptVentasHoy();
        }

        public IList<DtoRptVentasPorMes> GetRptVentasPorMes()
        {
            return _IDataReport.GetRptVentasPorMes();
        }

        public DtoRptProductoMasVendido GetRptProductoMasVendido()
        {
            return _IDataReport.GetRptProductoMasVendido();
        }

        public DtoRptProductoMenosVendido GetRptProductoMenosVendido()
        {
            return _IDataReport.GetRptProductoMenosVendido();
        }
    }
}
