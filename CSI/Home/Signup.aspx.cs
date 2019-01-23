using CSI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSI.Home
{
    public partial class Signup : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        public DataTable dtconsulta;
        public DataRow drconsulta;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registrar(object sender, EventArgs e)
        {
            string usuario = String.Format("{0}", Request.Form["usuario"]);
            string contraseña = String.Format("{0}", Request.Form["contraseña"]);
            string nombre = String.Format("{0}", Request.Form["nombre"]);
            string apellido = String.Format("{0}", Request.Form["apellido"]);
            string edad = String.Format("{0}", Request.Form["edad"]);
            dtconsulta = u.consultarusuarioregistro(usuario);
            if (dtconsulta.Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alertme()", true);
            }
            else
            {
                if (u.registrarusuario(nombre, apellido, edad, usuario, contraseña))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El registro se completo correctamente');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Ocurrio un error durante el registro');", true);
                }
                Response.Redirect("Login.aspx");
            }
        }
    }
}