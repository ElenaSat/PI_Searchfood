using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.BL
{
    public class clsCategoria
    {
        public List<Models.clstbCategoria> getCategorias() {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obDatos = new Entidades.BD_SEARCHFOODEntities1()) {

                    List<Models.clstbCategoria> lstclstbCategorias = (from q in obDatos.tbCategorias
                                                                      select new Models.clstbCategoria
                                                                      {
                                                                          longcateCodigo= (long) q.cateCodigo,
                                                                          strcateDescripcion=q.cateDescripcion
                                                                     }).ToList();
                         return lstclstbCategorias;
                }

            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }


        } 
    }
}
