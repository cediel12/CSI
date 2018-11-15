using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace CSI.Models
{
    public class Usuario
    {
        Conexion co = new Conexion();
        public DataTable ValidarPersona(string usuario, string contrasenia)
        {
            string sql = "SELECT * FROM cilcicaq.usuario WHERE nombre_usuario = '" + usuario + "' AND constrasena_usuario = '" + contrasenia + "';";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable roladmin(string rol)
        {
            string sql = "SELECT * FROM cilcicaq.administrador where usuario_id_correo=" + rol + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable rolcliente(string rol)
        {
            string sql = "SELECT * FROM cilcicaq.cliente where usuario_id_correo=" + rol + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable rolempresa(string rol)
        {
            string sql = "SELECT * FROM cilcicaq.empresa where usuario_id_correo=" + rol + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable menu(string idCuenta)
        {

            string sql = "select  vista_aplicativo.id_vista_aplicativo,vista_aplicativo.titulo, vista_aplicativo.icono, menu.idmenu, menu.title, menu.url, menu.idmenu,menu.icon from cilcicaq.menu inner join cilcicaq.vista_aplicativo on menu.vista_id_vista_aplicativo=vista_aplicativo.id_vista_aplicativo inner join cilcicaq.rol_usuario_has_vista_aplicativo on vista_aplicativo.id_vista_aplicativo=rol_usuario_has_vista_aplicativo.vista_aplicativo_id_vista_aplicativo inner join cilcicaq.rol_usuario on rol_usuario_has_vista_aplicativo.rol_usuario_id_rol_usuario=rol_usuario.id_rol_usuario where rol_usuario.id_rol_usuario=" + idCuenta + "; ";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }

    }
}