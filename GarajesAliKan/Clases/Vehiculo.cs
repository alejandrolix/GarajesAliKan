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
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO vehiculos (matricula, marca, modelo) VALUES (
                                                      @matricula, @marca, @modelo);", conexion);

            comando.Parameters.AddWithValue("@matricula", Matricula);
            comando.Parameters.AddWithValue("@marca", Marca);
            comando.Parameters.AddWithValue("@modelo", Modelo);

            int numFila = comando.ExecuteNonQuery();
            Id = (int)comando.LastInsertedId;
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Elimina un vehículo.
        /// </summary>
        /// <param name="idVehiculo">El Id de un vehículo.</param>
        /// <returns>Se ha eliminado el vehículo.</returns>
        public bool Eliminar(int idVehiculo)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"DELETE FROM vehiculos
                                                      WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idVehiculo);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public Vehiculo(string matricula, string marca, string modelo)                  // Para crear un vehículo a la hora de crear un cliente.
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
        }

        public Vehiculo()
        {
        }
    }
}
