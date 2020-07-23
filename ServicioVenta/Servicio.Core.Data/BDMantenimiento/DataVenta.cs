using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataVenta : IDataVenta
    {
        #region Get
        /// <summary>
        /// Listar los campos basicos de ventas, esto se vera en la grilla principal
        /// </summary>s
        /// <returns>retorno todos lo datos primeros usuarios encontradas.</returns>
        public IList<DtoVentaGrilla> Get()
        {
            List<DtoVentaGrilla> ListadoDTO = new List<DtoVentaGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Venta.Include(v => v.Cliente).Include(c => c.ConceptoVenta).Where(v => v.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Total = x.Total,
                        Fecha = x.Fecha,
                        Cliente = x.Cliente.Nombres + " " + x.Cliente.ApellidoPaterno + " " + x.Cliente.ApellidoMaterno,
                    
                    }).ToList()

                    .Select(x => new DtoVentaGrilla()
                    {
                        Id = x.Id,
                        Total = x.Total,
                        Fecha = x.Fecha.ToString(),
                        Cliente = x.Cliente
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / Id
        /// <summary>
        /// Devuelve los ventas con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID de la venta registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoVenta> Get(int pId)
        {
            List<DtoVenta> ListadoDTO = new List<DtoVenta>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Venta.Where(x => x.Id == pId && x.Status == 1).Include(c => c.Cliente)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Total = x.Total,
                        Fecha = x.Fecha,
                        ClienteId = x.ClienteId,

                    }).ToList()

                    .Select(x => new DtoVenta()
                    {
                        Id = x.Id,
                        Total = x.Total,
                        Fecha = x.Fecha,
                        ClienteId = x.ClienteId,
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / pValor
        /// <summary>
        /// Funcion que permite listar las ventas con el valor ingresado
        /// </summary>
        /// <param name="pValor">valor de la venta que se va a buscar</param>
        /// <returns>Retorna la lista con las ventas encontrados con el valor ingresado.</returns>
        public IList<DtoVentaGrilla> Get(string pValor)
        {
            List<DtoVentaGrilla> ListadoDTO = new List<DtoVentaGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Venta.Where(x => EF.Functions.Like(x.Cliente.Nombres, "%" + pValor + "%")).Include(c => c.Cliente)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Total = x.Total,
                        Fecha = x.Fecha,
                        Cliente = x.Cliente.Nombres + " " + x.Cliente.ApellidoPaterno + " " + x.Cliente.ApellidoMaterno

                    }).ToList()

                    .Select(x => new DtoVentaGrilla()
                    {
                        Id = x.Id,
                        Total = x.Total,
                        Fecha = x.Fecha.ToString(),
                        Cliente = x.Cliente
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Post / Put
        /// <summary>   
        /// Permite Guardar el registro de la venta en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores de la venta que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public DtoVenta Post(DtoVenta pEntidad)
        {
            DtoVenta DtoVenta = new DtoVenta();
            int idVenta = 0;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                   
                    var venta = new BDTablas.Venta()
                    {
                        Id = pEntidad.Id,
                        Total = pEntidad.Total,
                        Fecha = pEntidad.Fecha,
                        ClienteId = pEntidad.ClienteId,
                        Status = 1
                    };
                    if (venta.Id == 0)
                    {
                        db.Venta.Add(venta);
                    }
                    else
                    {
                        db.Entry(venta).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    idVenta = venta.Id;
                }
            }

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad.DtoConceptoVenta != null)
                {
                    foreach (var item in pEntidad.DtoConceptoVenta)
                    {
                        var conceptVenta = new BDTablas.ConceptoVenta()
                        {
                            Id = item.Id,
                            VentaId = idVenta,
                            ProductoId = item.ProductoId,
                            UsuarioId = item.UsuarioId,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUnitario,
                            Importe = item.Importe,
                            Status = 1
                        };

                        if (conceptVenta.Id == 0)
                        {
                            db.ConceptoVenta.Add(conceptVenta);
                        }
                        else
                        {
                            db.Entry(conceptVenta).State = EntityState.Modified;
                        }
                        db.SaveChanges();
                    }
                }
            }
            DtoVenta.Id = idVenta;

            return DtoVenta;
        }
        #endregion

        #region Delete / Id
        /// <summary>
        /// Elimina logicamente el registro de la venta en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID de la venta registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Delete(int pId)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var data = db.ConceptoVenta.Where(c => c.VentaId == pId).ToList();
                foreach (var item in data)
                {
                    var producto = db.Producto.Find(item.ProductoId);
                    producto.Stock += item.Cantidad;
                    db.Entry(producto).CurrentValues.SetValues(producto);
                    db.SaveChanges();
                }
            }

            using (var db = new BD_SistemaVentaContext())
            {
                var venta = db.Venta.Find(pId);
                if (venta != null)
                {
                    venta.Status = 0;
                    db.Entry(venta).CurrentValues.SetValues(venta);
                    db.SaveChanges();
                }
                IsValid = true;
            }
           
            return IsValid;
        }
        #endregion

        #region Existe / Id
        /// <summary>
        /// Valida la existencia del registro de la venta en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID de la venta registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Existe(int pId)
        {
            bool Existe = false;

            using (var db = new BD_SistemaVentaContext())
            {
                Existe = db.Venta.Any(x => x.Id == pId);

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
