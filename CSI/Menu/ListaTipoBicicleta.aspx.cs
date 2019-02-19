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
    public partial class ListaTipoBicicleta : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable dt;
        DataRow consumo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Administrar / Lista Tipos Bicicletas";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    lista.DataSource = u.TipoBicicletas();
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
            if (e.CommandName.Equals("modificar"))
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Session["idmoditipo"] = id;
                dt = u.culsutartipobiciunico(id);
                consumo = dt.Rows[0];
                tipo.Text = consumo["nombre_tipo_bicicleta"].ToString();
                descripcion.Text = consumo["descripcion_tipo_bicleta"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            }
            if (e.CommandName.Equals("eliminar"))
            {
                if (u.eliminartipobici(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "eliminartipobici()", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se realizo la eliminacion');", true);
                }
            }
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            string tip = tipo.Text.ToString();
            string descrip = descripcion.Text.ToString();
            if (u.modificartipobici(Convert.ToInt32(Session["idmoditipo"].ToString()),tip,descrip))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "modificartipobici()", true);

            }else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se realizo la modificacion');", true);
            }
        }
    }
}