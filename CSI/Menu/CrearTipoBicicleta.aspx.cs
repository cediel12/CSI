using CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class CrearTipoBicicleta : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Administrar / Crear Tipo Bicicleta";
                Session["entrada"] = "1";

            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
        protected void crear_tipo(object sender, EventArgs e)
        {
            if (u.creartipobicicleta(tipo.Text,descripcion.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "creartipobici()", true);
            }
        }
    }
}