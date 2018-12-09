using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Restaurante
{
    public partial class ConfiguracionR : System.Web.UI.Page
    {
        public string stRuta = string.Empty, stRutaDestino = string.Empty;

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
        void getImagenFu()
        {
            if (fuImagen.HasFile)
            {
                if (Path.GetExtension(fuImagen.FileName).Equals("png"))
                    throw new Exception("Solo se permiten formatos .png");

                stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;//RUTA TEMPORAL
                fuImagen.PostedFile.SaveAs(stRuta); //GUARDAR EL ARCHIVO DENTRO DEL PROYECTO
                stRutaDestino = Server.MapPath(@"~\Images\Restaurantes\") + txtCorreo.Text + Path.GetExtension(fuImagen.FileName); //RUTA DE DESTINO DONDE QUEDAN LAS IMAGENES

                if (File.Exists(stRutaDestino))
                {
                    File.SetAttributes(stRutaDestino, FileAttributes.Normal);
                    File.Delete(stRutaDestino);
                }

                File.Copy(stRuta, stRutaDestino);
                File.SetAttributes(stRuta, FileAttributes.Normal);
                File.Delete(stRuta);

            }

        }
        void getLimpiar()
        {
            lbOpcion.Text = lbCodigoRes.Text = txtNit.Text = txtNombre.Text = txtDireccion.Text = txtCelular.Text = txtCorreo.Text = txtContraseña.Text = txtArea.Text = string.Empty;
            txtLat.Text = "3.478617218356569";
            txtLong.Text = "-76.51652991771698";
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
                if (string.IsNullOrEmpty(txtLat.Text)) stMensaje += "Ingrese Latitud, ";
                if (string.IsNullOrEmpty(txtLong.Text)) stMensaje += "Ingrese Longitud, ";

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
                            strrestLatitud = txtLat.Text,
                            strrestLongitud = txtLong.Text,
                            strrestTelefono = txtCelular.Text,
                            strrestDescripcion = txtArea.Text,
                            strrestcorreo = txtCorreo.Text,

                            clsUsuarios = new Logica.Models.clsUsuarios
                            {

                                inCodigo = obclsAdministracionEmpresas.getValidarCodigoRestaurante(),
                                stLogin = txtCorreo.Text,
                                stPassword = txtContraseña.Text,
                                stImagen = stRutaDestino
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