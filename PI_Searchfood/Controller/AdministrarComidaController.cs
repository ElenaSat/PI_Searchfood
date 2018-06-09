using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_Searchfood.Controller
{
    public class AdministrarComidaController
    {
        public List<Logica.Models.clstbComida> getConsultarAdministrarComidaController()
        {
            try
            {
                PI_Searchfood.Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
                return obclsComida.getComida();

            }
            catch (Exception ex) { throw ex; }
        }

        public string addOpcionController(Logica.Models.clstbComida obclstbComida)
        {

            PI_Searchfood.Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            return obclsComida.addNombreOpcion(obclstbComida);

        }

        public string deleteOpcionController(Logica.Models.clstbComida obclstbComida)
        {

            PI_Searchfood.Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            return obclsComida.deleteNombreOpcion(obclstbComida);

        }
        public string updateOpcionController(Logica.Models.clstbComida obclstbComida)
        {

            PI_Searchfood.Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            return obclsComida.updateNombreOpcion(obclstbComida);

        }

       
    }
}