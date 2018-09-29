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
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Plaza { get; set; }

        /// <summary>
        /// Inserta un vehículo.
        /// </summary>        
        /// <param name="idCliente">El Id del nuevo cliente.</param>
        /// <returns>El vehículo se ha insertado.</returns>
        public bool Insertar(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO vehiculos (matricula, marca, modelo, idCliente, baseImponible, iva, total, plaza) VALUES (
                                                      @matricula, @marca, @modelo, @idCliente, @baseImponible, @iva, @total, @plaza);", conexion);

            comando.Parameters.AddWithValue("@matricula", Matricula);
            comando.Parameters.AddWithValue("@marca", Marca);
            comando.Parameters.AddWithValue("@modelo", Modelo);
            comando.Parameters.AddWithValue("@idCliente", idCliente);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@plaza", Plaza);

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            { }

            return numFila >= 1;
        }

        public Vehiculo(string matricula, string marca, string modelo, decimal baseImponible, decimal iva, decimal total, string plaza)
        {
            Matricula = matricula;
            Marca = marca;
            Modelo = modelo;
            BaseImponible = baseImponible;
            Iva = iva;
            Total = total;
            Plaza = plaza;
        }

        public Vehiculo()
        {
        }
    }
}
