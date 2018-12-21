using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class Alquiler
    {
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }        
        public decimal BaseImponible { get; set; }
        public int IdTipoAlquiler { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Plaza { get; set; }
        public int Llave { get; set; }
        public string Concepto { get; set; }

        /// <summary>
        /// Obtiene todos los conceptos.
        /// </summary>
        /// <returns>Los conceptos.</returns>
        public static List<Alquiler> ObtenerConceptos()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, concepto
                                                      FROM   tiposAlquileres
                                                      ORDER BY concepto;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Alquiler> listaConceptos = new List<Alquiler>();

            while (cursor.Read())
            {
                Alquiler alquiler = new Alquiler(cursor.GetInt32("id"), cursor.GetString("concepto"));                
                listaConceptos.Add(alquiler);
            }
            cursor.Close();
            conexion.Close();

            return listaConceptos;
        }

        /// <summary>
        /// Inserta los datos del alquiler que tiene un cliente.
        /// </summary>
        /// <param name="idGaraje">El Id de un garaje.</param>
        /// <returns>Los datos del alquiler se han insertado.</returns>
        public bool Insertar(int idGaraje)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("INSERT INTO alquilerClientesGarajes VALUES (@idCliente", conexion);

            if (IdVehiculo == 0)
                comando.CommandText += ", NULL, ";
            else
            {
                comando.CommandText += ", @idVehiculo, ";
                comando.Parameters.AddWithValue("@idVehiculo", IdVehiculo);
            }

            comando.CommandText += "@idTipoAlquiler, @idGaraje, @baseImponible, @iva, @total, @plaza";

            if (Llave == 0)
                comando.CommandText += ", NULL);";
            else
            {
                comando.CommandText += ", @llave);";
                comando.Parameters.AddWithValue("@llave", Llave);
            }            

            comando.Parameters.AddWithValue("@idCliente", IdCliente);                        
            comando.Parameters.AddWithValue("@idGaraje", idGaraje);
            comando.Parameters.AddWithValue("@idTipoAlquiler", IdTipoAlquiler);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);            
            comando.Parameters.AddWithValue("@plaza", Plaza);            

            int numFila = comando.ExecuteNonQuery();
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
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE alquilerPorCliente SET baseImponible = @baseImponible, iva = @iva, total = @total
                                                      WHERE  idCliente = @idCliente;", conexion);

            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@idCliente", idCliente);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Elimina el alquiler que tiene un cliente a partir de su Id.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>El alquiler del cliente se ha eliminado.</returns>
        public bool EliminarPorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"DELETE FROM alquilerPorCliente
                                                      WHERE idCliente = @idCliente;", conexion);

            comando.Parameters.AddWithValue("@idCliente", idCliente);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public Alquiler(int idTipoAlquiler, string concepto)
        {
            IdTipoAlquiler = idTipoAlquiler;
            Concepto = concepto;
        }

        public Alquiler()
        {
        }
    }
}
