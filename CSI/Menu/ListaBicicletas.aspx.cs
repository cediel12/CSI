using CSI.Models;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Menu
{
    public partial class ListaBicicletas : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        public DataTable dt, todo, consulcant,descripcionbici;
        public DataRow dr, drtodo, consucan,dtdescripcionbici;
        int id, canti;

        protected void button4_Click(object sender, EventArgs e)
        {
            dt = u.maximodealquileres(Session["IDCliente"].ToString());
            dr = dt.Rows[0];
            int max = Convert.ToInt32(dr["reserva"].ToString());
            if (max < 5)
            {

                string tiempo = eventos.SelectedValue;
                int asd = Convert.ToInt32(cantidadalqui.SelectedValue.ToString());
                int cantidadfinal = Convert.ToInt32(Session["cantibicisdispo"].ToString()) - asd;
                string fechainic = fechainicio.Text.ToString();
                if (u.alquilarbicicleta(fechainic, tiempo, Convert.ToInt32(Session["IDCliente"].ToString()), id, cantidadfinal, asd))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Alquiler realizado');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se realizo el alquiler');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alertme()", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["direccion"] = "Lista de Bicicletas";
                Session["entrada"] = "1";
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                //if (!IsPostBack)
                //{
                if (Session["rol"].ToString() == "Empresa")
                {
                    todo = u.ConsultarBicicletasempresa(Convert.ToInt32(Session["IDEMPRESA"].ToString()));
                }
                else
                {
                    todo = u.ConsultarBicicletas();

                }
                //}
                rep.DataSource = todo;
                rep.DataBind();
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }


        }

        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals(""))
            {
                dt = u.maximodealquileres(Session["IDCliente"].ToString());
                dr = dt.Rows[0];
                int max = Convert.ToInt32(dr["reserva"].ToString());
                if (max < 2)
                {
                    Session["AlquilerBicicleta"] = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("../Menu/Alquilar.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alertme()", true);
                }

            }
            if (e.CommandName.Equals("registrar"))
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());
                consulcant = u.consulcantidad(id);
                consucan = consulcant.Rows[0];
                canti = Convert.ToInt32(consucan["cantidad"]);
                Session["cantibicisdispo"] = canti;
                cantidadalqui.Items.Clear();
                cantidadalqui.DataSource = CreateDataSource();
                cantidadalqui.DataTextField = "Cantidad";
                cantidadalqui.DataValueField = "Valor";
                cantidadalqui.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            }
            if (e.CommandName.Equals("modificar"))
            {

            }
            if (e.CommandName.Equals("descripcion"))
            {
                string descrip = e.CommandArgument.ToString();
                descripcionbici = u.descripcionbicicleta(descrip);
                dtdescripcionbici = descripcionbici.Rows[0];
                TextBox1.Text = dtdescripcionbici["descripcion_tipo_bicleta"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "opendescripcionbici();", true);
            }
        }
        ICollection CreateDataSource()
        {
            DataTable dt = null;
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Valor", typeof(int)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(int)));
            DataView dv = null;
            for (int a = 1; a <= canti; a++)
            {
                dt.Rows.Add(CreateRow(a, a, dt));
                dv = new DataView(dt);
            }
            return dv;

        }
        DataRow CreateRow(int Text, int Value, DataTable dt)
        {
            DataRow dr = null;
            dr = dt.NewRow();
            dr[0] = Text;
            dr[1] = Value;

            return dr;

        }
    }
}