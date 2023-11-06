using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBaseDatos.Controlador
{
    internal class ControladorConexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "dualtec";
            string usuario = "root";
            string password = "Magdiel@123";

            string cadenaConexion = "Database=" + bd + "; Data Source=" +
                servidor + "; User Id=" + usuario + "; Password=" + password + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
