using CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString() == "OK")
                {
                    MenuControlador me = new MenuControlador();
                    Usuario u = new Usuario();
                    me.CargarMenu(Session["roldefinido"].ToString(), menudinamico);

                }

            }
            catch
            {
                Response.Redirect("../Inicio/Login.aspx");
            }
        }
    }
}