using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataUsuario : IDataUsuario
    {
        #region Get
        /// <summary>
        /// Listar los campos basicos de usuarios, esto se vera en la grilla principal
        /// </summary>s
        /// <returns>retorno todos lo datos primeros usuarios encontradas.</returns>
        public IList<DtoUsuarioGrilla> Get()
        {
            List<DtoUsuarioGrilla> ListadoDTO = null;

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Usuario.Where(u => u.Status == 1 && u.Estado == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        UsuarioName = x.UsuarioName,
                        Password = x.Password,
                        Email = x.Email,
                        RolUsuario = db.Parametros.Where(p => Convert.ToInt32(p.Valor1) == x.RoId && p.NroGrupo == 1).FirstOrDefault().Nombre,
                        Estado = x.Estado == 1 ? "Activo" : "Inactivo",
                        FechaRegistro = x.FechaRegistro,
                        Empleado = db.Empleado.Where(e => e.Id == x.IdEmpleado).FirstOrDefault().Nombre

                    }).ToList()

                    .Select(x => new DtoUsuarioGrilla()
                    {
                        Id = x.Id,
                        UsuarioName = x.UsuarioName,
                        Password = x.Password,
                        Email = x.Email,
                        RolUsuario = x.RolUsuario,
                        Estado = x.Estado,
                        FechaRegistro = x.FechaRegistro,
                        Empleado = x.Empleado
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / Id
        /// <summary>
        /// Devuelve los usuarios con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del usuario registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoUsuario> Get(int pId)
        {
            List<DtoUsuario> ListadoDTO = new List<DtoUsuario>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Usuario.Where(x => x.Id == pId && x.Status == 1 && x.Estado == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        UsuarioName = x.UsuarioName,
                        Password = x.Password,
                        Email = x.Email,
                        RoId = x.RoId,
                        Estado = x.Estado,
                        FechaRegistro = x.FechaRegistro,
                        IdEmpleado = x.IdEmpleado,

                    }).ToList()

                    .Select(x => new DtoUsuario()
                    {
                        Id = x.Id,
                        UsuarioName = x.UsuarioName,
                        Password = x.Password,
                        Email = x.Email,
                        RoId = x.RoId,
                        Estado = x.Estado,
                        FechaRegistro = x.FechaRegistro,
                        IdEmpleado = x.IdEmpleado,
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / pValor
        /// <summary>
        /// Funcion que permite listar los productos con el valor ingresado
        /// </summary>
        /// <param name="pValor">valor del producto que se va a buscar</param>
        /// <returns>Retorna la lista con los productos encontrados con el valor ingresado.</returns>
        public IList<DtoUsuarioGrilla> Get(string pValor)
        {
            List<DtoUsuarioGrilla> ListadoDTO = new List<DtoUsuarioGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Usuario.Where(x => EF.Functions.Like(x.UsuarioName, "%" + pValor + "%"))
                    .Select(x => new
                    {
                        Id = x.Id,
                        UsuarioName = x.UsuarioName,
                        Password = x.Password,
                        Email = x.Email,
                        RolUsuario = db.Parametros.Where(p => p.Id == x.RoId).FirstOrDefault().Nombre,
                        Estado = x.Estado == 1 ? "Activo" : "Inactivo",
                        FechaRegistro = x.FechaRegistro,
                        Empleado = db.Empleado.Where(e => e.Id == x.IdEmpleado).FirstOrDefault().Nombre

                    }).ToList()

                    .Select(x => new DtoUsuarioGrilla()
                    {
                        Id = x.Id,
                        UsuarioName = x.UsuarioName,
                        Password = x.Password,
                        Email = x.Email,
                        RolUsuario = x.RolUsuario,
                        Estado = x.Estado,
                        FechaRegistro = x.FechaRegistro,
                        Empleado = x.Empleado
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Post / Put
        /// <summary>
        /// Permite Guardar el registro del usuario en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores del usuario que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool Post(DtoUsuario pEntidad)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                    var usuario = new BDTablas.Usuario()
                    {
                        Id = pEntidad.Id,
                        UsuarioName = pEntidad.UsuarioName,
                        Password = pEntidad.Password,
                        Email = pEntidad.Email,
                        RoId = pEntidad.RoId,
                        Estado = pEntidad.Estado,
                        IdEmpleado = pEntidad.IdEmpleado,
                        Status = pEntidad.Status
                    };

                    if (usuario.Id == 0)
                    {
                        usuario.FechaRegistro = pEntidad.FechaRegistro;
                        db.Usuario.Add(usuario);
                    }
                    else
                    {
                        db.Entry(usuario).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    IsValid = true;
                }
            }
            return IsValid;
        }
        #endregion

        #region Put
        /// <summary>
        /// Permite actualizar el registro del usuario en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores del usuario que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool PutAccount(DtoAccountRequest pEntidad)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var usuario = db.Usuario.Find(pEntidad.Id);

                if (usuario != null)
                {
                    usuario.UsuarioName = pEntidad.Usuario;
                    usuario.Email = pEntidad.Email;
                    db.Entry(usuario).CurrentValues.SetValues(usuario);
                    db.SaveChanges();
                }
                IsValid = true;
            }
            return IsValid;
        }
        #endregion

        #region Delete / Id
        /// <summary>
        /// Elimina logicamente el registro del usuario en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del usuario registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Delete(int pId)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var usuario = db.Usuario.Find(pId);

                if (usuario != null)
                {
                    usuario.Estado = 0;
                    db.Entry(usuario).CurrentValues.SetValues(usuario);
                    db.SaveChanges();
                }
                IsValid = true;
            }
            return IsValid;
        }
        #endregion

        #region Existe / Id
        /// <summary>
        /// Valida la existencia del registro del producto en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del producto registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Existe(int pId)
        {
            bool Existe = false;

            using (var db = new BD_SistemaVentaContext())
            {
                Existe = db.Producto.Any(x => x.Id == pId);

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

        #region Validar / Usuario/Contraseña
        /// <summary>
        /// Valida el usuario en la base de datos
        /// </summary>
        /// <param name="pId">Numero de ID del producto registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public DtoLoginResponse Validar(DtoLoginRequest pEntidad)
        {
            DtoLoginResponse Dto = null;

            using (var db = new BD_SistemaVentaContext())
            {
                var response = db.Usuario.Where(x => x.UsuarioName == pEntidad.Usuario &&
                                                     x.Password == pEntidad.Password && 
                                                     x.Estado == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Usuario = x.UsuarioName,
                        Rol = db.Parametros.Where(p => Convert.ToInt32(p.Valor1) == x.RoId && p.NroGrupo == 1).FirstOrDefault().Nombre,
                        Status = x.Status == 1 ? "Activo" : "Inactivo",
                        Email = x.Email

                    }).ToList()

                    .Select(x => new DtoLoginResponse()
                    {
                        Id = x.Id,
                        Usuario = x.Usuario,
                        Rol = x.Rol,
                        Status = x.Status,
                        Email = x.Email

                    }).SingleOrDefault();

                Dto = response;
            }
            return Dto;
        }
        #endregion
    }
}
