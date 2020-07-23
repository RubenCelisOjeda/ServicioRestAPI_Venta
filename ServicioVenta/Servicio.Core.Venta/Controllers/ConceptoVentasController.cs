using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO;
using System;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ConceptoVentasController : Controller
    {
        private readonly Respuesta.RespuestaGenerica<DtoConceptoVenta> _respuesta = null;
        private readonly IServiceConceptoVenta _service = null;

        //Constructor
        public ConceptoVentasController(IServiceConceptoVenta service = null)
        {
            _respuesta = new Respuesta.RespuestaGenerica<DtoConceptoVenta>();
            _service = service;
        }

        #region Get
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoConceptoVentaGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoConceptoVentaGrilla>();
                var result = _service.Get();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de concepto de venta.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Id
        [HttpGet("{pId}")]
        public JsonResult Get(int pId = 0)
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoConceptoVentaResponse> _respuesta = new Respuesta.RespuestaGenerica<DtoConceptoVentaResponse>();
                var result = _service.Get(pId);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de concepto de venta.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Id
        [HttpGet("Detalle/{pId}")]
        public JsonResult GetAllByVentaId(int pId = 0)
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoConceptoVentaDetails> _respuesta = new Respuesta.RespuestaGenerica<DtoConceptoVentaDetails>();
                var result = _service.GetAllByVentaId(pId);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de concepto de venta.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Valor
        [HttpGet("Filtro/{pValor}")]
        public JsonResult Get(string pValor = "%")
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoConceptoVentaGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoConceptoVentaGrilla>();
                var result = _service.Get(pValor);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de concepto de venta.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult Post(DtoConceptoVenta pEntidad = null)
        {
            try
            {
                var result = _service.Post(pEntidad);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se Guardó Correctamente.", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Delete / Id
        [HttpDelete("{pId}")]
        public IActionResult Delete(int pId = 0)
        {
            try
            {
                var result = _service.Delete(pId);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se Elimino Correctamente.", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Existe / Id
        [HttpGet("Existe/{pId}")]
        public IActionResult Existe(int pId = 0)
        {
            try
            {
                var result = _service.Existe(pId);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se encontro Correctamente.", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion
    }
}
