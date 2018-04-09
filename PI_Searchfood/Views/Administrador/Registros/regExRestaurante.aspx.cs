using System;
using System.Data;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Administrador.Registros
{
    public partial class regExRestaurante : System.Web.UI.Page
    {

        void getRestaurante()
        {
            try
            {
                //Instanciar el controlador
                Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
                DataSet dsConsultarPais = obadministrarRestauranteController.getConsultarPaisController();
                ddlPais.DataSource = dsConsultarPais;
                ddlPais.DataTextField = "Nombre_Pais";
                ddlPais.DataValueField = "Codigo_Pais";
                ddlPais.DataBind();

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }

        void getLimpiar()
        {
            lbOpcion.Text = lbCodigoRes.Text = txtNit.Text = txtNombre.Text = txtDireccion.Text = txtCelular.Text = txtCorreo.Text = txtContraseña.Text = txtLatitud.Text = txtLongitud.Text = txtArea.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getRestaurante();
                lbOpcion.Text = "1";
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (string.IsNullOrEmpty(txtNit.Text)) stMensaje += "Ingrese NIT, ";
                if (string.IsNullOrEmpty(txtCorreo.Text)) stMensaje += "Ingrese Email, ";
                if (string.IsNullOrEmpty(txtContraseña.Text)) stMensaje += "Ingrese Contraseña, ";
                if (string.IsNullOrEmpty(txtDireccion.Text)) stMensaje += "Ingrese Dirección, ";
                if (string.IsNullOrEmpty(txtCelular.Text)) stMensaje += "Ingrese Celular, ";
                if (string.IsNullOrEmpty(txtArea.Text)) stMensaje += "Ingrese Descripción, ";
                if (string.IsNullOrEmpty(txtLatitud.Text)) stMensaje += "Ingrese Latitud, ";
                if (string.IsNullOrEmpty(txtLongitud.Text)) stMensaje += "Ingrese Longitud, ";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!string.IsNullOrEmpty(lbOpcion.Text))
                {

                    Logica.BL.clsAdministracionEmpresas obclsAdministracionEmpresas = new Logica.BL.clsAdministracionEmpresas();
                    if (lbOpcion.Text.Equals("1"))
                    {
                        Logica.Models.clstbRestaurante obclstbRestaurante = new Logica.Models.clstbRestaurante
                        {
                            longrestCodigo = Convert.ToInt64(txtNit.Text),
                            strrestNombre = txtNombre.Text,
                            strrestDireccion = txtDireccion.Text,
                            strrestLatitud = txtLatitud.Text,
                            strrestLongitud = txtLongitud.Text,
                            strrestTelefono = txtCelular.Text,
                            strrestDescripcion = txtArea.Text,
                            strrestcorreo = txtCorreo.Text,

                            clsUsuarios = new Logica.Models.clsUsuarios
                            {

                                inCodigo = obclsAdministracionEmpresas.getValidarCodigoRestaurante(),
                                stPassword = txtContraseña.Text
                            }
                               ,
                            clstbCiudad = new Logica.Models.clstbCiudad
                            {
                                ciudCodigo = Convert.ToInt32(ddlCiudad.SelectedValue)
                            }

                        };
                        Controller.AdministrarRestauranteController obAdministrarRestauranteController = new Controller.AdministrarRestauranteController();
                        ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('APROBADO!', '" + obAdministrarRestauranteController.setAdministrarEmpresasController(obclstbRestaurante, Convert.ToInt32(lbOpcion.Text)) + "!', 'success')</Script>");
                        getLimpiar();
                        Response.Redirect("../../Administrador/Login/frmLogin.aspx");//Redicciono a Login

                    }
                }
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            getLimpiar();
        }
        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inCodigo = Convert.ToInt32(ddlPais.SelectedValue);
            Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
            DataSet dsConsultarDepartamento = obadministrarRestauranteController.getConsultarDepartamentoController(inCodigo);

            ddlDepartamento.DataSource = dsConsultarDepartamento;
            ddlDepartamento.DataTextField = "Nombre_Depa";
            ddlDepartamento.DataValueField = "Codigo_Depa";
            ddlDepartamento.DataBind();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inCodigoDep = Convert.ToInt32(ddlDepartamento.SelectedValue);

            Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
            DataSet dsConsultarCiudad = obadministrarRestauranteController.getConsultarCiudadController(inCodigoDep);

            ddlCiudad.DataSource = dsConsultarCiudad;
            ddlCiudad.DataTextField = "Nombre_Ciudad";
            ddlCiudad.DataValueField = "Codigo_Ciudad";
            ddlCiudad.DataBind();

        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inCodigo = Convert.ToInt32(ddlCiudad.SelectedValue);

        }




    }
}