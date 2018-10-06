using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PI_Searchfood.Controller
{
    public class AdministrarComidaController
    {
        //RETORNA CONSULTA
        public List<Logica.Models.clstbComida> getComidaController() {
            try
            {
                wsServicios.wsServicios obwsServicios = new wsServicios.wsServicios();
                string json = obwsServicios.getComida();
                List<Logica.Models.clstbComida> lstclstbComidas = 
                JsonConvert.DeserializeObject<List <Logica.Models.clstbComida>>(json);
                return lstclstbComidas;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public object getComidaController_XML()
        {
            try
            {
                wsServicios.wsServicios obwsServicios = new wsServicios.wsServicios();
                var lstclstbComidas = obwsServicios.getComida_XML();
                return lstclstbComidas;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}