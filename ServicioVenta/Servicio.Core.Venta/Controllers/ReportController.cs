using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO.Report;
using System;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReportController : Controller
    {
        private readonly IServiceReport _service;

        public ReportController(IServiceReport service)
        {
            this._service = service;
        }

        #region GetRptVenta
        [HttpGet("RptVenta/{pIdVenta}")]
        public JsonResult GetRptVenta(int pIdVenta)
        {
            Respuesta.RespuestaGenerica<DtoRptVenta> _respuesta = new Respuesta.RespuestaGenerica<DtoRptVenta>();

            try
            {
                var result = _service.GetRptVenta(pIdVenta);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de ventas.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region GetRptVentasHoy
        [HttpGet("Rpt/RptVentasHoy")]
        public JsonResult GetRptVentasHoy()
        {
            Respuesta.RespuestaGenerica<DtoRptVentasHoy> _respuesta = new Respuesta.RespuestaGenerica<DtoRptVentasHoy>();

            try
            {
                var result = _service.GetRptVentasHoy();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de ventas.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region GetRptVentasPorMes
        [HttpGet("Rpt/RptVentasPorMes")]
        public JsonResult GetRptVentasPorMes()
        {
            Respuesta.RespuestaGenerica<DtoRptVentasPorMes> _respuesta = new Respuesta.RespuestaGenerica<DtoRptVentasPorMes>();

            try
            {
                var result = _service.GetRptVentasPorMes();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de ventas.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region GetRptProductoMasVendido
        [HttpGet("Rpt/RptProductoMasVendido")]
        public JsonResult GetRptProductoMasVendido()
        {
            Respuesta.RespuestaGenerica<DtoRptProductoMasVendido> _respuesta = new Respuesta.RespuestaGenerica<DtoRptProductoMasVendido>();

            try
            {
                var result = _service.GetRptProductoMasVendido();
                return Json(_respuesta.RespuestaCorrectaGETEntity(result, "Correcto.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region GetProductoMenosVendido
        [HttpGet("Rpt/RptProductoMenosVendido")]
        public JsonResult GetRptProductoMenosVendido()
        {
            Respuesta.RespuestaGenerica<DtoRptProductoMenosVendido> _respuesta = new Respuesta.RespuestaGenerica<DtoRptProductoMenosVendido>();

            try
            {
                var result = _service.GetRptProductoMenosVendido();
                return Json(_respuesta.RespuestaCorrectaGETEntity(result, "Correcto.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion
    }
}