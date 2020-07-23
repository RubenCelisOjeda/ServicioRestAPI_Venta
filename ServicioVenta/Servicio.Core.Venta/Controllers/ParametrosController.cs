using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Entity.DTO.Parametro;
using System;

namespace Servicio.Core.Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ParametrosController : Controller
    {
        private readonly Respuesta.RespuestaGenerica<DtoParametro> _respuesta;
        private readonly IServiceParametro _service;

        //Constructor
        public ParametrosController(IServiceParametro service)
        {
            _respuesta = new Respuesta.RespuestaGenerica<DtoParametro>();
            _service = service;
        }

        #region Get
        [HttpGet("{pId}/{pNroGrupo}")]
        [HttpGet("{pId}/{pNroGrupo}/{pPrevaleceGrupo}")]
        public IActionResult BuscarPorIdYGrupo(int pId, int pNroGrupo, bool pPrevaleceGrupo = true)
        {
            try
            {
                Respuesta.RespuestaGenerica<DtoParametroGrilla> _respuesta = new Respuesta.RespuestaGenerica<DtoParametroGrilla>();
                var resultado = _service.Get(pId, pNroGrupo, pPrevaleceGrupo);
                return Json(_respuesta.RespuestaCorrectaGET(resultado, "Lista de parámetros", "No se encontraron registros"));
            }
            catch (Exception ex)
            {
                return Json(_respuesta.RespuestaError(ex.Message.ToString()));
            }
        }
        #endregion
    }
}