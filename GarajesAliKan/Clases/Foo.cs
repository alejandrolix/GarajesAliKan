using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.IO;

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
        public static IMongoDatabase ConexionABd()
        {
            StreamReader leer = new StreamReader("DatosConexion.txt", Encoding.UTF8);
            string[] datosConexion = leer.ReadLine().Split(';');
            leer.Close();            

            MongoClient conexion = new MongoClient(datosConexion[0]);            
            return conexion.GetDatabase(datosConexion[1]);
        }
    }
}
