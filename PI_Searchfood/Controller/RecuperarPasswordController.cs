using System;
using System.Data;

namespace PI_Searchfood.Controller
{
    public class RecuperarPasswordController
    {
        /// <summary>
        /// CONSULTA EL REGISTRO PASSWORD
        /// </summary>
        /// <param name="obclsUsuarios"></param>
        /// <returns>obclsUsuarios</returns>
        public DataSet getConsultarPasswordController(Logica.Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                PI_Searchfood.Logica.BL.clsRecuperarPassword obclsRecuperarPassword = new Logica.BL.clsRecuperarPassword();
                return obclsRecuperarPassword.getConsultarPassword(obclsUsuarios);

            }
            catch (Exception ex) { throw ex; }
        }
        public void setEmailController(Logica.Models.clsCorreo obclsCorreo)
        {
            try
            {
                Logica.BL.clsGeneral obclsGeneral = new Logica.BL.clsGeneral();
                obclsGeneral.setEMail(obclsCorreo);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}