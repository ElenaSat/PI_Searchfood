using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace PI_Searchfood.API.Controllers
{
    [Route("")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [ActionName("")]
        public HttpResponseMessage GetUsuario(Logica.Models.clsUsuarios jsonrequest)
        {
            var json_response = "";
            var ret = Request.CreateResponse(HttpStatusCode.OK);
            ret.Content = new StringContent(json_response,Encoding.UTF8,"apllication/json");
            //return ret;

            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
