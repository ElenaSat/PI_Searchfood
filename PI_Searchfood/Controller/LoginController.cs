using System;
using System.Data;

namespace PI_Searchfood.Controller
{
    public class LoginController
    {   /// <summary>
    /// VALIDA USUARIO 
    /// </summary>
    /// <param name="obclsUsuarios">OBJETO USUARIO</param>
    /// <returns>CONFIGURACION</returns>      
        public bool getValidarUsuarioController(Logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {   Logica.BL.clsUsuarios obclsUsuario = new Logica.BL.clsUsuarios();
                return obclsUsuario.getValidarUsuario(obclsUsuarios);
                 }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public int getConsultarCUsuarioController()
        {
            try
            {
                Logica.BL.clsUsuarios obclsUsuario = new Logica.BL.clsUsuarios();
                return obclsUsuario.getValidarCodigo();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}