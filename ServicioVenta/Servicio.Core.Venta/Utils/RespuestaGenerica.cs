using Servicio.Core.Venta.Utils;
using System.Collections.Generic;

namespace Servicio.Core.Venta.Respuesta
{
    /// <summary>
    /// Respuesta generica para GET Listar / POST procesar y Eliminar
    /// </summary>
    /// <typeparam name="T">Clase o DTO que se usará para la Lista de Resultados (grilla) </typeparam>
    public class RespuestaGenerica<T> where T : class, new()
    {
        /// <summary>
        /// Método para proceso POST que devuelve un tipo Respuesta<T> con un parámetro de tipo Class genérica para devolver al Frontend
        /// </summary>
        /// <param name="pResultado">Resultado Boolean de la accion POST, Guardar, Eliminar, etc</param>
        /// <param name="pMensajeOK">Mensaje de visualización en caso el proceso SI sea exitoso</param>
        /// <param name="pMensajeError">Mensaje de visualizacion en caso el proceso No sea exitoso</param>
        /// <returns>Retorna una clase de tipo respuesta para el webAPI</returns>
        public Respuesta<T> RespuestaCorrectaPOST(bool pResultado, string pMensajeOK, string pMensajeError)
        {
            string MensajeRespuesta = pResultado == true ? pMensajeOK : pMensajeError;
            int CodigoErrorRespuesta = pResultado == true ? Constantes.CodigoResultados.Correcto.GetHashCode() : Constantes.CodigoResultados.Error.GetHashCode();

            var Respuesta = new Respuesta<T>() { CodigoError = CodigoErrorRespuesta, Mensaje = MensajeRespuesta, Lista = null, CantidadElementos = 0 };
            return Respuesta;
        }

        /// <summary>
        /// Método para proceso POST LIST que devuelve un tipo Respuesta<T>
        /// </summary>
        /// <param name="pResultado">Resultado Boolean de la accion POST, Guardar, Eliminar, etc</param>
        /// <param name="pMensajeOK">Mensaje de visualización en caso el proceso SI sea exitoso</param>
        /// <param name="pMensajeError">Mensaje de visualizacion en caso el proceso No sea exitoso</param>
        /// <returns>Retorna una clase de tipo respuesta para el webAPI</returns>
        public Respuesta<T> RespuestaCorrectaPOSTList(T pResultado, string pMensajeOK, string pMensajeError)
        {
            string MensajeRespuesta = pResultado == null ? pMensajeError : pMensajeOK;
            int CodigoErrorRespuesta = pResultado == null ? Constantes.CodigoResultados.Correcto.GetHashCode() : Constantes.CodigoResultados.Error.GetHashCode();

            var Respuesta = new Respuesta<T>() { CodigoError = CodigoErrorRespuesta, Mensaje = MensajeRespuesta, Lista = null, CantidadElementos = 0,Entity = pResultado };
            return Respuesta;
        }

        /// <summary>
        /// Método para proceso POST que devuelve un tipo Respuesta<T> con un parámetro de tipo Class genérica para devolver al Frontend
        /// </summary>
        /// <param name="pResultado">Resultado Boolean de la accion POST, Guardar, Eliminar, etc</param>
        /// <param name="pMensajeOK">Mensaje de visualización en caso el proceso SI sea exitoso</param>
        /// <param name="pMensajeError">Mensaje de visualizacion en caso el proceso No sea exitoso</param>
        /// <returns>Retorna una clase de tipo respuesta para el webAPI</returns>
        public RespuestaLogin<T> RespuestaCorrectaPOSTLogin(T pLista, string pMensajeOK, string pMensajeError)
        {
            string MensajeRespuesta = pLista == null ? pMensajeError : pMensajeOK;

            var Respuesta = new RespuestaLogin<T>() { Mensaje = MensajeRespuesta, Dto = pLista, Count = pLista == null ? 0 : 1 };
            return Respuesta;
        }

        /// <summary>
        /// Método para proceso GET que devuelve un tipo Respuesta<T> con un parámetro de tipo Class genérica para devolver al Frontend
        /// </summary>
        /// <param name="pLista">Lista que devuelve la consulta de la Base de datos.</param>
        /// <param name="pMensajeOK">Mensaje de visualización en caso SI sea exitoso o SI contenga registros.</param>
        /// <param name="pMensajeError">Mensaje de visualización en caso NO sea exitoso o NO contenga registros.</param>
        /// <returns>Retorna una clase de tipo respuesta para el webAPI con la lista de registros</returns>
        public Respuesta<T> RespuestaCorrectaGETEntity(T pLista, string pMensajeOK, string pMensajeError, int pCantidadTotalGeneral=0)
        {
            string MensajeRespuesta = pLista != null ? pMensajeOK : pMensajeError;
            var Respuesta = new Respuesta<T>() { CodigoError = Constantes.CodigoResultados.Correcto.GetHashCode(), Mensaje = MensajeRespuesta, Entity = pLista, CantidadElementos = pLista.GetHashCode(), CantidadElementosBD= pCantidadTotalGeneral };
            return Respuesta;
        }

        /// <summary>
        /// Método para proceso GET que devuelve un tipo Respuesta<T> con un parámetro de tipo Class genérica para devolver al Frontend
        /// </summary>
        /// <param name="pLista">Lista que devuelve la consulta de la Base de datos.</param>
        /// <param name="pMensajeOK">Mensaje de visualización en caso SI sea exitoso o SI contenga registros.</param>
        /// <param name="pMensajeError">Mensaje de visualización en caso NO sea exitoso o NO contenga registros.</param>
        /// <returns>Retorna una clase de tipo respuesta para el webAPI con la lista de registros</returns>
        public Respuesta<T> RespuestaCorrectaGET(IList<T> pLista, string pMensajeOK, string pMensajeError, int pCantidadTotalGeneral = 0)
        {
            string MensajeRespuesta = pLista.Count > 0 ? pMensajeOK : pMensajeError;
            var Respuesta = new Respuesta<T>() { CodigoError = Constantes.CodigoResultados.Correcto.GetHashCode(), Mensaje = MensajeRespuesta, Lista = pLista, CantidadElementos = pLista.Count, CantidadElementosBD = pCantidadTotalGeneral };
            return Respuesta;
        }

        /// <summary>
        /// Metodo que retorna una respuesta con el código de Error e indica que ocurrió un error al procesar la solicitud.
        /// </summary>
        /// <returns>Retorna una respuesta de tipo Respuesta<T>, donde T es una clase, DTO de la grilla que debería mostrarse</returns>
        public Respuesta<T> RespuestaError(string msg)
        {
            var Error = new Respuesta<T>() { CodigoError = Constantes.CodigoResultados.Error.GetHashCode(), Mensaje = "Ocurrió un error,error visual : " + msg, Lista = null, CantidadElementos = 0 };
            return Error;
        }
    }
}
