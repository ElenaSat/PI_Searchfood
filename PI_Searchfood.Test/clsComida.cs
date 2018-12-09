using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace PI_Searchfood.Test
{
    [TestClass]
    public class clsComida
    {
        [TestMethod]
        public void createComidaWS()
        {
            //ARRANGE
            wsServicios.wsServicios obwsServicios = NewMethod();
            //ACT
            Logica.Models.clstbComida obclstbComidaModel = new Logica.Models.clstbComida
            {
                loncomiValor = 45000,
                obclstbCategoria = new Logica.Models.clstbCategoria
                {
                    longcateCodigo = 1,
                },
                obclstbRestaurante = new Logica.Models.clstbRestaurante
                {
                    longrestCodigo = 313131,
                },
                strcomiDescripcion = "ARROZ CON POLLO",
                strcomiRutaImagen = null,
            };

            string json = JsonConvert.SerializeObject(obclstbComidaModel);
            //ASSERT
            obwsServicios.createComidaWS(json);
        }

        private static wsServicios.wsServicios NewMethod()
        {
            return new wsServicios.wsServicios();
        }
    }
}
