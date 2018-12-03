using CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class ListaEventos : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Estado"].ToString() != "OK")
            {
                Response.Redirect("../Inicio/Login.aspx");
            }
            if (!IsPostBack)
            {
                lista.DataSource = u.ConsultarEventos();
                lista.DataBind();
            }
        }
        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("registrar"))
            {

            }
        }
    }
}