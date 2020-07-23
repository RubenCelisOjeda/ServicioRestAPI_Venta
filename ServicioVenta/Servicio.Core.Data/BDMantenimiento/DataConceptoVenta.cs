using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataConceptoVenta : IDataConceptoVenta
    {
        #region Get
        /// <summary>
        /// Listar los campos basicos de concepto de venta, esto se vera en la grilla principal
        /// </summary>s
        /// <returns>retorno todos lo datos primeros conceptos de venta encontradas.</returns>
        public IList<DtoConceptoVentaGrilla> Get()
        {
            List<DtoConceptoVentaGrilla> ListadoDTO = new List<DtoConceptoVentaGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.ConceptoVenta.Include(p => p.Producto).Include(v => v.Venta).Where(c => c.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Producto = x.Producto.Nombre,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe,
                        TotalVenta = x.Venta.Total

                    }).ToList()

                    .Select(x => new DtoConceptoVentaGrilla()
                    {
                        Id = x.Id,
                        Producto = x.Producto,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe,
                        TotalVenta = x.TotalVenta
                    });
                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / Id
        /// <summary>
        /// Devuelve los conceptos basicos con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del concepto venta registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoConceptoVentaResponse> Get(int pId)
        {
            List<DtoConceptoVentaResponse> ListadoDTO = new List<DtoConceptoVentaResponse>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.ConceptoVenta.Where(x => x.Id == pId).Include(c => c.Venta.Cliente)
                    .Select(x => new
                    {
                        Id = x.Id,
                        ProductoId = x.ProductoId,
                        ClienteId = x.Venta.ClienteId,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe

                    }).ToList()

                    .Select(x => new DtoConceptoVentaResponse()
                    {
                        Id = x.Id,
                        ProductoId = x.ProductoId,
                        ClienteId = x.ClienteId,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe
                    });
                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region GetAllByVentaId
        /// <summary>
        /// Devuelve los conceptos basicos con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del concepto venta registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoConceptoVentaDetails> GetAllByVentaId(int pId = 0)
        {
            List<DtoConceptoVentaDetails> ListadoDTO = new List<DtoConceptoVentaDetails>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.ConceptoVenta.Where(x => x.VentaId == pId && x.Status == 1).Include(v => v.Venta)
                    .Select(x => new
                    {
                        Id = x.Id,
                        VentaId = x.VentaId,
                        Producto = x.Producto.Nombre,
                        Cliente = x.Venta.Cliente.Nombres,
                        PrecioUnitario = x.PrecioUnitario,
                        Cantidad = x.Cantidad,
                        Importe = x.Importe,
                        Total = x.Venta.Total

                    }).ToList()

                    .Select(x => new DtoConceptoVentaDetails()
                    {
                        Id = x.Id,
                        VentaId = x.VentaId,
                        Producto = x.Producto,
                        Cliente = x.Cliente,
                        PrecioUnitario = x.PrecioUnitario,
                        Cantidad = x.Cantidad,
                        Importe = x.Importe,
                        Total = x.Total
                    });
                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / IdVenta
        /// <summary>
        /// Devuelve los conceptos basicos con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pId">ID del concepto venta registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoConceptoVentaGrilla> GetByVenta(int pIdVenta = 0)
        {
            List<DtoConceptoVentaGrilla> ListadoDTO = new List<DtoConceptoVentaGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.ConceptoVenta.Where(x => x.VentaId == pIdVenta && x.Status == 1).Include(p => p.Producto).Include(v => v.Venta)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Producto = x.Producto.Nombre,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe,
                        TotalVenta = x.Venta.Total

                    }).ToList()

                    .Select(x => new DtoConceptoVentaGrilla()
                    {
                        Id = x.Id,
                        Producto = x.Producto,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe,
                        TotalVenta = x.TotalVenta
                    });
                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Get / pValor
        /// <summary>
        /// Funcion que permite listar los conceptos de venta con el valor ingresado
        /// </summary>
        /// <param name="pValor">valor del concepto de venta que se va a buscar</param>
        /// <returns>Retorna la lista con los conceptos de venta encontrados con el valor ingresado.</returns>
        public IList<DtoConceptoVentaGrilla> Get(string pValor = "%")
        {
            List<DtoConceptoVentaGrilla> ListadoDTO = new List<DtoConceptoVentaGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.ConceptoVenta.Where(x => EF.Functions.Like(x.Producto.Nombre, "%" + pValor + "%") && x.Status == 1)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Producto = x.Producto.Nombre,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe,
                        TotalVenta = x.Venta.Total

                    }).ToList()

                    .Select(x => new DtoConceptoVentaGrilla()
                    {
                        Id = x.Id,
                        Producto = x.Producto,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Importe = x.Importe,
                        TotalVenta = x.TotalVenta
                    });

                ListadoDTO = listado.ToList();
            }
            return ListadoDTO;
        }
        #endregion

        #region Post / Put
        /// <summary>
        /// Permite Guardar el registro del concepto de venta en la base de datos.
        /// </summary>
        /// <param name="pEntidad">Entidad con los valores del concepto de venta que se guardara.</param>
        /// <returns>Retorna TRUE si el guardado en la BD tuvo exito.</returns>
        public bool Post(DtoConceptoVenta pEntidad = null)
        {
            bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                if (pEntidad != null)
                {
                    var conceptoVenta = new BDTablas.ConceptoVenta()
                    {
                        Id = pEntidad.Id,
                        VentaId = pEntidad.VentaId,
                        ProductoId = pEntidad.ProductoId,
                        UsuarioId = pEntidad.UsuarioId,
                        Cantidad = pEntidad.Cantidad,
                        PrecioUnitario = pEntidad.PrecioUnitario,
                        Importe = pEntidad.Importe,
                        Status = 1

                    };

                    if (conceptoVenta.Id == 0)
                    {
                        db.ConceptoVenta.Add(conceptoVenta);
                    }
                    else
                    {
                        db.Entry(conceptoVenta).State = EntityState.Modified;
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
        /// Elimina logicamente el registro de concepto de venta en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID de concepto de venta registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Delete(int pId = 0)
        {
             bool IsValid = false;

            using (var db = new BD_SistemaVentaContext())
            {
                var conceptoVenta = db.ConceptoVenta.Find(pId);

                if (conceptoVenta != null)
                {
                    conceptoVenta.Status = 0;
                    db.Entry(conceptoVenta).CurrentValues.SetValues(conceptoVenta);
                    db.SaveChanges();
                }
                IsValid = true;
            }
            return IsValid;
        }
        #endregion

        #region Existe / Id
        /// <summary>
        /// Valida la existencia del registro de concepto de venta en la Base de datos.
        /// </summary>
        /// <param name="pId">Numero de ID de concepto de venta registrada que se eliminara</param>
        /// <returns>Retorna TRUE si la eliminacion tuvo exito.</returns>
        public bool Existe(int pId = 0)
        {
            bool Existe = false;

            using (var db = new BD_SistemaVentaContext())
            {
                Existe = db.ConceptoVenta.Any(x => x.Id == pId);

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
