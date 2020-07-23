using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO;
using System;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmpleadosController : Controller
    {
        private readonly Respuesta.RespuestaGenerica<DtoEmpleado> _respuesta;
        private readonly IServiceEmpleado _service;

        //Constructor
        public EmpleadosController(IServiceEmpleado service)
        {
            _respuesta = new Respuesta.RespuestaGenerica<DtoEmpleado>();
            _service = service;
        }

        #region Get
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoEmpleadoGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoEmpleadoGrilla>();
                var result = _service.Get();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de empleados.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Get combo
        [HttpGet("Combo/{pIdCombo}/{pIdUsuario}")]
        public JsonResult GetCombo(int pIdCombo = 0, int pIdUsuario = 0)
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoEmpleadoCombo> _respuesta = new Respuesta.RespuestaGenerica<DtoEmpleadoCombo>();
                var result = _service.GetCombo(pIdCombo, pIdUsuario);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Combo de empleados.", "No se encontraron registros."));
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
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de empleados.", "No se encontraron registros."));
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
                Respuesta.RespuestaGenerica<DtoEmpleadoGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoEmpleadoGrilla>();
                var result = _service.Get(pValor);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de empleados.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult Post(DtoEmpleado pEntidad)
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
        public IActionResult Delete(int pId)
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
        public IActionResult Existe(int pId)
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
