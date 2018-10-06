using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Restaurante
{
    public partial class Menu : System.Web.UI.Page
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
                stRutaDestino = Server.MapPath(@"~\Images\Personas\") + txtNombreC.Text + Path.GetExtension(fuImagen.FileName); //RUTA DE DESTINO DONDE QUEDAN LAS IMAGENES

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
        void getLimpiar() {txtNombreC.Text=txtValorC.Text=txtDescripcionC.Text = string.Empty; }
        protected void Page_Load(object sender, EventArgs e)
        {

            lbOpcion.Text = "1";
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnGuardarC_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelarC_Click(object sender, EventArgs e)
        {

        }
        protected void btnBuscador_Click(object sender, EventArgs e)
        {

        }
    }
}