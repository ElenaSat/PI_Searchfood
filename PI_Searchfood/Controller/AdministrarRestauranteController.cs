using System;
using System.Data;

namespace PI_Searchfood.Controller
{
    public class AdministrarRestauranteController
    {
      public DataSet getConsultarAdministrarRestauranteController()
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                return obclsAdministracionEmpresas.getConsultarEmpresas();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarAdministrarRestauranteControllerImg(string stcCorreo)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();

                return obclsAdministracionEmpresas.getConsultarRestaurantesImg(stcCorreo);

            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// ADMINISTRAR PERSONAS
        /// </summary>
        /// <param name="obclstbPersonaModels"> OBJETO</param>
        /// <param name="inopcion">OPCION DE EJECUCION</param>
        /// <returns>MENSAJE DE PROCESO</returns>
        public string setAdministrarEmpresasController(Logica.Models.clstbRestaurante obclstbRestauranteModels, int inopcion)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                return obclsAdministracionEmpresas.setAdministrarEmpresas(obclstbRestauranteModels, inopcion);
            }
            catch (Exception ex) { throw ex; }


        }
        public DataSet getConsultarPaisController()
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                return obclsAdministracionEmpresas.getConsultarPais();

            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getConsultarDepartamentoController(int CodigoPisDep)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                return obclsAdministracionEmpresas.getConsultarDepartamento(CodigoPisDep);

            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getConsultarCiudadController(int inCodigoDepCiudad)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                return obclsAdministracionEmpresas.getConsultarCiudad(inCodigoDepCiudad);

            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getConsultarDPControllerR(int inCodigoCiudad)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                return obclsAdministracionEmpresas.getConsultarPDR(inCodigoCiudad);

            }
            catch (Exception ex) { throw ex; }
        }
    }
}