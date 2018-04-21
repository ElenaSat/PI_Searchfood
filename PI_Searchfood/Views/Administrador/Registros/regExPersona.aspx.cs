using System;
using System.Data;
using System.IO;

namespace PI_Searchfood.Views.Administrador.Registros
{
    public partial class regExPersona : System.Web.UI.Page
    {
        public string stRuta = string.Empty, stRutaDestino = string.Empty;
        void getImagenFu()
        {
            if (fuImagen.HasFile)
            {
                if (Path.GetExtension(fuImagen.FileName).Equals("png"))
                    throw new Exception("Solo se permiten formatos .png");

                stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;//RUTA TEMPORAL
                fuImagen.PostedFile.SaveAs(stRuta); //GUARDAR EL ARCHIVO DENTRO DEL PROYECTO
                stRutaDestino = Server.MapPath(@"~\Images\Personas\") + txtCorreo.Text + Path.GetExtension(fuImagen.FileName); //RUTA DE DESTINO DONDE QUEDAN LAS IMAGENES

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
        private void getLimpiar()
        {
            lbOpcion.Text = txtIdentificacion.Text = txtNombre.Text = txtApellido.Text = txtCelular.Text = txtCorreo.Text = txtContraseña.Text = txtDireccion.Text = string.Empty;


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                try
                {
                    Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();
                    DataSet dsConsulta = obAdministrarPersonaController.getConsultarAdministrarPersonasController();

                    DataSet dsConsultarGenero = obAdministrarPersonaController.getConsultarGeneroController();
                    ddlGenero.DataSource = dsConsultarGenero;
                    ddlGenero.DataTextField = "Descripción_Genero";
                    ddlGenero.DataValueField = "Codigo_Genero";
                    ddlGenero.DataBind();

                    DataSet dsConsultarPais = obAdministrarPersonaController.getConsultarPaisController();
                    ddlPais.DataSource = dsConsultarPais;
                    ddlPais.DataTextField = "Nombre_Pais";
                    ddlPais.DataValueField = "Codigo_Pais";
                    ddlPais.DataBind();



                }
                catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtIdentificacion.Text)) stMensaje += "Ingrese Identificación, ";
                if (string.IsNullOrEmpty(txtCorreo.Text)) stMensaje += "Ingrese Email, ";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (string.IsNullOrEmpty(lbOpcion.Text)) lbOpcion.Text = "1";
                //Validar Imagen
                getImagenFu();
                Logica.BL.clsUsuarios obclsUsuarios = new Logica.BL.clsUsuarios();
                Logica.Models.clstbPersona obclstbPersona = new Logica.Models.clstbPersona
                {
                    longpersIdentificacion = Convert.ToInt64(txtIdentificacion.Text),
                    stpersNombre = txtNombre.Text,
                    stpersApellido = txtApellido.Text,
                    stpersDireccion = txtDireccion.Text,
                    stpersCorreo = txtCorreo.Text,
                    stpersCelular = txtCelular.Text,
                    clstbGenero = new Logica.Models.clstbGenero
                    {
                        longeneCodigo = Convert.ToInt64(ddlGenero.SelectedValue)
                    },

                    clsUsuarios = new Logica.Models.clsUsuarios
                    {

                        inCodigo = obclsUsuarios.getValidarCodigo(),
                        stLogin=txtCorreo.Text,
                        stPassword = txtContraseña.Text,
                        stImagen=stRutaDestino

                    }
                    ,
                    clstbCiudad = new Logica.Models.clstbCiudad
                    {
                        ciudCodigo = Convert.ToInt32(ddlCiudad.SelectedValue)
                    }

                };

                Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('APROBADO!', '" + obAdministrarPersonaController.setAdministrarPersonaController(obclstbPersona, Convert.ToInt32(lbOpcion.Text)) + "!', 'success')</Script>");
                getLimpiar();
                Response.Redirect("../../Administrador/Login/frmLogin.aspx");//Redicciono a Login


            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inCodigo = Convert.ToInt32(ddlPais.SelectedValue);
            Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();
            DataSet dsConsultarDepartamento = obAdministrarPersonaController.getConsultarDepartamentoController(inCodigo);

            ddlDepartamento.DataSource = dsConsultarDepartamento;
            ddlDepartamento.DataTextField = "Nombre_Depa";
            ddlDepartamento.DataValueField = "Codigo_Depa";
            ddlDepartamento.DataBind();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inCodigoDep = Convert.ToInt32(ddlDepartamento.SelectedValue);

            Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();
            DataSet dsConsultarCiudad = obAdministrarPersonaController.getConsultarCiudadController(inCodigoDep);

            ddlCiudad.DataSource = dsConsultarCiudad;
            ddlCiudad.DataTextField = "Nombre_Ciudad";
            ddlCiudad.DataValueField = "Codigo_Ciudad";
            ddlCiudad.DataBind();

        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int inCodigo = Convert.ToInt32(ddlCiudad.SelectedValue);

        }
        protected void ddlGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            getLimpiar();
        }

       

            }
}
