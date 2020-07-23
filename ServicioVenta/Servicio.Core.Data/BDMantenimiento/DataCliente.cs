using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataCliente : IDataCliente
    {

        #region Get
        /// <summary>
        /// Listar los campos basicos de cliente, esto se vera en la grilla principal
        /// </summary>
        /// <returns>retorno todos lo datos primeros clientes encontradas.</returns>
        public IList<DtoClienteGrilla> Get()
        {
            List<DtoClienteGrilla> ListadoDTO = new List<DtoClienteGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Cliente.Where(c => c.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        Dni = x.Dni

                    }).ToList()

                    .Select(x => new DtoClienteGrilla()
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        Dni = x.Dni
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get combo
        /// <summary>
        /// Listar los campos basicos de clientes, esto se vera en el combo de la vista solicitada
        /// </summary>
        /// <returns>retorno todos lo datos primeros clientes encontradas.</returns>
        public IList<DtoClienteCombo> GetCombo()
        {
            List<DtoClienteCombo> ListadoDTO = new List<DtoClienteCombo>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Cliente.Where(c => c.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Cliente = x.Nombres + " " + x.ApellidoPaterno + " " + x.ApellidoMaterno

                    }).ToList()

                    .Select(x => new DtoClienteCombo()
                    {
                        Id = x.Id,
                        Cliente = x.Cliente,
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / Id
        /// <summary>
        /// Devuelve los clientes con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del cliente registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoCliente> Get(int pId)
        {
            List<DtoCliente> ListadoDTO = new List<DtoCliente>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Cliente.Where(x => x.Id == pId && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        Dni = x.Dni,
                        Celular = x.Celular,
                        NombreFacebook = x.NombreFacebook,
                        DireccionLugarEntrega = x.DireccionLugarEntrega

                    }).ToList()

                    .Select(x => new DtoCliente()
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        Dni = x.Dni,
                        Celular = x.Celular,
                        NombreFacebook = x.NombreFacebook,
                        DireccionLugarEntrega = x.DireccionLugarEntrega
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / pValor
        /// <summary>
        /// Funcion que permite listar los clientes con el valor ingresado
        /// </summary>
        /// <param name="pValor">valor del cliente que se va a buscar</param>
        /// <returns>Retorna la lista con los clientes encontrados con el valor ingresado.</returns>
        public IList<DtoClienteGrilla> Get(string pValor)
        {
            List<DtoClienteGrilla> ListadoDTO = new List<DtoClienteGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Cliente.Where(x => EF.Functions.Like(x.Nombres,"%" + pValor + "%") && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        Dni = x.Dni

                    }).ToList()

                    .Select(x => new DtoClienteGrilla()
                    {
                        Id = x.Id,
                        Nombres = x.Nombres,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        Dni = x.Dni
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Post / Put
        /// <summary>
        /// Permite Guardar el registro del cliente en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores del cliente que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool Post(DtoCliente pEntidad)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                    var cliente = new BDTablas.Cliente()
                    {
                        Id = pEntidad.Id,
                        Nombres = pEntidad.Nombres,
                        ApellidoPaterno = pEntidad.ApellidoPaterno,
                        ApellidoMaterno = pEntidad.ApellidoMaterno,
                        Dni = pEntidad.Dni,
                        Status = 1,
                        Celular = pEntidad.Celular,
                        NombreFacebook = pEntidad.NombreFacebook,
                        DireccionLugarEntrega = pEntidad.DireccionLugarEntrega
                    };

                    if (cliente.Id ==0)
                    {
                        db.Cliente.Add(cliente);
                    }
                    else
                    {
                        db.Entry(cliente).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    IsValid = true;
                }
            }
            return IsValid;
        }
        #endregion

        #region Delete / Id
        /// <summary>
        /// Elimina logicamente el registro del cliente en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del cliente registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Delete(int pId)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var cliente = db.Cliente.Find(pId);

                if (cliente != null)
                {
                    cliente.Status = 0;
                    db.Entry(cliente).CurrentValues.SetValues(cliente);
                    db.SaveChanges();
                }
               
                IsValid = true;
            }
            return IsValid;
        }
        #endregion

        #region Existe / Id
        /// <summary>
        /// Validate la existencia del registro del cliente en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del cliente registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Existe(int pId)
        {
            bool Existe = false;

            using (var db = new BD_SistemaVentaContext())
            {
                Existe = db.Cliente.Any(x => x.Id == pId);

                if (Existe == true)
                {
                    Existe = true;
                }
                else
                {
                    Existe = false;
                }
            }
            return Existe;
        }
        #endregion
    }
}
