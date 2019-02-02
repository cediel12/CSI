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
    public partial class ListaBicicletas : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        public DataTable dt,todo;
        public DataRow dr,drtodo;
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
                if (!IsPostBack)
                {
                    if (Session["rol"].ToString() == "Empresa")
                    {
                        //lista.DataSource = u.ConsultarBicicletasempresa(Convert.ToInt32(Session["IDEMPRESA"].ToString()));
                        //lista.DataBind();
                        todo = u.ConsultarBicicletasempresa(Convert.ToInt32(Session["IDEMPRESA"].ToString()));
                    } else {
                        //lista.DataSource = u.ConsultarBicicletas();
                        //lista.DataBind();
                        todo = u.ConsultarBicicletas();
                        
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
            if (e.CommandName.Equals("registrar"))
            {
                dt = u.maximodealquileres(Session["IDCliente"].ToString());
                dr = dt.Rows[0];
                int max = Convert.ToInt32(dr["reserva"].ToString());
                if (max<2)
                {
                    Session["AlquilerBicicleta"] = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("../Menu/Alquilar.aspx");
                }else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alertme()", true);
                }
                
            }
            if (e.CommandName.Equals("eliminar"))
            {
                
            }
            if (e.CommandName.Equals("modificar"))
            {
                
            }
        }
    }
}