using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

namespace PI_Searchfood.Views.Administrador.Registros
{
    public partial class regRestaurante : System.Web.UI.Page
    {

        public string stRuta = string.Empty, stRutaDestino = string.Empty;
        void getRestaurante()
        {
            try
            {
                //Instanciar el controlador
                Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
                //Consultar restaurantes
                DataSet dsConsulta = obadministrarRestauranteController.getConsultarAdministrarRestauranteController();
                //Asignar datos a la GVW
                if (dsConsulta.Tables[0].Rows.Count > 0) { gvwDatos.DataSource = dsConsulta; }
                else { gvwDatos.DataSource = null; }
                gvwDatos.DataBind();

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
                        //Imagen Verificar
                        getImagenFu();

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
                                stLogin=txtCorreo.Text,
                                stPassword = txtContraseña.Text,
                                stImagen= stRutaDestino
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
                        getRestaurante();

                    }
                    else if (lbOpcion.Text.Equals("2"))
                    {
                        //Imagen Verificar
                        getImagenFu();

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

                                inCodigo = Convert.ToInt32(lbCodigoRes.Text),
                                stLogin=txtCorreo.Text,
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
                        getRestaurante();

                    }
                }
            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }
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

        protected void gvwDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);//Define que fila es.. CommandArgument
                if (e.CommandName.Equals("Modificar"))
                {
                    lbOpcion.Text = "2";
                    //Accede a un control web dentro de un grid
                    txtNit.Text = string.IsNullOrEmpty(((Label)gvwDatos.Rows[inIndice].FindControl("lblNIT")).Text) ? string.Empty : ((Label)gvwDatos.Rows[inIndice].FindControl("lblNIT")).Text;
                    txtNombre.Text = gvwDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[1].Text);
                    txtDireccion.Text = gvwDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[2].Text);
                    txtCelular.Text = gvwDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[3].Text);
                    //Colocar información de gvwDatos al Campo Descripciòn
                    TextBox a = (TextBox)(gvwDatos.Rows[inIndice].FindControl("txtDescripcion2"));
                    txtArea.Text = a.Text;
                  
                    txtLat.Text = gvwDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[5].Text);
                    txtLong.Text = gvwDatos.Rows[inIndice].Cells[6].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[6].Text);
                    lbCodigoRes.Text = gvwDatos.Rows[inIndice].Cells[8].Text;
                    int inCodigoCiudadU = Convert.ToInt32(gvwDatos.Rows[inIndice].Cells[7].Text);
                    txtCorreo.Text = gvwDatos.Rows[inIndice].Cells[9].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[9].Text);
                    txtContraseña.Text = gvwDatos.Rows[inIndice].Cells[10].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[10].Text);

                    Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
                    DataSet dsConsultaDP = obadministrarRestauranteController.getConsultarDPControllerR(inCodigoCiudadU);
                    ddlPais.SelectedValue = dsConsultaDP.Tables[0].Rows[0]["paisCodigo"].ToString();
                    ddlPais_SelectedIndexChanged(ddlPais, new EventArgs());

                    ddlDepartamento.SelectedValue = dsConsultaDP.Tables[0].Rows[0]["depaCodigo"].ToString();
                    ddlDepartamento_SelectedIndexChanged(ddlDepartamento, new EventArgs());

                    ddlCiudad.SelectedValue = dsConsultaDP.Tables[0].Rows[0]["ciudCodigo"].ToString();

                    getRestaurante();

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lbOpcion.Text = "3";
                    lbCodigoRes.Text = gvwDatos.Rows[inIndice].Cells[8].Text;
                    Logica.BL.clsUsuarios obclsUsuarios = new Logica.BL.clsUsuarios();
                    Logica.Models.clstbRestaurante obclstbRestaurante = new Logica.Models.clstbRestaurante
                    {
                        longrestCodigo = Convert.ToInt64(((Label)gvwDatos.Rows[inIndice].FindControl("lblNIT")).Text),
                        strrestcorreo = gvwDatos.Rows[inIndice].Cells[9].Text,
                        strrestNombre = string.Empty,
                        strrestDescripcion = string.Empty,
                        strrestDireccion = string.Empty,
                        strrestTelefono = string.Empty,
                        strrestLatitud = string.Empty,
                        strrestLongitud = string.Empty,

                        clsUsuarios = new Logica.Models.clsUsuarios
                        {

                            inCodigo = Convert.ToInt32(lbCodigoRes.Text),
                            stPassword = string.Empty,
                            stImagen=string.Empty
                        }
                   ,
                        clstbCiudad = new Logica.Models.clstbCiudad
                        {
                            ciudCodigo = 0,
                        }

                    };
                    Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('APROBADO!', '" + obadministrarRestauranteController.setAdministrarEmpresasController(obclstbRestaurante, Convert.ToInt32(lbOpcion.Text)) + "!', 'success')</Script>");
                    getLimpiar();//Limipiar
                    getRestaurante();

                }

            }
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            getLimpiar();
        }
    }
}