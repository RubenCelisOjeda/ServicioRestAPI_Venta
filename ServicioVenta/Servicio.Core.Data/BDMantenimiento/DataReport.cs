using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO;
using Servicio.Core.Entity.DTO.Report;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataReport : IDataReport
    {
        private string _querySql = string.Empty;

        #region GetRpt / Id
        /// <summary>
        /// Devuelve los ventas con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <param name="pIdVenta">ID de la venta registrado</param>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoRptVenta> GetRptVenta(int pIdVenta)
        {
            IList<DtoRptVenta> ListadoDTO = null;

            using (var db = new BD_SistemaVentaContext())
            {
                var dtoRpt = (from tblCLiente in db.Cliente
                              join tblVenta in db.Venta on tblCLiente.Id equals tblVenta.ClienteId
                              join tblConceptoVenta in db.ConceptoVenta on tblVenta.Id equals tblConceptoVenta.VentaId
                              where tblConceptoVenta.VentaId == pIdVenta && tblVenta.Status == 1
                              select new DtoRptVenta
                              {
                                  Id = tblCLiente.Id,
                                  NombreCliente = tblCLiente.Nombres,
                                  ApellidosCliente = tblCLiente.ApellidoMaterno + tblCLiente.ApellidoPaterno,
                                  Dni = tblCLiente.Dni,
                                  Total = tblVenta.Total,
                                  FechaVenta = tblVenta.Fecha,
                                  Producto = tblConceptoVenta.Producto.Nombre,
                                  Cantidad = tblConceptoVenta.Cantidad,
                                  PrecioUnitario = tblConceptoVenta.PrecioUnitario,
                                  Importe = tblConceptoVenta.Importe

                              }).ToList();

                ListadoDTO = dtoRpt;
            }
            return ListadoDTO;
        }
        #endregion

        #region GetRpt Ventas de hoy
        /// <summary>
        /// Devuelve los ventas del dia de hoy con el ID proporcionado. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoRptVentasHoy> GetRptVentasHoy()
        {
            IList<DtoRptVentasHoy> ListadoDTO = null;
            DateTime dateTime = DateTime.Now;
          
            using (var db = new BD_SistemaVentaContext())
            {
                 var dtoRpt = (from tblCLiente in db.Cliente
                              join tblVenta in db.Venta on tblCLiente.Id equals tblVenta.ClienteId
                              join tblConceptoVenta in db.ConceptoVenta on tblVenta.Id equals tblConceptoVenta.VentaId
                              where tblVenta.Fecha.Value.Day == dateTime.Day && 
                                    tblVenta.Fecha.Value.Month == dateTime.Month &&
                                    tblVenta.Fecha.Value.Year == dateTime.Year &&
                                    tblVenta.Status == 1 

                               select new DtoRptVentasHoy
                              {
                                  Id = tblCLiente.Id,
                                  NombreCliente = tblCLiente.Nombres,
                                  ApellidosCliente = tblCLiente.ApellidoMaterno + tblCLiente.ApellidoPaterno,
                                  Dni = tblCLiente.Dni,
                                  Total = tblVenta.Total,
                                  FechaVenta = tblVenta.Fecha,
                                  Producto = tblConceptoVenta.Producto.Nombre,
                                  Cantidad = tblConceptoVenta.Cantidad,
                                  PrecioUnitario = tblConceptoVenta.PrecioUnitario,
                                  Importe = tblConceptoVenta.Importe

                              }).ToList();

                ListadoDTO = dtoRpt;
            }
            return ListadoDTO;
        }
        #endregion

        #region GetRpt Ventas del mes
        /// <summary>
        /// Devuelve los ventas del mes actual. este se usará para cargar los datos y moficarlos segun cambie el asesor
        /// </summary>
        /// <returns>Retorna la lista con el ingreso que se encontro.</returns>
        public IList<DtoRptVentasPorMes> GetRptVentasPorMes()
        {
            IList<DtoRptVentasPorMes> ListadoDTO = null;
            DateTime dateTime = DateTime.Now;

            using (var db = new BD_SistemaVentaContext())
            {
                var dtoRpt = (from tblCLiente in db.Cliente
                              join tblVenta in db.Venta on tblCLiente.Id equals tblVenta.ClienteId
                              join tblConceptoVenta in db.ConceptoVenta on tblVenta.Id equals tblConceptoVenta.VentaId
                              where tblVenta.Fecha.Value.Year == dateTime.Year && 
                                    tblVenta.Fecha.Value.Month == dateTime.Month &&
                                    tblVenta.Status == 1

                              select new DtoRptVentasPorMes
                              {
                                  Id = tblCLiente.Id,
                                  NombreCliente = tblCLiente.Nombres,
                                  ApellidosCliente = tblCLiente.ApellidoMaterno + tblCLiente.ApellidoPaterno,
                                  Dni = tblCLiente.Dni,
                                  Total = tblVenta.Total,
                                  FechaVenta = tblVenta.Fecha,
                                  Producto = tblConceptoVenta.Producto.Nombre,
                                  Cantidad = tblConceptoVenta.Cantidad,
                                  PrecioUnitario = tblConceptoVenta.PrecioUnitario,
                                  Importe = tblConceptoVenta.Importe

                              }).ToList();

                ListadoDTO = dtoRpt;
            }
            return ListadoDTO;
        }
        #endregion

        #region GetRpt producto mas vendido
        /// <summary>
        /// Devuelve el producto mas vendidos. este se usará para mostrar en el reporte
        /// </summary>
        /// <returns>Retorna la el producto mas vendido.</returns>
        public DtoRptProductoMasVendido GetRptProductoMasVendido()
        {
            DtoRptProductoMasVendido dtoProductoMasVendido = null;

            _querySql = @"SELECT TOP(1) 
	                             ProductoId, 
                                 T2.Nombre,
	                             SUM(Cantidad) AS Cantidad
	   
                        FROM ConceptoVenta T1 INNER JOIN Producto T2 ON T1.ProductoId = T2.Id
                        WHERE T2.Status = 1
                        GROUP BY ProductoId,T2.Nombre
                        ORDER BY Cantidad DESC";

            using (var db = new BD_SistemaVentaContext())
            {
                using (var cn = new SqlConnection(db.Database.GetDbConnection().ConnectionString))
                {
                    using (var cmd = new SqlCommand(_querySql, cn))
                    { 
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = _querySql;
                        cmd.Connection.Open();

                        using (var result = cmd.ExecuteReader())
                        {
                            while (result.Read())
                            {
                                dtoProductoMasVendido = new DtoRptProductoMasVendido()
                                {
                                    Id = result.GetInt32(0),
                                    Producto = result.GetString(1),
                                    TotalCantidad = result.GetInt32(2)
                                };
                            }
                        }
                    }
                }
            }
            return dtoProductoMasVendido;
        }
        #endregion

        #region GetRpt producto menos vendido
        /// <summary>
        /// Devuelve el producto menos vendido. este se usará para mostrar en el reporte
        /// </summary>
        /// <returns>Retorna la el producto mas vendido.</returns>
        public DtoRptProductoMenosVendido GetRptProductoMenosVendido()
        {
            DtoRptProductoMenosVendido dtoProductoMasVendido = null;

            _querySql = @"SELECT  TOP(01)
                                  ProductoId, 
                                  T2.Nombre,
	                              SUM(Cantidad) AS Cantidad
	   
                        FROM ConceptoVenta T1 INNER JOIN Producto T2 ON T1.ProductoId = T2.Id
                        WHERE T2.Status = 1
                        GROUP BY ProductoId,T2.Nombre
                        ORDER BY Cantidad ASC";

            using (var db = new BD_SistemaVentaContext())
            {
                using (var cn = new SqlConnection(db.Database.GetDbConnection().ConnectionString))
                {
                    using (var cmd = new SqlCommand(_querySql, cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = _querySql;
                        cmd.Connection.Open();

                        using (var result = cmd.ExecuteReader())
                        {
                            while (result.Read())
                            {
                                dtoProductoMasVendido = new DtoRptProductoMenosVendido()
                                {
                                    Id = result.GetInt32(0),
                                    Producto = result.GetString(1),
                                    TotalCantidad = result.GetInt32(2)
                                };
                            }
                        }
                    }
                }
            }
            return dtoProductoMasVendido;
        }
        #endregion
    }
}
