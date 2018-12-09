using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_Searchfood.Controller
{
    public class BuscadorController
    {
        public List<Logica.Models.clstbRestaurante> getBuquedadRestController(string datoBus)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsBuscador obclsBuscador = new Logica.BL.clsBuscador();
                return obclsBuscador.getBuquedadRest(datoBus);

            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public List<Logica.Models.clstbRestaurante> getBuquedadRestControllerUnico(string datoBus)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsBuscador obclsBuscador = new Logica.BL.clsBuscador();
                return obclsBuscador.getBuquedadRestUnico(datoBus);

            }
            catch (Exception e)
            {

                throw e;
            }


        }

    }
}