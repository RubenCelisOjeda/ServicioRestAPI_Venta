using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : Controller
    {
        private readonly Respuesta.RespuestaGenerica<DtoUsuario> _respuesta;
        private readonly Respuesta.RespuestaGenerica<DtoLoginResponse> _respuestaLogin;
        private readonly IServiceUsuario _service;

        //Constructor
        public UsuariosController(IServiceUsuario service)
        {
            _respuesta = new Respuesta.RespuestaGenerica<DtoUsuario>();
            _respuestaLogin = new Respuesta.RespuestaGenerica<DtoLoginResponse>();
            _service = service;
        }

        #region Get
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoUsuarioGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoUsuarioGrilla>();
                var result = _service.Get();
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de usuarios.", "No se encontraron registros."));
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
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de usuarios.", "No se encontraron registros."));
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
                Respuesta.RespuestaGenerica<DtoUsuarioGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoUsuarioGrilla>();
                var result = _service.Get(pValor);
                return Json(_respuesta.RespuestaCorrectaGET(result, "Lista de usuarios.", "No se encontraron registros."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Post
        [HttpPost]
        public IActionResult Post(DtoUsuario pEntidad)
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

        #region Validar
        [HttpPost("Validar")]
        public IActionResult Validar(DtoLoginRequest pEntidad)
        {
            try
            {
         
                var result = _service.Validar(pEntidad);
                return Json(_respuestaLogin.RespuestaCorrectaPOSTLogin(result, "Usuario validado correctamente.", "Usuario y/o contraseña incorrecta."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion

        #region Put
        [HttpPost("PutAccount")]
        public IActionResult PutAccount(DtoAccountRequest pEntidad)
        {
            try
            {
                var result = _service.PutAccount(pEntidad);
                return Json(_respuestaLogin.RespuestaCorrectaPOST(result, "Se guardo correctamente.", "Error no se puedo guardar."));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.ToString()));
            }
        }
        #endregion
    }
}
