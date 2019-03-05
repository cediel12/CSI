using CSI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class MisBicicletas : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Bicicletas / Lista de Alquiladas";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    lista.DataSource = u.listadealquileresempresa(Convert.ToInt32(Session["IDEMPRESA"].ToString()));
                    lista.DataBind();
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }

        }
        public void cancelaralquiler(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("cancelar"))
            {
                dt = u.consultaralquiler(e.CommandArgument.ToString());                
                if (u.cancelaralquier(e.CommandArgument.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cancelaralquiler();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se elimino');", true);
                }
            }
            if (e.CommandName.Equals("confirmar"))
            {
                dt = u.consultaralquiler(e.CommandArgument.ToString());
                if (u.confirmaralquiler(e.CommandArgument.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "confirmaralquiler();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se elimino');", true);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}