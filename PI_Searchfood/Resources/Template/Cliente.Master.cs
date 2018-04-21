using System;
using System.Collections.Generic;
using System.Data;
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
            if (!IsPostBack)
            {
                string[] stEmail = null;
                if (Session["sesionLogin"] !=null) {

                    stEmail = Session["sesionLogin"].ToString().Split('@');
                    lbUser.Text = stEmail[0];

                } else {
                    Response.Redirect("../../Views/Administrador/Login/frmLogin.aspx");

                }
            }


        }

        protected void lbSalir_Click(object sender, EventArgs e)
        {
            //tecla fin + f7 para entrar al codigo; ctlr + c para comentar en aspN y ctlr + u descomentar
            Session.RemoveAll();
            Response.Redirect("../../Views/Administrador/Login/frmLogin.aspx");

        }
    }
}