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
    public partial class ListaEventosInscritos : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    int iduser = Convert.ToInt32(Session["IDUSER"].ToString());
                    lista.DataSource = u.eventosinscritosconsulta(iduser);
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
            if (e.CommandName.Equals("cancelar"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (u.eliminarinscripcionevento(id))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Se cancelo la inscripcion correctamente');", true);
                }
            }
            Response.Redirect("../Menu/ListaEventosInscritos.aspx");
        }
    }
}