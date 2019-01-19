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
    public partial class GestionarUsuarioEmpresa : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable empresa;
        DataRow drempresa;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Estado"].ToString() != "OK")
                {
                    Response.Redirect("../Home/Login.aspx");
                }
                empresa = u.rolempresa(Session["IDUSER"].ToString());
                if (empresa.Rows.Count > 0)
                {
                    drempresa = empresa.Rows[0];
                    nombre.Text = drempresa["nombre_empresa"].ToString();
                    direccion.Text = drempresa["dirrecion_empresa"].ToString();
                    telefono.Text = drempresa["telefono_empresa"].ToString();
                }
            }
            catch
            {
                Response.Redirect("../Home/Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombre.Text) || string.IsNullOrEmpty(direccion.Text) || string.IsNullOrEmpty(telefono.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Datos ingresados no validos');", true);
            }
            else
            {
                //if (u.actualizarcliente(nombre.Text, direccion.Text, Convert.ToInt32(telefono.Text), Convert.ToInt32(Session["IDEMPRESA"].ToString())))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Datos Actualizados correctamente');", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Los datos no se han podido actualizar');", true);
                //}
            }
        }
    }
}