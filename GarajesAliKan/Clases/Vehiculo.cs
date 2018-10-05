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

        /// <summary>
        /// Elimina un vehículo.
        /// </summary>
        /// <param name="idVehiculo">El Id de un vehículo.</param>
        /// <returns>Se ha eliminado el vehículo.</returns>
        public bool Eliminar(int idVehiculo)
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"DELETE FROM vehiculos WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idVehiculo);            

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();                
            }
            catch (Exception)
            { }
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Obtiene el Id de un vehículo a partir del Id de un cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>El Id del vehículo del cliente.</returns>
        public int ObtenerIdPorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT idVehiculo FROM alquilerPorCliente WHERE idCliente = @idCliente;", conexion);

            comando.Parameters.AddWithValue("@idCliente", idCliente);            

            int idVehiculo = 0;
            try
            {
                idVehiculo = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception)
            { }
            conexion.Close();

            return idVehiculo;
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
