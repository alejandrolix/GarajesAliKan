using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPoco;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    /// <summary>
    /// Contiene métodos estáticos que se utilizan en varias clases.
    /// </summary>
    class Foo
    {
        /// <summary>
        /// Realiza una conexión a la base de datos usando el micro ORM NPoco.
        /// </summary>
        /// <returns>La conexión de la base de datos.</returns>
        public static Database ConexionABd()
        {
            string datosConexion = LeerArchivoConexion();
            return new Database(datosConexion, "MySql.Data.MySqlClient");             
        }

        /// <summary>
        /// Realiza una conexión a la base de datos usando el driver de MySQL.
        /// </summary>
        /// <returns>La conexión de la base de datos.</returns>
        public static MySqlConnection ConexionABdMySQL()
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
    }
}
