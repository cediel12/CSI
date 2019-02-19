using CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class ListaEmpresas : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Administrar / Lista de Empresas";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    lista.DataSource = u.listaempresas();
                    lista.DataBind();
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
    }
}