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
    public partial class UnidadesBicicleta : System.Web.UI.Page
    {
        Usuario u = new Usuario();

        protected void button4_Click(object sender, EventArgs e)
        {
            string refe = referencia.Text.ToString();
            if (u.updatereferencia(refe, Session["modibiciuni"].ToString()))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "modificarreferencia()", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Eventos / Lista de Eventos";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    if (Session["rol"].ToString() == "Empresa")
                    {
                        lista.DataSource = u.consultarunidades(Convert.ToInt32(Session["idbiciuni"].ToString()));
                        lista.DataBind();
                    }
                    else
                    {
                        lista.DataSource = u.ConsultarEventos();
                        lista.DataBind();
                    }
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("modificar"))
            {
                Session["modibiciuni"] = Convert.ToInt32(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
    }
}