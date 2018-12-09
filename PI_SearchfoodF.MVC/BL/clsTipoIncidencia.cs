using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_SearchfoodF.MVC.BL
{
    public class clsTipoIncidencia
    {
        /// <summary>
        /// OBTIENE LOS REGISTROS DE TIPO INCIDENCIA
        /// </summary>
        /// <returns>LISTA DE MODELOS DE TIPO INCIDENCIA</returns>
        public List<Models.TipoIncidencia> GetTipoIncidencia()
        {
            try
            {
                using (DAL.BD_SEARCHFOODEntities obDatos = new DAL.BD_SEARCHFOODEntities())
                {
                    List<Models.TipoIncidencia> tipo_incidencia = new List<Models.TipoIncidencia>();
                    tipo_incidencia = (from q in obDatos.tbTipoIncidencia
                                       select new Models.TipoIncidencia
                                       {
                                           Id = q.Id_TipoIncidencia,
                                           Descripcion = q.TipoInDescripcion
                                       }).ToList();

                    return tipo_incidencia;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}