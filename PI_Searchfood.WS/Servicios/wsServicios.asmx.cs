using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Services;

namespace PI_Searchfood.WS.Servicios
{
    /// <summary>
    /// Descripción breve de wsServicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsServicios : System.Web.Services.WebService
    {
//METODOS PARA CONSULTAR EN FORMATO JSON Y XML
        [WebMethod]
        public string getComida()
        {
            Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            return  JsonConvert.SerializeObject(obclsComida.getComida());
           
        }

        [WebMethod]
        public List <Logica.Models.clstbComida>getComida_XML()
        {
            Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            return obclsComida.getComida();

        }

        //METODO PARA INSERTAR 
        [WebMethod]
        public void createComidaWS(string stclstbComida) {
            Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            Logica.Models.clstbComida obclstbComidaModel = JsonConvert.DeserializeObject<Logica.Models.clstbComida>(stclstbComida);
            obclsComida.createComida(obclstbComidaModel);
              }
        //METODO PARA EDITAR
        [WebMethod]
        public void updateComidaWS(string stclstbComida)
        {
            Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            Logica.Models.clstbComida obclstbComidaModel = JsonConvert.DeserializeObject<Logica.Models.clstbComida>(stclstbComida);
            obclsComida.updateComida(obclstbComidaModel);
        }

        //METODO PARA ELIMINAR
        [WebMethod]
        public void deleteComidaWS(string stclstbComida)
        {
            Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();
            Logica.Models.clstbComida obclstbComidaModel = JsonConvert.DeserializeObject<Logica.Models.clstbComida>(stclstbComida);
            obclsComida.deleteComida(obclstbComidaModel);


        }
    }
}
