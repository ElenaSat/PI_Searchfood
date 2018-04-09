using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PI_Searchfood.Resources.Template
{
    public partial class Cliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void lbSalir_Click(object sender, EventArgs e)
        {
            //tecla fin + f7 para entrar al codigo; ctlr + c para comentar en aspN y ctlr + u descomentar
            Session.RemoveAll();
            Response.Redirect("../../Views/Administrador/Login/frmLogin.aspx");

        }
    }
}