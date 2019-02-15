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
        DataTable dt, dtcrebici;
        DataRow dr, drcrebici;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Lista de Alquiladas";
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
                string alquiladas = dr["alquiladas"].ToString();
                dtcrebici = u.consulcantidad(Convert.ToInt32(idcicla));
                drcrebici = dtcrebici.Rows[0];
                int total = Convert.ToInt32(alquiladas) + Convert.ToInt32(drcrebici["cantidad"]);
                if (u.actualizarcantidadbici(idcicla, total) && u.eliminaralquiler(e.CommandArgument.ToString(), idcicla))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Alquiler eliminado correctamente');", true);
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