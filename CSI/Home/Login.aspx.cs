using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSI.Models;
using System.Data;

namespace CSI.Home
{
    public partial class Login : System.Web.UI.Page
    {
        Usuario u = new Usuario();
        DataTable dt, admin, cliente, empresa;
        string rol;
        DataRow dr, dadmin, dempresa, dcliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            username.Attributes.Add("autocomplete", "off");
            password.Attributes.Add("autocomplete", "off");

        }

        protected void IniciarSesion(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(username.Text) && !string.IsNullOrWhiteSpace(password.Text))
            {
                dt = u.ValidarPersona(username.Text, password.Text);
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    Session["Estado"] = "OK";
                    Session["IDUSER"] = dr["id_correo"].ToString();
                    string iduser= dr["id_correo"].ToString();
                    //Session["correo"] = dr["correo"].ToString();
                    rol = dr["rol_usuario_id_rol_usuario"].ToString();
                    Session["roldefinido"]= dr["rol_usuario_id_rol_usuario"].ToString();
                    if (!string.IsNullOrWhiteSpace(rol))
                    {
                        if (rol == "3")
                        {
                            Session["rol"] = "Administrador";
                            admin = u.roladmin(iduser);
                            if (admin.Rows.Count > 0)
                            {
                                dadmin = admin.Rows[0];
                                Session["Nombre"] = dadmin["nombre_administrador"].ToString();
                            }
                        }
                        else if (rol == "1")
                        {
                            Session["rol"] = "Cliente";
                            cliente = u.rolcliente(iduser);
                            if (cliente.Rows.Count > 0)
                            {
                                dcliente = cliente.Rows[0];
                                Session["Nombre"] = dcliente["nombre_cliente"].ToString() + " " + dcliente["apellido_cliente"].ToString();
                            }
                        }
                        else if (rol == "2")
                        {
                            Session["rol"] = "Empresa";
                            empresa = u.rolempresa(iduser);
                            if (empresa.Rows.Count > 0)
                            {
                                dempresa = empresa.Rows[0];
                                Session["Nombre"] = dempresa["nombre_empresa"].ToString();
                                Session["IDEMPRESA"] = dempresa["id_empresa"];
                            }
                        }
                    }
                    Response.Redirect("../Menu/Home.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Datos ingresados no validos');", true);
            }
        }

        protected void registrar(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}