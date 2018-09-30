using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class AlquilerPorCliente
    {
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public int IdTipoAlquiler { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Plaza { get; set; }
        public int Llave { get; set; }

        /// <summary>
        /// Inserta los datos del alquiler que tiene un cliente.
        /// </summary>
        /// <param name="idGaraje">El Id de un garaje.</param>
        /// <returns>Los datos del alquiler se han insertado.</returns>
        public bool Insertar(int idGaraje)
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("INSERT INTO alquilerPorCliente VALUES (@idCliente, ", conexion);            

            if (IdVehiculo == 0)            
                comando.CommandText += "NULL, ";            
            else
            {
                comando.CommandText += "@idVehiculo";
                comando.Parameters.AddWithValue("@idVehiculo", IdVehiculo);
            }
            comando.CommandText += "@idTipoAlquiler, @idGaraje, @baseImponible, @iva, @total, @plaza, ";            

            if (Llave == 0)            
                comando.CommandText += "NULL);";            
            else
            {
                comando.CommandText += "@llave);";
                comando.Parameters.AddWithValue("@llave", Llave);
            }

            comando.Parameters.AddWithValue("@idCliente", IdCliente);
            comando.Parameters.AddWithValue("@idTipoAlquiler", IdTipoAlquiler);
            comando.Parameters.AddWithValue("@idGaraje", idGaraje);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@plaza", Plaza);

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
        /// Modifica los datos del alquiler del cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del alquiler se han modificado.</returns>
        public bool Modificar(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"UPDATE alquilerPorCliente SET baseImponible = @baseImponible, iva = @iva, total = @total
                                                      WHERE  idCliente = @idCliente;", conexion);                        
            
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@idCliente", idCliente);

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conexion.Close();

            return numFila >= 1;
        }

        public AlquilerPorCliente(decimal baseImponible, decimal iva, decimal total, string plaza, int llave)
        {            
            BaseImponible = baseImponible;
            Iva = iva;
            Total = total;
            Plaza = plaza;
            Llave = llave;
        }

        public AlquilerPorCliente(decimal baseImponible, decimal iva, decimal total)
        {            
            BaseImponible = baseImponible;
            Iva = iva;
            Total = total;
        }
    }
}
