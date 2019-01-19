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
    public partial class CrearBicicleta : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        public DataTable dtconsulta = new DataTable();
        public DataRow drconsulta;
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
                    dtconsulta = u.TipoBicicletas();
                    if (dtconsulta.Rows.Count > 0)
                    {
                        drconsulta = dtconsulta.Rows[0];
                        for (int i = 0; i < dtconsulta.Rows.Count; i++)
                        {
                            drconsulta = dtconsulta.Rows[i];
                            eventos.Items.Add(drconsulta["nombre_tipo_bicicleta"].ToString().ToUpper());
                        }
                    }
                }

            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
        protected void crear_bicicleta(object sender, EventArgs e)
        {
            int selection = 0;
            selection = Convert.ToInt32(eventos.SelectedIndex);
            if (u.crear_bicicleta(nombrebici.Text, Convert.ToInt32(Session["IDEMPRESA"].ToString()), selection, Convert.ToInt32(valor.Text)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bicicleta creada correctamente');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bicicleta no se creada correctamente');", true);
            }            
        }
    }
}