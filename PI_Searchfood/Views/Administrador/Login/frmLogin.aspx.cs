using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Administrador.Login
{
    public partial class frmLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtEmail.Text)) stMensaje += "Ingrese Email, ";
                if (string.IsNullOrEmpty(txtPassword.Text)) stMensaje += "Ingrese Contraseña, ";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (Radio1.Checked==true) {
                    //Defino objetos con propiedades
                    Logica.Models.clsUsuarios obclsUsuarios = new Logica.Models.clsUsuarios
                    {
                        stLogin = txtEmail.Text,
                        stPassword = txtPassword.Text,
                        stPerfil = 1
                    };
                    //Instancia Controlador
                    Controller.LoginController obLoginController = new Controller.LoginController();
                    bool blBandera = obLoginController.getValidarUsuarioController(obclsUsuarios);
                    if (blBandera)
                    {
                        Response.Redirect("../../Cliente/indexCliente.aspx");//REdicciono
                    }
                    else
                    {
                        throw new Exception("Usuario ,Password o Tipo de Usuario incorrectos");
                    }
                }else  if (Radio2.Checked==true){

                //Defino objetos con propiedades
                Logica.Models.clsUsuarios obclsUsuarios = new Logica.Models.clsUsuarios
                {
                    stLogin = txtEmail.Text,
                    stPassword = txtPassword.Text,
                    stPerfil = 2
                    };

                    //Instancia Controlador
                    Controller.LoginController obLoginController = new Controller.LoginController();
                    bool blBandera = obLoginController.getValidarUsuarioController(obclsUsuarios);
                    if (blBandera)
                    {
                        Response.Redirect("../../Restaurante/indexRestaurante.aspx");//REdicciono
                    }
                    else
                    {
                        throw new Exception("Usuario ,Password o Tipo de Usuario incorrectos");
                    }

                }
                else
                {
                    throw new Exception("Usuario ,Password o Tipo de Usuario incorrectos");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }
        }




    }
}
