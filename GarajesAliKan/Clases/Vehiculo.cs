using MySql.Data.MySqlClient;
using System;

namespace GarajesAliKan.Clases
{
    class Vehiculo
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        /// <summary>
        /// Inserta un vehículo.
        /// </summary>                
        /// <returns>El vehículo se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO vehiculos (matricula, marca, modelo) VALUES (
                                                      @matricula, @marca, @modelo);", conexion);

            comando.Parameters.AddWithValue("@matricula", Matricula);
            comando.Parameters.AddWithValue("@marca", Marca);
            comando.Parameters.AddWithValue("@modelo", Modelo);

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();

                comando.CommandText = "SELECT MAX(id) FROM vehiculos;";
                Id = Convert.ToInt32(comando.ExecuteScalar());                               
            }
            catch (Exception)
            { }
            conexion.Close();

            return numFila >= 1;
        }

        public Vehiculo(string matricula, string marca, string modelo)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
        }
    }
}
