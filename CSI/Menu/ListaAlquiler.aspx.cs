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
    public partial class ListaAlquiler : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable dt;
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Lista de Alquiler";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    lista.DataSource = u.listadealquileres(Convert.ToInt32(Session["IDCliente"].ToString()));
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
                dr = dt.Rows[0];
                string idcicla = dr["bicicleta_id_bicicleta"].ToString();
                if (u.eliminaralquiler(e.CommandArgument.ToString(),idcicla))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "eliminaralquiler()", true);
                    
                }else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se elimino');", true);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}