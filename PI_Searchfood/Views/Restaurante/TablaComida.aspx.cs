using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Restaurante
{
    public partial class TablaComida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getComida_XML();
        }

        public void getComida() {
            try
            {
                Controller.AdministrarComidaController obadministrarComidaController = new Controller.AdministrarComidaController();
                List<Logica.Models.clstbComida> lstclstbComidas = obadministrarComidaController.getComidaController();
                if (lstclstbComidas.Count > 0) gvwDatos.DataSource = lstclstbComidas;
                else gvwDatos.DataSource = null;
                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }

        }

        public void getComida_XML()
        {
            try
            {
                Controller.AdministrarComidaController obadministrarComidaController = new Controller.AdministrarComidaController();
               var lstclstbComidas = obadministrarComidaController.getComidaController_XML();
                if (lstclstbComidas != null) gvwDatos.DataSource = lstclstbComidas;
                else gvwDatos.DataSource = null;
                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");
            }

        }
        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}