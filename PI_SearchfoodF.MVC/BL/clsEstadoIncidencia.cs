using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_SearchfoodF.MVC.BL
{
       public class clsEstadoIncidencia
    {
        /// <summary>
        /// OBTIENE LOS REGISTROS DE ESTADO INCIDENCIA
        /// </summary>
        /// <returns>LISTA DE MODELOS DE ESTADO INCIDENCIA</returns>
        public List<Models.tbEstadoIncidencia> GetEstadoIncidencia()
        {
            try
            {
                using (DAL.BD_SEARCHFOODEntities obDatos = new DAL.BD_SEARCHFOODEntities())
                {
                    List<Models.tbEstadoIncidencia> estado_incidencia = new List<Models.tbEstadoIncidencia>();
                    estado_incidencia = (from q in obDatos.tbEstado_Incidencia
                                         select new Models.tbEstadoIncidencia
                                         {
                                             Id_EstdIncidencia = q.Id_EstdIncidencia,
                                             EstdDescripcion = q.EstdDescripcion
                                         }).ToList();

                    return estado_incidencia;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// OBTIENE LOS REGISTROS DE ESTADO INCIDENCIA
        /// </summary>
        /// <returns>LISTA DE MODELOS DE ESTADO INCIDENCIA</returns>
        public List<Models.tbEstadoIncidencia> GetEstadoIncidencia(Models.tbEstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.BD_SEARCHFOODEntities obDatos = new DAL.BD_SEARCHFOODEntities())
                {
                    List<Models.tbEstadoIncidencia> estado_incidencia = new List<Models.tbEstadoIncidencia>();
                    estado_incidencia = (from q in obDatos.tbEstado_Incidencia
                                         where q.Id_EstdIncidencia == obEstadoIncidencia.Id_EstdIncidencia
                                         select new Models.tbEstadoIncidencia
                                         {
                                             Id_EstdIncidencia = q.Id_EstdIncidencia,
                                             EstdDescripcion = q.EstdDescripcion
                                         }).ToList();

                    return estado_incidencia;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// CREA REGISTRO DE ESTADO INCIDENCIA
        /// </summary>
        /// <param name="obEstadoIncidencia">MODELO DE ESTADO INCIDENCIA</param>
        public void CreateEstadoIncidencia(Models.tbEstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.BD_SEARCHFOODEntities obDatos = new DAL.BD_SEARCHFOODEntities())
                {
                    obDatos.tbEstado_Incidencia.Add(new DAL.tbEstado_Incidencia
                    {
                        EstdDescripcion = obEstadoIncidencia.EstdDescripcion
                    });
                    obDatos.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// MODIFICAR REGISTRO DE ESTADO INCIDENCIA
        /// </summary>
        /// <param name="obEstadoIncidencia">MODELO DE ESTADO INCIDENCIA</param>
        public void UpdateEstadoIncidencia(Models.tbEstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.BD_SEARCHFOODEntities obDatos = new DAL.BD_SEARCHFOODEntities())
                {
                    DAL.tbEstado_Incidencia estado_incidencia = new DAL.tbEstado_Incidencia();
                    estado_incidencia = (from q in obDatos.tbEstado_Incidencia
                                         where q.Id_EstdIncidencia == obEstadoIncidencia.Id_EstdIncidencia
                                         select q).FirstOrDefault();

                    estado_incidencia.EstdDescripcion = obEstadoIncidencia.EstdDescripcion;

                    obDatos.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// ELIMINAR REGISTRO DE ESTADO INCIDENCIA
        /// </summary>
        /// <param name="obEstadoIncidencia">MODELO DE ESTADO INCIDENCIA</param>
        public void DeleteEstadoIncidencia(Models.tbEstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.BD_SEARCHFOODEntities obDatos = new DAL.BD_SEARCHFOODEntities())
                {
                    DAL.tbEstado_Incidencia estado_incidencia = new DAL.tbEstado_Incidencia();
                    estado_incidencia = (from q in obDatos.tbEstado_Incidencia
                                         where q.Id_EstdIncidencia == obEstadoIncidencia.Id_EstdIncidencia
                                         select q).FirstOrDefault();

                    obDatos.tbEstado_Incidencia.Remove(estado_incidencia);
                    obDatos.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}