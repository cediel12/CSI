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
    public partial class ListaEventos : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Lista de Eventos";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    lista.DataSource = u.ConsultarEventos();
                    lista.DataBind();
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("registrar"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                int iduser = Convert.ToInt32(Session["IDUSER"].ToString());
                //dt = u.consultarinscripcionevento(iduser, id);
                //if (dt.Rows.Count>0)
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "errorinscribir()", true);
                //}
                //else
                //{
                //    if (u.inscrbirevento(id, iduser) ==true)
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Su registro fue exitoso');", true);
                //    }
                //}
            }
        }
    }
}