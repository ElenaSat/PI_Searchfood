using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

namespace PI_Searchfood.Views.Administrador.Registros
{
    public partial class regPersonas : System.Web.UI.Page
    {
        public string stRuta = string.Empty, stRutaDestino = string.Empty;
        void getPersonas()
        {
            try
            {
                Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();
                DataSet dsConsulta = obAdministrarPersonaController.getConsultarAdministrarPersonasController();

                if (dsConsulta.Tables[0].Rows.Count > 0) { gvwDatos.DataSource = dsConsulta; }
                else { gvwDatos.DataSource = null; }
                gvwDatos.DataBind();
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
        void getLimpiar()
        {
            lbOpcion.Text = lbCodigoUs.Text = txtIdentificacion.Text = txtNombre.Text = txtApellido.Text = txtCelular.Text = txtCorreo.Text = txtContraseña.Text = txtDireccion.Text = string.Empty;

        }
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
        /// <summary>
        /// OBTINE CONSULTA DE PERSONAS
        /// </summary>
        ///
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getPersonas();
                lbOpcion.Text = "1";
            }
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtNombre.Text)) stMensaje += "Ingrese Nombre, ";
                if (string.IsNullOrEmpty(txtApellido.Text)) stMensaje += "Ingrese Apellido, ";
                if (string.IsNullOrEmpty(txtIdentificacion.Text)) stMensaje += "Ingrese Identificación, ";
                if (string.IsNullOrEmpty(txtCorreo.Text)) stMensaje += "Ingrese Email, ";
                if (string.IsNullOrEmpty(txtContraseña.Text)) stMensaje += "Ingrese Contraseña, ";
                if (string.IsNullOrEmpty(txtDireccion.Text)) stMensaje += "Ingrese Dirección, ";
                if (string.IsNullOrEmpty(txtCelular.Text)) stMensaje += "Ingrese Celular, ";

                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!string.IsNullOrEmpty(lbOpcion.Text))
                {

                    Logica.BL.clsUsuarios obclsUsuarios = new Logica.BL.clsUsuarios();

                    if (lbOpcion.Text.Equals("1"))
                    {
                        //Imagen Verificar
                        getImagenFu();

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
                                stPassword = txtContraseña.Text,
                                stImagen = stRutaDestino
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
                        getPersonas();

                    }
                    else if (lbOpcion.Text.Equals("2"))
                    {
                        //Imagen
                        getImagenFu();

                        Logica.Models.clstbPersona obclstbPersonaE = new Logica.Models.clstbPersona
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

                                inCodigo = Convert.ToInt32(lbCodigoUs.Text),
                                stPassword = txtContraseña.Text,
                                stImagen = stRutaDestino


                            }
                            ,
                            clstbCiudad = new Logica.Models.clstbCiudad
                            {
                                ciudCodigo = Convert.ToInt32(ddlCiudad.SelectedValue)
                            }

                        };
                        Controller.AdministrarPersonaController obAdministrarPersonaControllerE = new Controller.AdministrarPersonaController();
                        ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('APROBADO!', '" + obAdministrarPersonaControllerE.setAdministrarPersonaController(obclstbPersonaE, Convert.ToInt32(lbOpcion.Text)) + "!', 'success')</Script>");
                        getLimpiar();
                        getPersonas();

                    }


                }
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

        protected void gvwDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);//Define que fila es.. CommandArgument
                if (e.CommandName.Equals("Modificar"))
                {
                    lbOpcion.Text = "2";
                    //Accede a un control web dentro de un grid
                    txtIdentificacion.Text = string.IsNullOrEmpty(((Label)gvwDatos.Rows[inIndice].FindControl("lblIdentificacion")).Text) ? string.Empty : ((Label)gvwDatos.Rows[inIndice].FindControl("lblIdentificacion")).Text;
                    txtNombre.Text = gvwDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[1].Text);
                    txtApellido.Text = gvwDatos.Rows[inIndice].Cells[2].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[2].Text);
                    txtDireccion.Text = gvwDatos.Rows[inIndice].Cells[3].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[3].Text);
                    txtCorreo.Text = gvwDatos.Rows[inIndice].Cells[4].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[4].Text);
                    txtCelular.Text = gvwDatos.Rows[inIndice].Cells[5].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[5].Text);
                    txtContraseña.Text = gvwDatos.Rows[inIndice].Cells[9].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[9].Text);
                    lbCodigoUs.Text = gvwDatos.Rows[inIndice].Cells[8].Text;
                    int inCodigoCiudadU = Convert.ToInt32(gvwDatos.Rows[inIndice].Cells[7].Text);
                    Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();
                    DataSet dsConsultaDP = obAdministrarPersonaController.getConsultarDPController(inCodigoCiudadU);
                    ddlPais.SelectedValue = dsConsultaDP.Tables[0].Rows[0]["paisCodigo"].ToString();
                    ddlPais_SelectedIndexChanged(ddlPais, new EventArgs());

                    ddlDepartamento.SelectedValue = dsConsultaDP.Tables[0].Rows[0]["depaCodigo"].ToString();
                    ddlDepartamento_SelectedIndexChanged(ddlDepartamento, new EventArgs());

                    ddlCiudad.SelectedValue = dsConsultaDP.Tables[0].Rows[0]["ciudCodigo"].ToString();

                    int codigoGU = Convert.ToInt32(gvwDatos.Rows[inIndice].Cells[6].Text);
                    DataSet dsConsultarGU = obAdministrarPersonaController.getConsultarGUController(codigoGU);
                    ddlGenero.SelectedValue = dsConsultarGU.Tables[0].Rows[0]["geneCodigo"].ToString();
                    ddlGenero_SelectedIndexChanged(ddlGenero, new EventArgs());

                    getPersonas();

                }
                else if (e.CommandName.Equals("Eliminar"))
                {
                    lbOpcion.Text = "3";
                    lbCodigoUs.Text = gvwDatos.Rows[inIndice].Cells[8].Text;
                    Logica.BL.clsUsuarios obclsUsuarios = new Logica.BL.clsUsuarios();
                    Logica.Models.clstbPersona obclstbPersona = new Logica.Models.clstbPersona
                    {
                        longpersIdentificacion = Convert.ToInt64(((Label)gvwDatos.Rows[inIndice].FindControl("lblIdentificacion")).Text),
                        stpersCorreo = gvwDatos.Rows[inIndice].Cells[4].Text,
                        stpersNombre = string.Empty,
                        stpersApellido = string.Empty,
                        stpersDireccion = string.Empty,
                        stpersCelular = string.Empty,
                        clstbGenero = new Logica.Models.clstbGenero
                        {
                            longeneCodigo = 0,
                        },

                        clsUsuarios = new Logica.Models.clsUsuarios
                        {

                            inCodigo = Convert.ToInt32(lbCodigoUs.Text),
                            stPassword = string.Empty,
                            stImagen = string.Empty,
                           stLogin=gvwDatos.Rows[inIndice].Cells[4].Text
                        }
                   ,
                        clstbCiudad = new Logica.Models.clstbCiudad
                        {
                            ciudCodigo = 0,
                        }

                    };
                    Controller.AdministrarPersonaController obAdministrarPersonaController = new Controller.AdministrarPersonaController();

                    ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('APROBADO!', '" + obAdministrarPersonaController.setAdministrarPersonaController(obclstbPersona, Convert.ToInt32(lbOpcion.Text)) + "!', 'success')</Script>");
                    getLimpiar();//Limipiar
                    getPersonas();

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