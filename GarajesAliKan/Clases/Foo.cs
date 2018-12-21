using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    /// <summary>
    /// Contiene métodos estáticos que se utilizan en varias clases.
    /// </summary>
    class Foo
    {
        /// <summary>
        /// Realiza una conexión a la base de datos usando el driver de MySQL.
        /// </summary>
        /// <returns>La conexión de la base de datos.</returns>
        public static MySqlConnection ConexionABd()
        {
            string datosConexion = LeerArchivoConexion();
            MySqlConnection conexion = new MySqlConnection(datosConexion);
            conexion.Open();

            return conexion;
        }

        /// <summary>
        /// Lee el archivo para obtener los datos de conexión de la base de datos.
        /// </summary>
        /// <returns>Los datos de conexión.</returns>
        private static string LeerArchivoConexion()
        {
            StreamReader leer = new StreamReader(@"..\..\..\DatosConexion.txt", Encoding.UTF8);
            string datosConexion = leer.ReadLine();
            leer.Close();

            return datosConexion;
        }

        /// <summary>
        /// Guarda la fecha de hoy para realizar el backup de la base de datos.
        /// </summary>
        public static void GuardarFechaActual()
        {
            StreamWriter escribir = new StreamWriter(@"..\..\..\FechaBackupBD.txt", false, Encoding.UTF8);
            escribir.WriteLine(DateTime.Now.ToString("dd-MM-yyyy"));

            escribir.Close();
        }

        /// <summary>
        /// Lee la fecha guardada para compararla con la de hoy.
        /// </summary>
        /// <returns>La fecha guardada</returns>
        public static DateTime ObtenerFechaGuardada()
        {
            StreamReader leer = new StreamReader(@"..\..\..\FechaBackupBD.txt", Encoding.UTF8);
            DateTime fecha = DateTime.Parse(leer.ReadLine());

            leer.Close();
            return fecha;
        }

        /// <summary>
        /// Inserta la fecha y hora de la realización del backup de la base de datos.
        /// </summary>
        public static void InsertarFechaHoraBackup()
        {
            MySqlConnection conexion = ConexionABd();
            MySqlCommand comando = new MySqlCommand("INSERT INTO backupsBD (fechaHoraCopia) VALUES (@fecha);", conexion);

            comando.Parameters.AddWithValue("@fecha", DateTime.Now);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        /// <summary>
        /// Exporta la base de datos a un fichero SQL.
        /// </summary>
        public static void ExportarBD()
        {
            MySqlConnection conexion = ConexionABd();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexion;

            MySqlBackup mySqlBackup = new MySqlBackup(comando);
            mySqlBackup.ExportToFile(@"C:\BdGarajes\bd.sql");

            conexion.Close();
        }
    }
}
