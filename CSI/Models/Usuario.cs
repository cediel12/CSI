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

            string sql = "select  vista_aplicativo.id_vista_aplicativo,vista_aplicativo.titulo, vista_aplicativo.icono, menu.vista_id_vista_aplicativo, menu.title, menu.url, menu.idmenu,menu.icon from cilcicaq.menu inner join cilcicaq.vista_aplicativo on menu.vista_id_vista_aplicativo=vista_aplicativo.id_vista_aplicativo inner join cilcicaq.rol_usuario_has_menu on menu.idmenu=rol_usuario_has_menu.menu_id_menu inner join cilcicaq.rol_usuario on rol_usuario_has_menu.rol_usuario_id_rol_usuario=rol_usuario.id_rol_usuario where rol_usuario.id_rol_usuario=" + idCuenta + "; ";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarEventos()
        {
            string sql = "select id_evento,hora, nombre_evento, date_format(fecha_evento, ' %d-%c-%Y') as fecha_evento , nombre_empresa from cilcicaq.evento inner join cilcicaq.empresa on id_empresa=empresa_id_empresa and fecha_evento>curdate();";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarBicicletas()
        {
            string sql = "SELECT id_bicicleta,nombre_bicicleta,valor_bicicleta, descripcion_bicicleta, estado_bicicleta,nombre_tipo_bicicleta,nombre_empresa from cilcicaq.bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where estado_bicicleta='Disponible';";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarBicicletasempresa(int idempresa)
        {
            string sql = "SELECT id_bicicleta,nombre_bicicleta,valor_bicicleta, descripcion_bicicleta, estado_bicicleta,nombre_tipo_bicicleta,nombre_empresa from cilcicaq.bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where empresa_id_empresa="+idempresa+";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool crear_bicicleta(string nombrebicicleta, int idempresa, int idtipobicicleta, int valor)
        {
            string[] sql = new string[1];
            sql[0] = "CALL `cilcicaq`.`crear_bicicleta`('" + nombrebicicleta + "'," + idempresa + "," + idtipobicicleta +"," + valor +")";
            return co.RealizarTransaccion(sql);
        }
        public DataTable TipoBicicletas()
        {
            string sql = "SELECT * FROM cilcicaq.tipo_bicicleta;";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool crear_evento(string nombreevento, string fechaevento,string hora, int idempresa)
        {
            string[] sql = new string[1];
            sql[0] = "CALL `cilcicaq`.`crear_evento`('" + nombreevento + "','" + fechaevento + "','"+hora +"'," + idempresa +")";
            return co.RealizarTransaccion(sql);
        }
        public DataTable consulareventos()
        {
            string sql = "SELECT nombre_evento,fecha_evento,hora,nombre_empresa from cilcicaq.evento inner join cilcicaq.empresa on empresa_id_empresa=id_empresa;";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool inscrbirevento(int idevento, int idcliente)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.inscribirevento(" + idevento + "," + idcliente + ");";
            return co.RealizarTransaccion(sql);
        }
        public DataTable consultarinscripcionevento(int iduser, int idevento)
        {
            string sql = "SELECT * FROM cilcicaq.evento_usuario where evento_id_evento="+idevento+" and usuario_id_usuario="+ iduser+";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable eventosinscritosconsulta(int iduser)
        {
            string sql = "SELECT idEvento_Usuario,nombre_evento,date_format(fecha_evento, ' %d/%c/%Y') as fecha_evento,hora,nombre_empresa from cilcicaq.evento inner join cilcicaq.empresa on empresa_id_empresa=id_empresa inner join evento_usuario on evento_id_evento=id_evento and usuario_id_usuario=" + iduser + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool eliminarinscripcionevento(int idevento)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.eliminarinscripcion(" + idevento + ");";
            return co.RealizarTransaccion(sql);
        }
        public bool actualizarcliente(string nombre, string apellido, string edad, string idcliente)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.cliente set nombre_cliente='"+nombre + "', apellido_cliente='"+apellido + "', edad_cliente="+ edad + ", where usuario_id_correo=" + idcliente +";";
            return co.RealizarTransaccion(sql);
        }
        public DataTable listadealquileres(int iduser)
        {
            string sql = "select nombre_bicicleta, valor_bicicleta, nombre_empresa,date_format( fechafin, ' %d/%c/%Y') as  fechafin,date_format( fechainicio, ' %d/%c/%Y') as  fechainicio, id_alquiler,nombre_tipo_bicicleta from cilcicaq.alquiler inner join cilcicaq.bicicleta on bicicleta_id_bicicleta=id_bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where fk_id_cliente=" + iduser + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
    }
}