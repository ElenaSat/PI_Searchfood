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
            if (!IsPostBack) {
                if (Request.Cookies["Email"]!=null) {
                    txtEmail.Text = Request.Cookies["Email"].Value.ToString();

                }


            }
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
                        if (chkRecordar.Checked)
                        {
                            //DEFINIR COOKIE
                            HttpCookie cookieEmail = new HttpCookie("Email", txtEmail.Text);
                            cookieEmail.Expires = DateTime.Now.AddDays(2);
                            Response.Cookies.Add(cookieEmail);
                        }
                        else {
                            //ELIMINAR COOKIE
                            HttpCookie cookieEmail = new HttpCookie("Email", txtEmail.Text);
                            cookieEmail.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(cookieEmail);


                        }
                        ViewState["viewLogin"]= txtEmail.Text;
                        ViewState["viewPassword"]= txtPassword.Text;
                        //definir sesion
                        Session["sesionLogin"] = txtEmail.Text;
                        Session["sesionPassword"] = txtPassword.Text;

                        //Borrar
                       // Session.RemoveAll();
                        //Session.Remove("sesionlogin"); Nombre de variable a remover

                        Response.Redirect("../../Cliente/indexCliente.aspx?stLogin="+txtEmail.Text+"&stPassword="+txtPassword.Text);//REdicciono
                        //traspaso de datos ?despues enviar parametros se ven

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
