using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataProducto : IDataProducto
    {
        #region Get
        /// <summary>
        /// Listar los campos basicos de producto, esto se vera en la grilla principal
        /// </summary>
        /// <returns>retorno todos lo datos primeros producto encontradas.</returns>
        public IList<DtoProductoGrilla> Get()
        {
            List<DtoProductoGrilla> ListadoDTO = new List<DtoProductoGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Producto.Where(p => p.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = x.Precio,
                        Costo = x.Costo,
                        Stock = x.Stock

                    }).ToList()

                    .Select(x => new DtoProductoGrilla()
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = x.Precio,
                        Costo = x.Costo,
                        Stock = x.Stock
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get combo
        /// <summary>
        /// Listar los campos basicos de producto, esto se vera en el combo de la vista solicitada
        /// </summary>
        /// <returns>retorno todos lo datos primeros producto encontradas.</returns>
        public IList<DtoProductoCombo> GetCombo()
        {
            List<DtoProductoCombo> ListadoDTO = new List<DtoProductoCombo>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Producto.Where(x => x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Producto = x.Nombre

                    }).ToList()

                    .Select(x => new DtoProductoCombo()
                    {
                        Id = x.Id,
                        Producto = x.Producto
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / Id
        /// <summary>
        /// Devuelve los productos con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del producto registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoProducto> Get(int pId)
        {
            List<DtoProducto> ListadoDTO = new List<DtoProducto>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Producto.Where(x => x.Id == pId && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = x.Precio,
                        Costo = x.Costo,
                        Stock = x.Stock

                    }).ToList()

                    .Select(x => new DtoProducto()
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = x.Precio,
                        Costo = x.Costo,
                        Stock = x.Stock
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get /Precio Stock
        /// <summary>
        /// Devuelve los productos con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del producto registrado</param>
        /// <returns>Retorna el precio con el ingreso que se encontro.</returns>
        public IList<DtoProductoPrecioStock> GetPrecioStock(int pId)
        {
            List<DtoProductoPrecioStock> ListadoDTO = new List<DtoProductoPrecioStock>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Producto.Where(x => x.Id == pId && x.Status == 1)
                    .Select(x => new
                    {
                        Precio = x.Precio,
                        Stock = x.Stock,

                    }).ToList()

                    .Select(x => new DtoProductoPrecioStock()
                    {
                        Precio = x.Precio,
                        Stock = x.Stock
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
        public IList<DtoProductoGrilla> Get(string pValor)
        {
            List<DtoProductoGrilla> ListadoDTO = new List<DtoProductoGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Producto.Where(x => EF.Functions.Like(x.Nombre, "%" + pValor + "%") && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = x.Precio,
                        Costo = x.Costo,
                        Stock = x.Stock

                    }).ToList()

                    .Select(x => new DtoProductoGrilla()
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                        Precio = x.Precio,
                        Costo = x.Costo,
                        Stock = x.Stock
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Put Stock
        /// <summary>
        /// Actualiza el stock del producto del Id seleccionado
        /// </summary>
        /// <param name="pEntidad">Entidad con el valor del stock del producto.
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool PutStock(DtoProductoStock pEntidad)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                    var query = db.Producto.Single(p => p.Id ==  pEntidad.Id && p.Status == 1);

                    if (pEntidad.Accion == "restar")
                    {
                        query.Stock = query.Stock -= pEntidad.Stock;
                    }
                    else
                    {
                        query.Stock = query.Stock += pEntidad.Stock;
                    }
                    db.SaveChanges();
                    IsValid = true;
                }
            }
            return IsValid;
        }
        #endregion

        #region Post / Put
        /// <summary>
        /// Permite Guardar el registro del producto en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores del producto que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool Post(DtoProducto pEntidad)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                    var producto = new BDTablas.Producto()
                    {
                        Id = pEntidad.Id,
                        Nombre = pEntidad.Nombre,
                        Precio = pEntidad.Precio,
                        Costo = pEntidad.Costo,
                        Stock = pEntidad.Stock,
                        Status = 1
                    };

                    if (producto.Id == 0)
                    {
                        db.Producto.Add(producto);
                    }
                    else
                    {
                        db.Entry(producto).State = EntityState.Modified;
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
        /// Elimina logicamente el registro del producto en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID del producto registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Delete(int pId)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var producto = db.Producto.Find(pId);

                if (producto != null)
                {
                    producto.Status = 0;
                    db.Entry(producto).CurrentValues.SetValues(producto);
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
    }
}
