using CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class Alquilar : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Estado"].ToString() != "OK")
            {
                Response.Redirect("../Home/Login.aspx");
            }
            else
            {
                Page.Form.Enctype = "multipart/form-data";
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            if (u.alquilarbicicleta(fechafin.Text,fechainicio.Text, Convert.ToInt32(Session["IDCliente"].ToString()), Convert.ToInt32(Session["AlquilerBicicleta"].ToString())))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Alquiler realizado');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se realizo el alquiler');", true);
            }
        }
    }
}