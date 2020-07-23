using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO;
using System;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductosController : Controller
    {
        private readonly Respuesta.RespuestaGenerica<DtoProducto> _respuesta;
        private readonly IServiceProducto _service;

        //Constructor
        public ProductosController(IServiceProducto service)
        {
            _respuesta = new Respuesta.RespuestaGenerica<DtoProducto>();
            _service = service;
        }

        #region Get
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoProductoGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoProductoGrilla>();
                var result = _service.Get();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de productos.", "No se encontraron registros."));
            }  
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Id
        [HttpGet("{pId}")]
        public JsonResult Get(int pId)
        {
            try
            {
                var result = _service.Get(pId);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de productos.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Id
        [HttpGet("PrecioStock/{pId}")]
        public JsonResult GetPrecioStock(int pId)
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoProductoPrecioStock> _respuesta = new Respuesta.RespuestaGenerica<DtoProductoPrecioStock>();

                var result = _service.GetPrecioStock(pId);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de productos.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get combo
        [HttpGet("Combo")]
        public JsonResult GetCombo()
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoProductoCombo> _respuesta = new Respuesta.RespuestaGenerica<DtoProductoCombo>();
                var result = _service.GetCombo();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de productos combo.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Valor
        [HttpGet("Filtro/{pValor}")]
        public JsonResult Get(string pValor)
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoProductoGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoProductoGrilla>();
                var result = _service.Get(pValor);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de productos.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult Post(DtoProducto pEntidad)
        {
            try
            {
                var result = _service.Post(pEntidad);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se Guardó Correctamente", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Post
        [HttpPost("{ActualizarStock}")]
        public IActionResult PutStock(DtoProductoStock pEntidad)
        {
            try
            {
                var result = _service.PutStock(pEntidad);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se actualizo Correctamente", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Delete / Id
        [HttpDelete("{pId}")]
        public IActionResult Delete(int pId)
        {
            try
            {
                var result = _service.Delete(pId);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se Elimino Correctamente", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get / Existe / Id
        [HttpGet("Existe/{pId}")]
        public IActionResult Existe(int pId)
        {
            try
            {
                var result = _service.Existe(pId);
                return Json(_respuesta.RespuestaCorrectaPOST(result, "Se encontro Correctamente", "Ocurrió un error"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion
    }
}
