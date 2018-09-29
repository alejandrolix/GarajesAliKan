using MySql.Data.MySqlClient;
using PetaPoco;
using System;
using System.Collections.Generic;

namespace GarajesAliKan.Clases
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nif { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Garaje Garaje { get; set; }
        public string Observaciones { get; set; }
        public int Llave { get; set; }
        public bool EsClienteGaraje { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public TipoAlquiler TipoAlquiler { get; set; }

        /// <summary>
        /// Comprueba si existen clientes guardados.
        /// </summary>
        /// <returns>El número de clientes.</returns>
        public static bool HayClientes()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("SELECT COUNT(id) FROM clientes;", conexion);

            int numClientes = 0;
            try
            {
                numClientes = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
            }
            catch (Exception)
            { }

            return numClientes >= 1;
        }

        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        /// <returns>Los clientes existentes.</returns>
        public static List<Cliente> ObtenerClientesGarajes()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaClientes = conexion.Fetch<Cliente, Garaje, Vehiculo, TipoAlquiler>(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, cli.llave, gaj.nombre, veh.matricula, veh.marca, veh.modelo, veh.plaza, veh.baseImponible, veh.iva, veh.total, tAlq.concepto
                                                                                                    FROM   clientes cli
		                                                                                                   JOIN garajes gaj ON gaj.id = cli.idGaraje
		                                                                                                   JOIN vehiculos veh ON veh.idCliente = cli.id
		                                                                                                   JOIN tiposAlquileres tAlq ON tAlq.id = cli.idTipoAlquiler
                                                                                                    WHERE  cli.esClienteGaraje IS TRUE
                                                                                                    ORDER BY cli.apellidos;");
            conexion.CloseSharedConnection();
            return listaClientes;
        }

        /// <summary>
        /// Inserta un cliente.
        /// </summary>
        /// <returns>El cliente se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO clientes (nombre, apellidos, nif, direccion, telefono, idGaraje, observaciones, llave, esClienteGaraje, idTipoAlquiler) VALUES (
                                                      @nombre, @apellidos, @nif, @direccion, @telefono, @idGaraje, @observaciones, @llave, true, @idTipoAlquiler);", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);
            comando.Parameters.AddWithValue("@idGaraje", Garaje.Id);
            comando.Parameters.AddWithValue("@observaciones", Observaciones);
            comando.Parameters.AddWithValue("@llave", Llave);
            comando.Parameters.AddWithValue("@idTipoAlquiler", TipoAlquiler.Id);

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();

                if (TipoAlquiler.Id == 1)       // Si el concepto es "ALQUILER PLAZA DE GARAJE".
                {
                    comando.CommandText = "SELECT MAX(id) FROM clientes;";
                    Id = Convert.ToInt32(comando.ExecuteScalar());
                }                
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return numFila >= 1;
        }

        public Cliente(string nombre, string apellidos, string nif, string direccion, string telefono, Garaje garaje, string observaciones, int llave, bool esClienteGaraje, Vehiculo vehiculo, TipoAlquiler tipoAlquiler)
        {            
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;
            Garaje = garaje;
            Observaciones = observaciones;
            Llave = llave;
            EsClienteGaraje = esClienteGaraje;
            Vehiculo = vehiculo;
            TipoAlquiler = tipoAlquiler;
        }

        public Cliente()
        {
        }
    }
}
