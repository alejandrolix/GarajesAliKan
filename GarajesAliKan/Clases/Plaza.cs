using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajesAliKan.Clases
{
    class Plaza
    {        
        public int IdCliente { get; set; }        
        public string NombrePlaza { get; set; }

        /// <summary>
        /// Obtiene todas las plazas de garajes y trasteros de los clientes.
        /// </summary>
        /// <returns>Las plazas de garajes y trasteros de los clientes.</returns>
        public static List<Plaza> ObtenerPlazas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT idCliente, plaza
                                                      FROM   plazaClientes
                                                      ORDER BY plaza;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Plaza> listaPlazas = new List<Plaza>();

            while (cursor.Read())
            {
                Plaza plaza = new Plaza(cursor.GetInt32("idCliente"), cursor.GetString("plaza"));
                listaPlazas.Add(plaza);
            }
            cursor.Close();
            conexion.Close();

            return listaPlazas;
        }

        public Plaza(int idCliente, string nombrePlaza)
        {
            IdCliente = idCliente;
            NombrePlaza = nombrePlaza;
        }
    }
}
