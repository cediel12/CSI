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
                Session["direccion"] = "Crear Bicicleta";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                if (!IsPostBack)
                {
                    eventos.DataSource = u.TipoBicicletas();
                    eventos.DataTextField = "nombre_tipo_bicicleta";
                    eventos.DataValueField = "id_tipo_bicicleta";
                    eventos.DataBind();
                    //dtconsulta = u.TipoBicicletas();
                    //if (dtconsulta.Rows.Count > 0)
                    //{
                    //    drconsulta = dtconsulta.Rows[0];
                    //    for (int i = 0; i < dtconsulta.Rows.Count; i++)
                    //    {
                    //        drconsulta = dtconsulta.Rows[i];
                    //        eventos.Items.Add(drconsulta["nombre_tipo_bicicleta"].ToString().ToUpper());
                    //    }
                    //}
                }

            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }
        protected void crear_bicicleta(object sender, EventArgs e)
        {
            if (fileupload1.HasFile)
            {
                string filepth = "~/scr/" + fileupload1.FileName;
                int selection = 0;
                string imagen = fileupload1.FileName;
                selection = Convert.ToInt32(eventos.SelectedValue);
                int idempresa = Convert.ToInt32(Session["IDEMPRESA"].ToString());
                fileupload1.SaveAs(MapPath(filepth));
                if (u.crear_bicicleta(nombrebici.Text, idempresa, selection, Convert.ToInt32(valor.Text), talla.Text, imagen))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "creaciondebici()", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bicicleta no se creada correctamente');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "cargarimagen()", true);
            }
        }
    }
}