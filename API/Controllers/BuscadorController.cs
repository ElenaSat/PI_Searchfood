using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace API.Controllers
{
    public class BuscadorController : ApiController
    {
        [HttpGet]
        [ActionName("TraerBuscador")]
        public HttpResponseMessage GetcargarRestaurantes(string valor)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsBuscador clsBuscador = new   PI_Searchfood.Logica.BL.clsBuscador();//Ir a la clase

                List<PI_Searchfood.Logica.Models.clstbRestaurante> listRest = clsBuscador.getBuquedadRest(valor);//Pasa el valor

                string json_response = JsonConvert.SerializeObject(listRest);//Jeason Lista de Restaurantes

                var ret = Request.CreateResponse(HttpStatusCode.OK);

                ret.Content = new StringContent(json_response, Encoding.UTF8, "apllication/json");
                return ret;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        [HttpPost]
        [ActionName("TraerUsuario")]
        public HttpResponseMessage GetcargarUsuario(PI_Searchfood.Logica.Models.clstbPersona obclstbPersona)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsBuscador clsUsuarios = new PI_Searchfood.Logica.BL.clsBuscador();//Ir a la clase

                List<PI_Searchfood.Logica.Models.clstbPersona> listUser = clsUsuarios.GetUsuarios(obclstbPersona);//Pasa el valor

                string json_response = JsonConvert.SerializeObject(listUser);//Jeason Lista de Restaurantes

                var ret = Request.CreateResponse(HttpStatusCode.OK);

                ret.Content = new StringContent(json_response, Encoding.UTF8, "application/json");
                return ret;

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

    }
}
