using System;
using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : Controller
    {
        private readonly Respuesta.RespuestaGenerica<DtoCliente> _respuesta;
        private readonly IServiceCliente _service;


        //Constructor
        public ClientesController(IServiceCliente service)
        {
            _respuesta = new Respuesta.RespuestaGenerica<DtoCliente>();
            _service = service;
        }

        #region Get
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoClienteGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoClienteGrilla>();
                var result = _service.Get();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de clientes.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region GetCombo
        [HttpGet("Combo")]
        public JsonResult GetCombo()
        {
            try
            {  
                Respuesta.RespuestaGenerica<DtoClienteCombo> _respuesta = new Respuesta.RespuestaGenerica<DtoClienteCombo>();
                var result = _service.GetCombo();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Combo clientes.", "No se encontraron registros."));
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
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de clientes.", "No se encontraron registros."));
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
                Respuesta.RespuestaGenerica<DtoClienteGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoClienteGrilla>();
                var result = _service.Get(pValor);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de clientes.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult Post(DtoCliente pEntidad)
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
