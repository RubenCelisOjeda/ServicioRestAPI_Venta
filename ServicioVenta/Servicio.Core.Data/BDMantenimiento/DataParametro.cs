using Servicio.Core.Data.BDTablas;
using Servicio.Core.Data.Interfaces;
using Servicio.Core.Entity.DTO.Parametro;
using System.Collections.Generic;
using System.Linq;

namespace Servicio.Core.Data.BDMantenimiento
{
    public class DataParametro : IDataParametro
    {
        #region Get
        /// <summary>
        /// Listar los campos basicos de parametro, esto se vera en la grilla principal
        /// </summary>s
        /// <returns>retorno todos lo datos primeros parametro encontradas.</returns>
        /// 
        public IList<DtoParametroGrilla> Get(int pId)
        {
            List<DtoParametroGrilla> ListadoDTO = new List<DtoParametroGrilla>();

            using (var db = new BD_SistemaVentaContext())
            {
                var listado = db.Parametros.Where(x => x.Id == pId)
                    .Select(x => new
                    {
                        Id = x.Id,
                        NroGrupo = x.NroGrupo,
                        Nombre = x.Nombre,
                        Valor1 = x.Valor1,
                        Valor2 = x.Valor2,
                        Valor3 = x.Valor3,
                        Estado = x.Estado

                    }).ToList()

                    .Select(x => new DtoParametroGrilla()
                    {
                        Id = x.Id,
                        NroGrupo = x.NroGrupo,
                        Nombre = x.Nombre,
                        Valor1 = x.Valor1,
                        Valor2 = x.Valor2,
                        Valor3 = x.Valor3,
                        Estado = x.Estado
                    });

                ListadoDTO = listado.ToList();
            }

            return ListadoDTO;
        }
        #endregion

        #region Get / Id / NroGrupo / PrevaleGrupo
        /// <summary>
        /// Listar los campos basicos de parametro, esto se vera en la grilla principal
        /// </summary>s
        /// <returns>retorno todos lo datos primeros parametro encontradas.</returns>
        /// 
        public IList<DtoParametroGrilla> Get(int pId, int pNroGrupo, bool pPrevaleGrupo = true)
        {
            IList<DtoParametroGrilla> ListadoDTO = new List<DtoParametroGrilla>();

            if (pPrevaleGrupo)
            {
                using (var db = new BD_SistemaVentaContext())
                {
                    var listado = db.Parametros.Where(x => x.NroGrupo == pNroGrupo)
                        .Select(x => new
                        {
                            Id = x.Id,
                            NroGrupo = x.NroGrupo,
                            Nombre = x.Nombre,
                            Valor1 = x.Valor1,
                            Valor2 = x.Valor2,
                            Valor3 = x.Valor3,
                            Estado = x.Estado

                        }).ToList()

                        .Select(x => new DtoParametroGrilla()
                        {
                            Id = x.Id,
                            NroGrupo = x.NroGrupo,
                            Nombre = x.Nombre,
                            Valor1 = x.Valor1,
                            Valor2 = x.Valor2,
                            Valor3 = x.Valor3,
                            Estado = x.Estado
                        });

                    ListadoDTO = listado.ToList();
                }
            }
            else
            {
                ListadoDTO = Get(pId);
            }

            return ListadoDTO;
        }
        #endregion
    }
}
