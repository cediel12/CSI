using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CSI.Models
{
    public class Conexion
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["Event_Connection"].ConnectionString);
        private string stringConnection = ConfigurationManager.ConnectionStrings["Event_Connection"].ConnectionString;
        private bool Conectar()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void Desconectar()
        {
            conexion.Close();
        }
        public MySqlConnection ConexionMySQL()
        {
            MySqlConnection Connection = new MySqlConnection(stringConnection);

            try
            {
                Connection.Open();
            }
            catch (Exception exc)
            {
                throw new Exception("No se realizó la conexión a la base de pameters: " + exc.Message);
            }

            return Connection;
        }
        public DataTable EjecutarConsulta(string sentencia, CommandType TipoComando)
        {
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = new MySqlCommand(sentencia, conexion);
            adaptador.SelectCommand.CommandType = TipoComando;

            DataSet resultado = new DataSet();
            adaptador.Fill(resultado);

            return resultado.Tables[0];
        }
        public bool RealizarTransaccion(string[] cadena)
        {
            bool state = false;
            if (Conectar())
            {
                MySqlTransaction Transa = conexion.BeginTransaction();
                MySqlCommand cmd = null;
                try
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i].Length > 0)
                        {
                            cmd = new MySqlCommand(cadena[i], conexion);
                            cmd.Transaction = Transa;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Transa.Commit();
                    conexion.Close();
                    conexion.Dispose();
                    Transa.Dispose();
                    Desconectar();
                    state = true;
                }
                catch
                {
                    Transa.Rollback();
                    conexion.Close();
                    conexion.Dispose();
                    Desconectar();
                    state = false;
                }
                finally
                {
                    // Recolectamos objetos para liberar su memoria.
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return state;
        }
    }
}