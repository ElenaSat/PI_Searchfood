using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Restaurante
{
    public partial class frmRestaurante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string stLogin = string.Empty;
                string stPassword = string.Empty;

                if (Request.QueryString["stLogin"] != null && Request.QueryString["stPassword"] != null)
                {
                    stLogin = Request.QueryString["stLogin"].ToString();
                    stPassword = Request.QueryString["stPassword"].ToString();

                }
                //Validar
                if (Session["sesionLogin"] != null && Session["sesionPassword"] != null)
                {
                    stLogin = Session["sesionLogin"].ToString();//recepcion
                    stPassword = Session["sesionPassword"].ToString();
                    // INSTANCIAR LA VARIABLE Session["sesionLogin"] = "brandon";
                }
                else
                {
                    Response.Redirect("../Administrador/Login/frmLogin.aspx");
                    //Validar por todos los formularios
                }
                Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
                DataSet dsConsulta = obadministrarRestauranteController.getConsultarAdministrarRestauranteControllerImg(stLogin);
                string stNombreImagen = string.Empty;
                if (dsConsulta.Tables[0].Rows[0]["UsuaImagen"].ToString().Equals(""))
                {
                    stNombreImagen = "Images/DfImages/defualt.png";
                }
                else
                {
                    dsConsulta = obadministrarRestauranteController.getConsultarAdministrarRestauranteControllerImg(stLogin);
                    string[] stNombre = dsConsulta.Tables[0].Rows[0]["UsuaImagen"].ToString().Split('\\');
                    stNombreImagen = "Images/Restaurantes/" + stNombre[stNombre.Length - 1].ToString();
                }

                //ALT +126
                imgUsuario.ImageUrl = "~/" + stNombreImagen;
            }
        }
    }
}