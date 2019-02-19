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
            string sql = "SELECT * FROM cilcicaq.usuario WHERE nombre_usuario = '" + usuario + "' AND constrasena_usuario = password('" + contrasenia + "');";
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
            string sql = "select id_evento,hora, nombre_evento, date_format(fecha_evento, ' %d/%c/%Y') as fecha_evento,lugar , nombre_empresa from cilcicaq.evento inner join cilcicaq.empresa on id_empresa=empresa_id_empresa and fecha_evento>curdate();";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarEventosempresa(int a)
        {
            string sql = "select id_evento,hora, nombre_evento, date_format(fecha_evento, ' %d/%c/%Y') as fecha_evento,lugar , nombre_empresa from cilcicaq.evento inner join cilcicaq.empresa on id_empresa=empresa_id_empresa and fecha_evento>curdate() and id_empresa="+a+";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarBicicletas()
        {
            string sql = "SELECT id_bicicleta,cantidad,imagen,nombre_bicicleta,talla,valor_bicicleta, estado_bicicleta,nombre_tipo_bicicleta,nombre_empresa from cilcicaq.bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where estado_bicicleta='Disponible' and cantidad>0;";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable ConsultarBicicletasempresa(int idempresa)
        {
            string sql = "SELECT id_bicicleta,cantidad,imagen,nombre_bicicleta,valor_bicicleta, talla, estado_bicicleta,nombre_tipo_bicicleta,nombre_empresa from cilcicaq.bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where empresa_id_empresa=" + idempresa + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool crear_bicicleta(string nombrebicicleta, int idempresa, int idtipobicicleta, int valor, string imagen,string talla,int cantidad)
        {
            string[] sql = new string[1];
            //sql[0] = "CALL `cilcicaq`.`crear_bicicleta`('" + nombrebicicleta + "'," + idempresa + "," + idtipobicicleta +"," + valor +",'"+tipo+"','"+imagen+"');";
            sql[0] = "call cilcicaq.crear_bicicleta('"+nombrebicicleta+"', "+idempresa+","+ idtipobicicleta + ","+ valor+", '"+talla+"', '"+imagen+"',"+cantidad +");";
            return co.RealizarTransaccion(sql);
        }
        public DataTable TipoBicicletas()
        {
            string sql = "SELECT * FROM cilcicaq.tipo_bicicleta;";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool crear_evento(string nombreevento, string fechaevento, string hora, int idempresa, string lugar,string descripcion)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.crear_evento('"+nombreevento+"', '"+fechaevento+"', '"+ hora + "',"+ idempresa + ", '"+ lugar + "', '"+ descripcion + "');";
            return co.RealizarTransaccion(sql);
        }        
        public bool inscrbirevento(int idevento, int idcliente)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.inscribirevento(" + idevento + "," + idcliente + ");";
            return co.RealizarTransaccion(sql);
        }
        public bool creartipobicicleta(string tipo, string descripcion)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.creartipobicicleta('" + tipo + "','" + descripcion + "');";
            return co.RealizarTransaccion(sql);
        }
        public DataTable consultarinscripcionevento(int iduser, int idevento)
        {
            string sql = "SELECT * FROM cilcicaq.evento_usuario where evento_id_evento=" + idevento + " and usuario_id_usuario=" + iduser + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable culsutartipobiciunico(int idbici)
        {
            string sql = "SELECT * FROM cilcicaq.tipo_bicicleta where id_tipo_bicicleta=" + idbici + ";";
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
        public bool modificartipobici(int idtipo,string tipo, string descrip)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.tipo_bicicleta set nombre_tipo_bicicleta='"+tipo+"', descripcion_tipo_bicleta='"+descrip+"' where id_tipo_bicicleta=" + idtipo + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool eliminartipobici(int idtipo)
        {
            string[] sql = new string[1];
            sql[0] = "delete from cilcicaq.tipo_bicicleta where id_tipo_bicicleta=" + idtipo + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool actualizarcliente(string nombre, string apellido, string edad, string idcliente)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.cliente set nombre_cliente='" + nombre + "', apellido_cliente='" + apellido + "', edad_cliente=" + edad + ", where usuario_id_correo=" + idcliente + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool actualizarempresa(string nombre, string apellido, string edad, string idcliente)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.cliente set nombre_cliente='" + nombre + "', apellido_cliente='" + apellido + "', edad_cliente=" + edad + ", where usuario_id_correo=" + idcliente + ";";
            return co.RealizarTransaccion(sql);
        }
        public DataTable listadealquileres(int iduser)
        {
            string sql = "select nombre_bicicleta, valor,codigoalquiler,alquiladas, nombre_empresa,date_format( fechafin, ' %d/%c/%Y') as  fechafin,date_format( fechainicio, ' %d/%c/%Y') as  fechainicio,estado, id_alquiler,nombre_tipo_bicicleta from cilcicaq.alquiler inner join cilcicaq.bicicleta on bicicleta_id_bicicleta=id_bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where fk_id_cliente=" + iduser + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable listaempresas()
        {
            string sql = "SELECT * FROM cilcicaq.empresa;";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable listadealquileresempresa(int iduser)
        {
            string sql = "select nombre_bicicleta, valor,codigoalquiler,alquiladas, nombre_empresa,date_format( fechafin, ' %d/%c/%Y') as  fechafin,date_format( fechainicio, ' %d/%c/%Y') as  fechainicio,estado, id_alquiler,nombre_tipo_bicicleta from cilcicaq.alquiler inner join cilcicaq.bicicleta on bicicleta_id_bicicleta=id_bicicleta inner join cilcicaq.empresa on id_empresa=empresa_id_empresa inner join cilcicaq.tipo_bicicleta on id_tipo_bicicleta=tipo_bicicleta_id_bicicleta where id_empresa=" + iduser + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable cargarpais()
        {
            string sql = "SELECT * FROM cilcicaq.pais;";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable cargardepartamentos(int a)
        {
            string sql = "SELECT * FROM cilcicaq.departamento where fk_id_pais=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable cargarciudad(int a)
        {
            string sql = "SELECT * FROM cilcicaq.ciudad where fk_id_departamento=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable consultarusuarioregistro(string a)
        {
            string sql = "SELECT * FROM cilcicaq.usuario where nombre_usuario='" + a + "';";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool registrarusuario(string nombre, string apellido, string edad, string usuario, string contraseña,string correo)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.registrar('"+usuario+"', '"+contraseña+"', '"+nombre+"', '"+apellido+"', '"+edad+"', '"+correo+"');";
            return co.RealizarTransaccion(sql);
        }
        public bool registrarempresa(string usuario, string contraseña,string nombreempresa,string direccion,string telefono,string correo, string nit)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.registrarempresa('"+usuario+"', '"+contraseña+"', '"+nombreempresa+"', '"+direccion+"', '"+telefono+"', '"+correo+"', '"+nit+"');";
            return co.RealizarTransaccion(sql);
        }
        public bool alquilarbicicleta(string fechainicio, string fechafin, int codigoalquiler, int alquiladas, int valor,int idcliente, int idbici)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.alquilarbicicleta('"+fechainicio+"', '"+fechafin+"', "+codigoalquiler+", "+alquiladas+","+ valor+", "+idcliente+", "+idbici+");";
            return co.RealizarTransaccion(sql);
        }
        
        public DataTable maximodealquileres(string a)
        {
            string sql = "SELECT count(fk_id_cliente) as reserva from cilcicaq.alquiler where fk_id_cliente=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable consultaralquiler(string a)
        {
            string sql = "SELECT * FROM cilcicaq.alquiler where id_alquiler=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool eliminaralquiler(string idalquiler)
        {
            string[] sql = new string[1];
            sql[0] = "delete from cilcicaq.alquiler where id_alquiler=" + idalquiler +";";
            return co.RealizarTransaccion(sql);
        }
        public DataTable consultarcontracambiopass(int a, string b)
        {
            string sql = "SELECT * FROM cilcicaq.usuario where id_correo=" + a + " and constrasena_usuario='" + b + "';";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool cambiarcontrapass(string a, string b)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.usuario set constrasena_usuario=" + a + "where id_correo=" + b + ";";
            return co.RealizarTransaccion(sql);
        }
        public DataTable consulcantidad(int a)
        {
            string sql = "SELECT * FROM cilcicaq.bicicleta where id_bicicleta=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable consumodievento(int a)
        {
            string sql = "SELECT * FROM cilcicaq.evento where id_evento=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable descripcionbicicleta(string a)
        {
            string sql = "SELECT * FROM cilcicaq.tipo_bicicleta where nombre_tipo_bicicleta='" + a + "';";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }        
        public DataTable consultarcodigoallquiler(int a)
        {
            string sql = "SELECT * FROM cilcicaq.alquiler where codigoalquiler=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }        
        public DataTable consultardescripcionevento(int a)
        {
            string sql = "SELECT * FROM cilcicaq.evento where id_evento=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public DataTable consultarfechasalquiler(int a)
        {
            string sql = "SELECT fechainicio,fechafin,alquiladas FROm cilcicaq.alquiler where bicicleta_id_bicicleta=" + a + ";";
            return co.EjecutarConsulta(sql, CommandType.Text);
        }
        public bool modificarbici(string nombre,string talla, int valor, int cantidad,int idbici,int tipobici)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.bicicleta set nombre_bicicleta='"+nombre+"',talla='"+talla+"',valor_bicicleta="+valor+",cantidad="+cantidad+ ", tipo_bicicleta_id_bicicleta="+tipobici + " where id_bicicleta=" + idbici + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool actualizarpass(int id, string oldpas, string newpas)
        {
            string[] sql = new string[1];
            sql[0] = "call cilcicaq.Actualizar_password(" + id + ",'" + oldpas + "','" + newpas + "');";
            return co.RealizarTransaccion(sql);
        }
        public bool eliminarbicicleta( int id)
        {
            string[] sql = new string[1];
            sql[0] = "delete from cilcicaq.bicicleta where id_bicicleta=" + id + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool modificarevento(int idevento,string nombre,string fecha, string hora, string lugar, string descripion)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.evento set nombre_evento='"+nombre+"', fecha_evento='"+fecha+"', hora='"+hora+"',lugar='"+lugar+"',descripcion='"+descripion+"' where id_evento=" + idevento + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool eliminarevento(int idevento)
        {
            string[] sql = new string[1];
            sql[0] = "delete from cilcicaq.evento where id_evento=" + idevento + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool cancelaralquier(string idalquiler)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.alquiler set estado='Cancelado' where id_alquiler=" + idalquiler + ";";
            return co.RealizarTransaccion(sql);
        }
        public bool confirmaralquiler(string idalquiler)
        {
            string[] sql = new string[1];
            sql[0] = "update cilcicaq.alquiler set estado='Confirmado' where id_alquiler=" + idalquiler + ";";
            return co.RealizarTransaccion(sql);
        }
    }
}