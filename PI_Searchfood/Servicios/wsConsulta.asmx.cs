using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PI_Searchfood.Servicios
{
    /// <summary>
    /// Descripción breve de wsConsulta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsConsulta : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> getEmpleadosWS(string prefixText, int count)
        {
            Logica.BL.clsEmpleados obclsEmpleados =
                new Logica.BL.clsEmpleados();

            List<Logica.BL.clsEmpleados.clsModelEmpleado> lstclsModelEmpleado =
                obclsEmpleados.getEmpleados(prefixText);

            List<string> lstEmpleados = new List<string>();
            foreach (var elem in lstclsModelEmpleado)
                lstEmpleados.Add(elem.ID + " - " + elem.NOMBRES + " " + elem.APELLIDOS);

            return lstEmpleados;
        }

        [WebMethod]
        public List<string> getConsultarComidaWS(string prefixText, int count) {
            Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();

            List<Logica.Models.clstbComida> lstclstbComidas = obclsComida.getConsultarComida(prefixText);
            List<string> lstComida = new List<string>();
            foreach (var elem in lstclstbComidas)
                lstComida.Add(elem.longcomiCodigo + " - " + elem.strcomiDescripcion);

            return lstComida;


        }

    }
}
