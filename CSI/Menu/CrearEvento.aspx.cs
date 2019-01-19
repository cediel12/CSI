using CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class CrearEvento : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
        protected void crear_evento(object sender, EventArgs e)
        {
            int idempresa = Convert.ToInt32(Session["IDEMPRESA"].ToString());
            if (u.crear_evento(nombreevento.Text, fechafin.Text, hora.Text, idempresa))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Evento creado correctamente');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Evento no se ha creado correctamente');", true);
            }
        }
    }
}