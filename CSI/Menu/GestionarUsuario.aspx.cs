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
    public partial class GestionarUsuario : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable cliente;
        DataRow drcliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                cliente = u.rolcliente(Session["IDUSER"].ToString());
                if (cliente.Rows.Count>0)
                {
                    drcliente = cliente.Rows[0];
                    nombre.Text = drcliente["nombre_cliente"].ToString();
                    apellido.Text = drcliente["apellido_cliente"].ToString();
                    edad.Text = drcliente["edad_cliente"].ToString();
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombre.Text) || string.IsNullOrEmpty(apellido.Text) || string.IsNullOrEmpty(edad.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Datos ingresados no validos');", true);
            }else
            {
                string idcliente = Session["IDUSER"].ToString();
                if (u.actualizarcliente(nombre.Text,apellido.Text,edad.Text, idcliente))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Datos Actualizados correctamente');", true);
                }else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Los datos no se han podido actualizar');", true);
                }
            }
        }
    }
}