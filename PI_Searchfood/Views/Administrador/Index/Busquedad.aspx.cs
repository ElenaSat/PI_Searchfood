using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Views.Administrador.Index
{
    public partial class Busquedad : System.Web.UI.Page
    {
        public void cargarRestaurantes( string valor) {
            try
            {
                Controller.BuscadorController obbuscadorController = new Controller.BuscadorController();
               List<Logica.Models.clstbRestaurante> listRest =obbuscadorController.getBuquedadRestController(valor);
               if (listRest!=null) { grvbusqueda.DataSource = listRest; } else { grvbusqueda.DataSource = null; }
                grvbusqueda.DataBind();

            }
            catch (Exception ex)
            { ClientScript.RegisterStartupScript(this.GetType(), "Mesaje", "<Script> swal('ERROR!', '" + ex.Message + "!', 'error')</Script>");}

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarRestaurantes("Ensaladas");
        }

        protected void grvbusqueda_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            cargarRestaurantes(txtBuscar.Text);

        }
    }
}