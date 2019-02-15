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
    public partial class RegistrarEmpresa : System.Web.UI.Page
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
            string direccion = String.Format("{0}", Request.Form["direccion"]);
            string telefono = String.Format("{0}", Request.Form["telefono"]);
            string nit = String.Format("{0}", Request.Form["nit"]);
            string correo = String.Format("{0}", Request.Form["correo"]);

            dtconsulta = u.consultarusuarioregistro(usuario);
            EnsureChildControls();
            if (dtconsulta.Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randontext", "alertme()", true);
            }
            else
            {
                if (u.registrarempresa(usuario,contraseña,nombre,direccion,telefono,correo,nit))
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