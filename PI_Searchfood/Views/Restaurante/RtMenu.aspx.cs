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
    public partial class RtMenu : System.Web.UI.Page
    {
        public string stLogin = string.Empty;
        public string stRuta = string.Empty, stRutaDestino = string.Empty;
        void getImagenFu()
        {
            if (fuImagen.HasFile)
            {
                if (Path.GetExtension(fuImagen.FileName).Equals("png"))
                    throw new Exception("Solo se permiten formatos .png");

                stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;//RUTA TEMPORAL
                fuImagen.PostedFile.SaveAs(stRuta); //GUARDAR EL ARCHIVO DENTRO DEL PROYECTO
                stRutaDestino = Server.MapPath(@"~\Images\Restaurantes\Menu\") + txtCodigoComida.Text + Path.GetExtension(fuImagen.FileName); //RUTA DE DESTINO DONDE QUEDAN LAS IMAGENES

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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GridView gvwDatos = new GridView();
                Logica.BL.clsComida obclsComida = new Logica.BL.clsComida();

                List<Logica.Models.clstbComida> listComida = obclsComida.getComida();
                gvwDatos.DataSource = listComida;
                gvwDatos.DataBind();
                lbOpcion.Text = "1";

                if (Session["sesionLogin"] != null)
                {
                    stLogin = Session["sesionLogin"].ToString();

                }

            }


        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string stMensaje = string.Empty;
                if (string.IsNullOrEmpty(txtNombreC.Text)) stMensaje += "Ingrese Nombre de la Comida, ";
                if (string.IsNullOrEmpty(txtValorC.Text)) stMensaje += "Ingrese Valor de la Comida, ";
                if (string.IsNullOrEmpty(txtDescripcionC.Text)) stMensaje += "Ingrese Descripcion, ";
                if (!string.IsNullOrEmpty(stMensaje)) throw new Exception(stMensaje.TrimEnd(','));

                if (!string.IsNullOrEmpty(lbOpcion.Text))
                {
                    Logica.BL.clsComida obclstbComida = new Logica.BL.clsComida();
                    Controller.AdministrarRestauranteController obadministrarRestauranteController = new Controller.AdministrarRestauranteController();
                    DataSet dsConsulta = obadministrarRestauranteController.getConsultarRestautanteCodigo(stLogin);

                    if (lbOpcion.Text.Equals("1"))
                    {

                        Logica.Models.clstbComida obMclstbComida = new Logica.Models.clstbComida
                        {
                            longcomiCodigo = Convert.ToInt64(txtCodigoComida.Text),
                            loncomiValor = Convert.ToInt64(txtValorC),
                            strcomiDescripcion = txtDescripcionC.Text,
                            strcomiRutaImagen = stRutaDestino,
                            obclstbCategoria = new Logica.Models.clstbCategoria
                            {
                                longcateCodigo = Convert.ToInt64(ddlCategoria.SelectedValue)
                            },
                            obclstbRestaurante = new Logica.Models.clstbRestaurante
                            {
                                longrestCodigo = Convert.ToInt64(dsConsulta.Tables[0].Rows)
                            }


                        };
                        Controller.AdministrarComidaController oadministrarComidaController = new Controller.AdministrarComidaController();
                        ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('APROBADO!', '" + oadministrarComidaController.addOpcionController(obMclstbComida) + "!', 'success')</Script>");


                    }
                    else if (lbOpcion.Text.Equals("2"))
                    {



                    }
                    else if (lbOpcion.Text.Equals("3"))
                    {




                    }
                   }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");



            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int inIndice = Convert.ToInt32(e.CommandArgument);//Define que fila es.. CommandArgument
                if (e.CommandName.Equals("Modificar"))
                {
                    lbOpcion.Text = "2";
                }
            }
            //Accede a un control web dentro de un grid
            /*txtCodigoComida.Text = string.IsNullOrEmpty(((Label)gvwDatos.Rows[inIndice].FindControl("CodigoComida")).Text) ? string.Empty : ((Label)gvwDatos.Rows[inIndice].FindControl("CodigoComida")).Text;
            txt.Text = gvwDatos.Rows[inIndice].Cells[1].Text.Equals("&nbsp;") ? string.Empty : (gvwDatos.Rows[inIndice].Cells[1].Text);
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

        }*/

            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>"); }


        }

    }
}
            