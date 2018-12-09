using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Restaurante
{
    public partial class RestauranteCliente : System.Web.UI.Page
    {
        string codRes = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

               
                string[] stEmail = null;
                string stLogin = string.Empty;
                string stPassword = string.Empty;
                stEmail = Session["sesionLogin"].ToString().Split('@');
                        

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
                //Colocar informacion

                Controller.BuscadorController obbuscadorController = new Controller.BuscadorController();
                List<Logica.Models.clstbRestaurante> listRest = obbuscadorController.getBuquedadRestControllerUnico(stLogin);
                if (listRest != null) {
                    lbnomrest.Text = listRest[0].strrestNombre;
                    lbdescrest.Text = listRest[0].strrestDescripcion;
                    lbCorreo.Text = listRest[0].strrestcorreo;
                    lbTelefono.Text = listRest[0].strrestTelefono;
                    lbDire.Text = listRest[0].strrestDireccion;
                    lbPrincipal.Text = listRest[0].strrestPrincipal;
                    lbSu.Text = listRest[0].strrestSucursal;
                    codRes = listRest[0].longrestCodigo.ToString();

                } else { }

            }
        }

        protected void btnReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Restaurante/Menu.aspx?"+codRes);//REdicciono

        }
    }
}