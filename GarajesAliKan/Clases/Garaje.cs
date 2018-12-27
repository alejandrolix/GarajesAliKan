using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{    
    class Garaje
    {        
        public int Id { get; set; }
        public string SubId { get; set; }        
        public string Nombre { get; set; }        

        /// <summary>
        /// Obtiene todos los garajes.
        /// </summary>
        /// <returns>Los Garajes.</returns>
        public static List<Garaje> ObtenerGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nombre
                                                      FROM   garajes
                                                      ORDER BY nombre;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Garaje> listaGarajes = new List<Garaje>();

            while (cursor.Read())
            {
                Garaje garaje = new Garaje(cursor.GetInt32("id"), cursor.GetString("nombre"));
                listaGarajes.Add(garaje);
            }
            cursor.Close();
            conexion.Close();

            return listaGarajes;
        }                

        public Garaje(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Garaje()
        {
        }
    }
}
