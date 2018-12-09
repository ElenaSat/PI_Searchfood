using System;
using System.Collections.Generic;
using System.Linq;

namespace PI_Searchfood.Logica.BL
{
    public class clsComida
    {
        public List<Models.clstbComida> getComida()
        {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obDatos = new Entidades.BD_SEARCHFOODEntities1())
                {

                    List<Models.clstbComida> lstclstbComida = (from q in obDatos.tbComida
                                                               join tbCate in obDatos.tbCategorias on q.cateCodigo equals tbCate.cateCodigo
                                                               select new Models.clstbComida
                                                               {
                                                                   longcomiCodigo = (long)q.comiCodigo,
                                                                   loncomiValor = (long)q.comiValor,
                                                                   obclstbCategoria = new Models.clstbCategoria {
                                                                       longcateCodigo = (long)q.cateCodigo,
                                                                       strcateDescripcion = tbCate.cateDescripcion
                                                                   },
                                                                   obclstbRestaurante = new Models.clstbRestaurante {
                                                                       longrestCodigo = (long)q.restcodigo
                                                                   },
                                                                   strcomiDescripcion = q.comiDescripcion,
                                                                   strcomiRutaImagen = q.comiRutaImagen
                                                               }).ToList();
                    return lstclstbComida;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        public List<Models.clstbComida> getConsultarComida(string stNombreCompleto)
        {

            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obDatos = new Entidades.BD_SEARCHFOODEntities1())
                {

                    List<Models.clstbComida> lstclstbComida = (from q in obDatos.tbComida
                                                               where (q.comiCodigo + " " +q.comiDescripcion).Contains(stNombreCompleto)
                                                               select new Models.clstbComida
                                                               {
                                                                   longcomiCodigo = (long)q.comiCodigo,
                                                                   loncomiValor = (long)q.comiValor,
                                                                   obclstbCategoria = new Models.clstbCategoria
                                                                   {
                                                                       longcateCodigo = (long)q.cateCodigo,
                                                                       strcateDescripcion = q.tbCategorias.cateDescripcion
                                                                   },
                                                                   obclstbRestaurante = new Models.clstbRestaurante
                                                                   {
                                                                       longrestCodigo = (long)q.restcodigo
                                                                   },
                                                                   strcomiDescripcion = q.comiDescripcion,
                                                                   strcomiRutaImagen = q.comiRutaImagen
                                                               }
                                                               ).ToList();
                    return lstclstbComida;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        public void createComida(Models.clstbComida obclstbComida) {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obDatos = new Entidades.BD_SEARCHFOODEntities1()) {

                    obDatos.tbComida.Add(new Entidades.tbComida {
                        cateCodigo = obclstbComida.obclstbCategoria.longcateCodigo,
                        restcodigo = obclstbComida.obclstbRestaurante.longrestCodigo,
                        comiValor = obclstbComida.loncomiValor,
                        comiDescripcion = obclstbComida.strcomiDescripcion,
                        comiRutaImagen = obclstbComida.strcomiRutaImagen
                    });
                    obDatos.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string updateComida(Models.clstbComida obclstbComida)
        {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obBD_SEARCHFOODEntities = new Entidades.BD_SEARCHFOODEntities1())
                {

                    Entidades.tbComida obtbComida = (from q in obBD_SEARCHFOODEntities.tbComida
                                                     where q.comiCodigo == obclstbComida.longcomiCodigo
                                                     select q).FirstOrDefault();

                    obtbComida.tbCategorias.cateCodigo = obclstbComida.obclstbCategoria.longcateCodigo;
                    obtbComida.comiValor = obclstbComida.loncomiValor;
                    obtbComida.comiDescripcion = obclstbComida.strcomiDescripcion;
                    obtbComida.comiRutaImagen = obclstbComida.strcomiRutaImagen;

                    obBD_SEARCHFOODEntities.SaveChanges();

                    return "Se realizo los cambios con exito";
                }


            }
            catch (Exception ex) { throw ex; }


        }

        public string deleteComida(Models.clstbComida obclstbComida)
        {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obBD_SEARCHFOODEntities = new Entidades.BD_SEARCHFOODEntities1())
                {

                    Entidades.tbComida obtbComida = (from q in obBD_SEARCHFOODEntities.tbComida
                                                     where q.comiCodigo == obclstbComida.longcomiCodigo
                                                     select q).FirstOrDefault();

                    obBD_SEARCHFOODEntities.tbComida.Remove(obtbComida);
                    obBD_SEARCHFOODEntities.SaveChanges();

                    return "Se realizo el proceso con exito";
                }


            }
            catch (Exception ex) { throw ex; }


        }

        public List<Models.clstbCategoria> GetCategorias() {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obDatos = new Entidades.BD_SEARCHFOODEntities1())
                {

                    List<Models.clstbCategoria> lstbCategorias = (from q in obDatos.tbCategorias
                                                                  select new Models.clstbCategoria {
                                                                      longcateCodigo = (long)q.cateCodigo,
                                                                      strcateDescripcion = q.cateDescripcion
                                                                  }).ToList();
                    return lstbCategorias;
                }
            }
            catch (Exception exe)
            {

                throw exe;
            }
        }


       
    }
}
