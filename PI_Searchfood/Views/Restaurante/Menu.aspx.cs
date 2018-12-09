using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using PI_Searchfood.wsServicios;

namespace PI_Searchfood.Views.Restaurante
{
    public partial class Menu : System.Web.UI.Page
    {

        public string stRuta = string.Empty, stRutaDestino = string.Empty;
         public string GetCodRest(string correo)
        {
            try
            {
                string codigo = string.Empty;
                Controller.AdministrarRestauranteController administrarRestauranteController = new Controller.AdministrarRestauranteController();
                DataSet dsConsulta = administrarRestauranteController.getConsultarRestautanteCodigo(correo);

                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    codigo = Convert.ToString(dsConsulta.Tables[0].Rows);

                }
                else
                {
                    return "-1";
                }

                return codigo;
            }
            catch (Exception ex)
            {

                return "-1";
            }
        }

        void getImagenFu()
        {
            if (fuImagen.HasFile)
            {
                if (Path.GetExtension(fuImagen.FileName).Equals("png") || Path.GetExtension(fuImagen.FileName).Equals("jpg"))
                    throw new Exception("Solo se permiten formatos .png o .jpg");
                stRuta = Server.MapPath(@"~\tmp\") + fuImagen.FileName;//RUTA TEMPORAL
                fuImagen.PostedFile.SaveAs(stRuta); //GUARDAR EL ARCHIVO DENTRO DEL PROYECTO
                stRutaDestino = Server.MapPath(@"~\Images\Restaurantes\Menu\") + txtNombreC.Text + Path.GetExtension(fuImagen.FileName); //RUTA DE DESTINO DONDE QUEDAN LAS IMAGENES

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
        void getLimpiar() { txtNombreC.Text = txtValorC.Text = txtDescripcionC.Text = stRuta = stRutaDestino = string.Empty; }

        void getCategoria()
        {
            try
            {
                Controller.AdministrarComidaController administrarComidaController = new Controller.AdministrarComidaController();
                List<Logica.Models.clstbCategoria> lstbCategorias = administrarComidaController.getConsultarCategoria();
                if (lstbCategorias != null)
                {
                    ddlCategoria.DataSource = lstbCategorias;
                    ddlCategoria.DataTextField = "strcateDescripcion";
                    ddlCategoria.DataValueField = "longcateCodigo";
                    ddlCategoria.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");


            }


        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            getCategoria();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnGuardarC_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtNombreC.Text) && string.IsNullOrEmpty(txtDescripcionC.Text) && string.IsNullOrEmpty(txtDescripcionC.Text) && string.IsNullOrEmpty(ddlCategoria.Text))
                {
                    getImagenFu();
                    wsServicios.wsServicios obwsServicios = new wsServicios.wsServicios();
                    Logica.Models.clstbComida obclstbComidaModel = new Logica.Models.clstbComida
                    {
                        loncomiValor = Convert.ToInt64(txtValorC.Text),
                        strcomiDescripcion = txtDescripcionC.Text,
                        strcomiRutaImagen = stRuta,
                        obclstbCategoria = new Logica.Models.clstbCategoria
                        {
                            longcateCodigo = Convert.ToInt64(ddlCategoria.SelectedValue)
                        },
                        obclstbRestaurante = new Logica.Models.clstbRestaurante
                        {
                            longrestCodigo = Convert.ToInt64(GetCodRest("br25@gmail.com")),//Colocar un metodo para el codigo
                        }
                    };
                    string json = JsonConvert.SerializeObject(obclstbComidaModel);
                    //ASSERT
                    obwsServicios.createComidaWS(json);
                    getLimpiar();

                }
                else
                {

                    throw new Exception("Por favor completar los datos");
                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }


        }



        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarC_Click(object sender, EventArgs e)
        {
            getLimpiar();
        }
        protected void btnBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDato.Text))
                {

                }
                else
                {

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}