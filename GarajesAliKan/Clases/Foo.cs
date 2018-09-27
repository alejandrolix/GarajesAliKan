using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PetaPoco;

namespace GarajesAliKan.Clases
{
    /// <summary>
    /// Contiene métodos estáticos que se utilizan en varias clases.
    /// </summary>
    class Foo
    {
        /// <summary>
        /// Realiza una conexión a la base de datos.
        /// </summary>
        /// <returns>La conexión de la base de datos.</returns>
        public static Database ConexionABd()
        {
            StreamReader leer = new StreamReader(@"..\..\..\DatosConexion.txt", Encoding.UTF8);
            string datosConexion = leer.ReadLine();
            leer.Close();

            return new Database(datosConexion, "MySql.Data.MySqlClient");
        }
    }
}
