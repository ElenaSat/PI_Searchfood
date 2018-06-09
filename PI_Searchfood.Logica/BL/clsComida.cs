using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.BL
{
    public class clsComida
    {/// <summary>
     /// /Inserta Datos 
     /// </summary>
     /// <param name="obclstbComida"></param>
     /// <returns></returns>
        public string addNombreOpcion(Models.clstbComida obclstbComida)
        {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obBD_SEARCHFOODEntities = new Entidades.BD_SEARCHFOODEntities1())
                {

                    Entidades.tbComida obtbComida = new Entidades.tbComida
                    {
                        cateCodigo = obclstbComida.obclstbCategoria.longcateCodigo,
                        comiCodigo = obclstbComida.longcomiCodigo,
                        comiDescripcion = obclstbComida.strcomiDescripcion,
                        comiValor = obclstbComida.loncomiValor,
                        comiRutaImagen = obclstbComida.strcomiRutaImagen,
                        restcodigo = obclstbComida.obclstbRestaurante.longrestCodigo

                    };

                    obBD_SEARCHFOODEntities.tbComida.Add(obtbComida);
                    obBD_SEARCHFOODEntities.SaveChanges();
                    return "Se realizo proceso con exito";
                }


            }
            catch (Exception ex) { throw ex; }


        }
        /// <summary>
        /// Editar Datos
        /// </summary>
        /// <param name="obclstbComida"></param>
        /// <returns></returns>
        public string updateNombreOpcion(Models.clstbComida obclstbComida)
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
        /// <summary>
        /// Eliminar Datos
        /// </summary>
        /// <param name="obclstbComida"></param>
        /// <returns></returns>
        public string deleteNombreOpcion(Models.clstbComida obclstbComida)
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
        /// <summary>
        /// Buscar toda la comida
        /// </summary>
        /// <returns></returns>
        public List<Models.clstbComida> getComida()
        {
            try
            {

                using (Entidades.BD_SEARCHFOODEntities1 obBD_SEARCHFOODEntities = new Entidades.BD_SEARCHFOODEntities1())
                {
                    List<Models.clstbComida> lstclsComida = (from q in obBD_SEARCHFOODEntities.tbComida
                                                             join tbRT in  obBD_SEARCHFOODEntities.tbrestaurante on q.tbrestaurante.restCodigo equals tbRT.restCodigo
                                                             join tbCAT in obBD_SEARCHFOODEntities.tbCategorias on q.tbCategorias.cateCodigo equals tbCAT.cateCodigo
                                                             select new Models.clstbComida
                                                             {
                                                                 longcomiCodigo = Convert.ToInt64(q.comiCodigo),
                                                                 loncomiValor = Convert.ToInt64(q.comiValor),
                                                                 strcomiDescripcion = q.comiDescripcion,
                                                                 strcomiRutaImagen = q.comiRutaImagen,
                                                                 obclstbCategoria = new Models.clstbCategoria
                                                                 {
                                                                     longcateCodigo = Convert.ToInt64(q.tbCategorias.cateCodigo),
                                                                     strcateDescripcion=tbCAT.cateDescripcion
                                                                 },
                                                                 obclstbRestaurante = new Models.clstbRestaurante
                                                                 {
                                                                     longrestCodigo = Convert.ToInt64(q.tbrestaurante.restCodigo),
                                                                     strrestNombre=tbRT.restNombre
                                                                     
                                                                 }

                                                             }).ToList();
                    return lstclsComida;
                }
            }
            catch (Exception ex) { throw ex; }


        }
        /// <summary>
        /// Buscar la comida por codigo
        /// </summary>
        /// <param name="obclstbComidaF"></param>
        /// <returns></returns>
        public List<Models.clstbComida> getComida(Models.clstbComida obclstbComidaF)
        {
            try
            {

                using (Entidades.BD_SEARCHFOODEntities1 obBD_SEARCHFOODEntities = new Entidades.BD_SEARCHFOODEntities1())
                {
                    List<Models.clstbComida> lstclsComida = (from q in obBD_SEARCHFOODEntities.tbComida
                                                             join tbRT in obBD_SEARCHFOODEntities.tbrestaurante on q.tbrestaurante.restCodigo equals tbRT.restCodigo
                                                             join tbCAT in obBD_SEARCHFOODEntities.tbCategorias on q.tbCategorias.cateCodigo equals tbCAT.cateCodigo
                                                             where q.comiCodigo == obclstbComidaF.longcomiCodigo
                                                             select new Models.clstbComida
                                                             {
                                                                 longcomiCodigo = Convert.ToInt64(q.comiCodigo),
                                                                 loncomiValor = Convert.ToInt64(q.comiValor),
                                                                 strcomiDescripcion = q.comiDescripcion,
                                                                 strcomiRutaImagen = q.comiRutaImagen,
                                                                 obclstbCategoria = new Models.clstbCategoria
                                                                 {
                                                                     longcateCodigo = Convert.ToInt64(q.tbCategorias.cateCodigo),
                                                                     strcateDescripcion = tbCAT.cateDescripcion
                                                                 },
                                                                 obclstbRestaurante = new Models.clstbRestaurante
                                                                 {
                                                                     longrestCodigo = Convert.ToInt64(q.tbrestaurante.restCodigo),
                                                                     strrestNombre = tbRT.restNombre

                                                                 }

                                                             }).ToList();
                    return lstclsComida;
                }
            }
            catch (Exception ex) { throw ex; }


        }

       

    }
}
