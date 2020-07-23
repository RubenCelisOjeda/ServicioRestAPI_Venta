using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataEmpleado : IDataEmpleado
    {
        #region Get
        /// <summary>
        /// Listar los campos basicos de empleado, esto se vera en la grilla principal
        /// </summary>s
        /// <returns>retorno todos lo datos primerass empleados encontradas.</returns>
        public IList<DtoEmpleadoGrilla> Get()
        {
            List<DtoEmpleadoGrilla> ListadoDTO = new List<DtoEmpleadoGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Empleado.Where(e => e.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        FechaNacimiento = x.FechaNacimiento,
                        EstadoCivil = db.Parametros.Where(p => Convert.ToInt32(p.Valor1) == x.EstadoCivil && p.NroGrupo == 2).FirstOrDefault().Nombre,
                        Direccion = x.Direccion
                    }).ToList()

                    .Select(x => new DtoEmpleadoGrilla()
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        FechaNacimiento = x.FechaNacimiento,
                        EstadoCivil = x.EstadoCivil,
                        Direccion = x.Direccion
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Get combo
        /// <summary>
        /// Listar los campos basicos de empleado, esto se vera en el combo de la vista solicitada
        /// </summary>
        /// <returns>retorno todos lo datos primerass empleados encontradas.</returns>
        public IList<DtoEmpleadoCombo> GetCombo(int pIdCombo = 0,int pIdUsuario = 0)
        {
            List<DtoEmpleadoCombo> ListadoDTO = new List<DtoEmpleadoCombo>();

            using (var db = new BD_SistemaVentaContext())
            {
                if (pIdCombo == 0)
                {
                    var empleado = db.Usuario.Where(u => u.Id == pIdUsuario && u.Status == 1 && u.Estado == 1).Single();
                    var listado = db.Empleado.Where(e => e.Id == empleado.IdEmpleado && e.Status == 1)
                        .Select(x => new
                        {
                            Id = x.Id,
                            Nombre = x.Nombre + " " + x.ApellidoPaterno + " " + x.ApellidoMaterno
                        }).ToList()

                        .Select(x => new DtoEmpleadoCombo()
                        {
                            Id = x.Id,
                            Empleado = x.Nombre
                        });
                        return ListadoDTO = listado.ToList();
                }
                else
                {
                    var usuario = db.Usuario.Select(x => x.IdEmpleado).ToArray();
                    var listado = db.Empleado.Where(e => !usuario.Contains(e.Id))
                        .Select(x => new
                        {
                            Id = x.Id,
                            Nombre = x.Nombre + " " + x.ApellidoPaterno + " " + x.ApellidoMaterno
                        }).ToList()

                        .Select(x => new DtoEmpleadoCombo()
                        {
                            Id = x.Id,
                            Empleado = x.Nombre
                        });
                    return ListadoDTO = listado.ToList();
                }
            }
        }
        #endregion

        #region Get / Id
        /// <summary>
        /// Devuelve los empleado con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del empleado registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoEmpleado> Get(int pId)
        {
            List<DtoEmpleado> ListadoDTO = new List<DtoEmpleado>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Empleado.Where(x => x.Id == pId && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        FechaNacimiento = x.FechaNacimiento,
                        EstadoCivil = x.EstadoCivil,
                        Direccion = x.Direccion

                    }).ToList()

                    .Select(x => new DtoEmpleado()
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        FechaNacimiento = x.FechaNacimiento,
                        EstadoCivil = x.EstadoCivil,
                        Direccion = x.Direccion
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Get / pValor
        /// <summary>
        /// Funcion que permite listar los empleados con el valor ingresado
        /// </summary>
        /// <param name="pValor">valor del empleado que se va a buscar</param>
        /// <returns>Retorna la lista con los empleados encontrados con el valor ingresado.</returns>
        public IList<DtoEmpleadoGrilla> Get(string pValor)
        {
            List<DtoEmpleadoGrilla> ListadoDTO = new List<DtoEmpleadoGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Empleado.Where(x => EF.Functions.Like(x.Nombre, "%" + pValor + "%") && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        FechaNacimiento = x.FechaNacimiento,
                        EstadoCivil = db.Parametros.Where(p => Convert.ToInt32(p.Valor1) == x.EstadoCivil && p.NroGrupo == 2).FirstOrDefault().Nombre,
                        Direccion = x.Direccion

                    }).ToList()

                    .Select(x => new DtoEmpleadoGrilla()
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        ApellidoPaterno = x.ApellidoPaterno,
                        ApellidoMaterno = x.ApellidoMaterno,
                        FechaNacimiento = x.FechaNacimiento,
                        EstadoCivil = x.EstadoCivil,
                        Direccion = x.Direccion
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Post / Put
        /// <summary>
        /// Permite Guardar el registro del empleado en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores del empleado que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool Post(DtoEmpleado pEntidad)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                    var empleado = new BDTablas.Empleado()
                    {
                        Id = pEntidad.Id,
                        Nombre = pEntidad.Nombre,
                        ApellidoPaterno = pEntidad.ApellidoPaterno,
                        ApellidoMaterno = pEntidad.ApellidoMaterno,
                        FechaNacimiento = pEntidad.FechaNacimiento,
                        EstadoCivil = pEntidad.EstadoCivil,
                        Direccion = pEntidad.Direccion,
                        Status = pEntidad.Status
                    };

                    if (empleado.Id == 0)
                    {
                        db.Empleado.Add(empleado);
                    }
                    else
                    {
                        db.Entry(empleado).State = EntityState.Modified;
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
        /// Elimina logicamente el registro del empleado en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del empleado registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Delete(int pId)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var empleado = db.Empleado.Find(pId);

                if (empleado != null)
                {
                    empleado.Status = 0;
                    db.Entry(empleado).CurrentValues.SetValues(empleado);
                    db.SaveChanges();
                }
                IsValid = true;
            }
            return IsValid;
        }
        #endregion

        #region Existe / Id
        /// <summary>
        /// Valida la existencia del usuario el registro del empleado en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del empleado registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Existe(int pId)
        {
            bool Existe = false;

            using (var db = new BD_SistemaVentaContext())
            {
                Existe = db.Empleado.Any(x => x.Id == pId);

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
