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
                Response.Redirect("../Home/Login.aspx");
            }


        }

        public void salir(object sender, EventArgs e)
        {
            Session["Estado"] = "1";
            Session["IDUSER"] = "1";
            Session["Nombre"] = "1";
            Session["rol"] = "1";
            Response.Redirect("../Home/Login.aspx");
        }
    }
}