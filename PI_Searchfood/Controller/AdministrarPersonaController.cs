using System;
using System.Data;

namespace PI_Searchfood.Controller
{
    public class AdministrarPersonaController
    {
        /// <summary>
        /// OBTIENE REGISTROS DE PERSONAS
        /// </summary>
        /// <returns>DATA POSIBLES PERSONAS</returns>
        public DataSet getConsultarAdministrarPersonasController()
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarPersonas();

                 }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// ADMINISTRAR PERSONAS
        /// </summary>
        /// <param name="obclstbPersonaModels"> OBJETO</param>
        /// <param name="inopcion">OPCION DE EJECUCION</param>
        /// <returns>MENSAJE DE PROCESO</returns>
        public string setAdministrarPersonaController(Logica.Models.clstbPersona obclstbPersonaModels, int inopcion)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.setAdministrarPersona(obclstbPersonaModels, inopcion);
            }
            catch (Exception ex) { throw ex; }


        }

        /// <summary>
        /// CONSULTAR GENERO
        /// </summary>
        /// <returns>DATA GENERO</returns>
        public DataSet getConsultarGeneroController()
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarGenero();

            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getConsultarPaisController()
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarPais();

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarDepartamentoController(int CodigoPisDep)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarDepartamento(CodigoPisDep);

            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getConsultarCiudadController(int inCodigoDepCiudad)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarCiudad(inCodigoDepCiudad);

            }
            catch (Exception ex) { throw ex; }
        }
        public DataSet getConsultarDPController(int inCodigoCiudad)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarPD(inCodigoCiudad);

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet getConsultarGUController( int inCodigoGU)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsAdministracionPersonas obclsAdministracionPersonas = new Logica.BL.clsAdministracionPersonas();
                return obclsAdministracionPersonas.getConsultarGU(inCodigoGU);

            }
            catch (Exception ex) { throw ex; }
        }

    }
}