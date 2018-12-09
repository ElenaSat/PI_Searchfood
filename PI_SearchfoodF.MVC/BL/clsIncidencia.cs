using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_SearchfoodF.MVC.BL
{
    public class clsIncidencia
    {
        public List<Models.Incidencia> GetIncidencias()
        {
            try
            {
                using (var db = new DAL.BD_SEARCHFOODEntities())
                {
                    var result = (from q in db.tbIncidencia
                                  join tbEI in db.tbEstado_Incidencia on q.Id equals tbEI.Id_EstdIncidencia
                                  join tbTI in db.tbTipoIncidencia on q.Id equals tbTI.Id_TipoIncidencia
                                  select new Models.Incidencia
                                  {
                                      Id = q.Id,
                                      Identificacion = (long)q.Identificacion,
                                      PrimerNombre = q.primer_nombre,
                                      SegundoNombre = q.segundo_nombrre,
                                      PrimerApellido = q.primer_apellido,
                                      SegundoApellido = q.segundo_apellido,
                                      Direccion = q.direccion,
                                      Telefono = q.telefono,
                                      Correo = q.correo,
                                      EstadoIncidencia = new Models.tbEstadoIncidencia
                                      {
                                          Id_EstdIncidencia = (int)q.Estado_Indicencia,
                                          EstdDescripcion = tbEI.EstdDescripcion                                      },
                                      TipoIncidencia = new Models.TipoIncidencia
                                      {
                                          Id = (int)q.Tipo_Incidencia,
                                          Descripcion = tbTI.TipoInDescripcion
                                      }
                                  }).ToList();

                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Models.Incidencia> GetIncidencias(int Id)
        {
            try
            {
                using (var db = new DAL.BD_SEARCHFOODEntities())
                {
                    var result = (from q in db.tbIncidencia
                                  join tbEI in db.tbEstado_Incidencia on q.Id equals tbEI.Id_EstdIncidencia
                                  join tbTI in db.tbTipoIncidencia on q.Id equals tbTI.Id_TipoIncidencia
                                  where q.Id == Id
                                  select new Models.Incidencia
                                  {
                                      Id = q.Id,
                                      Identificacion = (long)q.Identificacion,
                                      PrimerNombre = q.primer_nombre,
                                      SegundoNombre = q.segundo_nombrre,
                                      PrimerApellido = q.primer_apellido,
                                      SegundoApellido = q.segundo_apellido,
                                      Direccion = q.direccion,
                                      Telefono = q.telefono,
                                      Correo = q.correo,
                                      EstadoIncidencia = new Models.tbEstadoIncidencia
                                      {
                                          Id_EstdIncidencia = (int)q.Estado_Indicencia,
                                          EstdDescripcion = tbEI.EstdDescripcion
                                      },
                                      TipoIncidencia = new Models.TipoIncidencia
                                      {
                                          Id = (int)q.Tipo_Incidencia,
                                          Descripcion = tbTI.TipoInDescripcion
                                      }
                                  }).ToList();

                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void CreateIncidencia(Models.Incidencia incidencia)
        {
            try
            {
                using (var db = new DAL.BD_SEARCHFOODEntities())
                {
                    db.tbIncidencia.Add(new DAL.tbIncidencia
                    {
                       Id= incidencia.Id,
                        primer_nombre = incidencia.PrimerNombre,
                        segundo_nombrre = incidencia.SegundoNombre,
                        primer_apellido = incidencia.PrimerApellido,
                        segundo_apellido = incidencia.SegundoApellido,
                        direccion = incidencia.Direccion,
                        telefono = incidencia.Telefono,
                        correo = incidencia.Correo,
                        Estado_Indicencia = incidencia.EstadoIncidencia.Id_EstdIncidencia,
                        Tipo_Incidencia = incidencia.TipoIncidencia.Id
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}