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
        public bool EsClienteGaraje { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public TipoAlquiler TipoAlquiler { get; set; }  
        public AlquilerPorCliente AlquilerPorCliente { get; set; }

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
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, gaj.nombre AS nombreGaraje, veh.matricula, veh.marca, veh.modelo, alqPc.baseImponible, alqPc.iva, alqPc.total, alqPc.plaza, alqPc.llave, tAlq.concepto
                                                      FROM   clientes cli		 
		                                                     JOIN alquilerPorCliente alqPc ON alqPc.idCliente = cli.id
		                                                     JOIN garajes gaj ON gaj.id = alqPc.idGaraje
		                                                     LEFT JOIN vehiculos veh ON veh.id = alqPc.idVehiculo
		                                                     JOIN tiposAlquileres tAlq ON tAlq.id = alqPc.idTipoAlquiler
                                                      WHERE  cli.esClienteGaraje IS TRUE
                                                      ORDER BY cli.apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaClientes = new List<Cliente>();

            while (cursor.Read())
            {
                Garaje garaje = new Garaje(cursor.GetString("nombreGaraje"));
                Vehiculo vehiculo = new Vehiculo(cursor.IsDBNull(8) ? null : cursor.GetString("matricula"), cursor.IsDBNull(9) ? null : cursor.GetString("marca"), cursor.IsDBNull(10) ? null : cursor.GetString("modelo"));                
                TipoAlquiler tipoAlquiler = new TipoAlquiler(cursor.GetString("concepto"));
                AlquilerPorCliente alqPorCliente = new AlquilerPorCliente(cursor.GetDecimal("baseImponible"), cursor.GetDecimal("iva"), cursor.GetDecimal("total"), cursor.GetString("plaza"), cursor.IsDBNull(15) ? 0 : cursor.GetInt32("llave"));                

                Cliente cliente = new Cliente(cursor.GetInt32("id"), cursor.GetString("nombre"), cursor.GetString("apellidos"), cursor.GetString("nif"), cursor.GetString("direccion"), cursor.GetString("telefono"), cursor.IsDBNull(6) ? null: cursor.GetString("observaciones"),
                    garaje, true, vehiculo, tipoAlquiler, alqPorCliente);

                listaClientes.Add(cliente);
            }

            return listaClientes;
        }

        /// <summary>
        /// Obtiene los datos de un cliente a partir de su Id.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del cliente.</returns>
        public static Cliente ObtenerClientePorId(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, gaj.nombre AS nombreGaraje, veh.matricula, veh.marca, veh.modelo, alqPc.baseImponible, alqPc.iva, alqPc.total, alqPc.plaza, alqPc.llave, tAlq.concepto
                                                      FROM   clientes cli		 
		                                                     JOIN alquilerPorCliente alqPc ON alqPc.idCliente = cli.id
		                                                     JOIN garajes gaj ON gaj.id = alqPc.idGaraje
		                                                     LEFT JOIN vehiculos veh ON veh.id = alqPc.idVehiculo
		                                                     JOIN tiposAlquileres tAlq ON tAlq.id = alqPc.idTipoAlquiler
                                                      WHERE  cli.id = @idCliente;", conexion);

            comando.Parameters.AddWithValue("@idCliente", idCliente);
            MySqlDataReader cursor = comando.ExecuteReader();
            Cliente cliente = null;

            while (cursor.Read())
            {
                Garaje garaje = new Garaje(cursor.GetString("nombreGaraje"));
                Vehiculo vehiculo = new Vehiculo(cursor.IsDBNull(8) ? null : cursor.GetString("matricula"), cursor.IsDBNull(9) ? null : cursor.GetString("marca"), cursor.IsDBNull(10) ? null : cursor.GetString("modelo"));
                TipoAlquiler tipoAlquiler = new TipoAlquiler(cursor.GetString("concepto"));
                AlquilerPorCliente alqPorCliente = new AlquilerPorCliente(cursor.GetDecimal("baseImponible"), cursor.GetDecimal("iva"), cursor.GetDecimal("total"), cursor.GetString("plaza"), cursor.IsDBNull(15) ? 0 : cursor.GetInt32("llave"));

                cliente = new Cliente(cursor.GetInt32("id"), cursor.GetString("nombre"), cursor.GetString("apellidos"), cursor.GetString("nif"), cursor.GetString("direccion"), cursor.GetString("telefono"), cursor.IsDBNull(6) ? null : cursor.GetString("observaciones"),
                    garaje, true, vehiculo, tipoAlquiler, alqPorCliente);                
            }

            return cliente;
        }

        /// <summary>
        /// Inserta un cliente.
        /// </summary>
        /// <returns>El cliente se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO clientes (nombre, apellidos, nif, direccion, telefono, observaciones, esClienteGaraje) VALUES (
                                                      @nombre, @apellidos, @nif, @direccion, @telefono, @observaciones, true);", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);
            comando.Parameters.AddWithValue("@observaciones", Observaciones == "" ? null : Observaciones);                        

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();
                comando.CommandText = "SELECT MAX(id) FROM clientes;";
                Id = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception)
            { }
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de un cliente.
        /// </summary>
        /// <returns>Los datos se han modificado.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"UPDATE clientes SET nombre = @nombre, apellidos = @apellidos, nif = @nif, direccion = @direccion, telefono = @telefono, observaciones = @observaciones
                                                      WHERE  id = @idCliente;", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);            
            comando.Parameters.AddWithValue("@observaciones", Observaciones == "" ? null : Observaciones);
            comando.Parameters.AddWithValue("@idCliente", Id);

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

        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("DELETE FROM clientes WHERE idCliente = @idCliente;", conexion);

            comando.Parameters.AddWithValue("@idCliente", Id);

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            conexion.Close();

            return numFila >= 1;
        }
        
        public override bool Equals(object obj)
        {
            return Id == ((Cliente)obj).Id;
        }        

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono, string observaciones, Garaje garaje, bool esClienteGaraje, Vehiculo vehiculo, TipoAlquiler tipoAlquiler, AlquilerPorCliente alquilerPorCliente)              // Alquilar una plaza de garaje.  
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;            
            Observaciones = observaciones;
            Garaje = garaje;
            EsClienteGaraje = esClienteGaraje;
            Vehiculo = vehiculo;
            TipoAlquiler = tipoAlquiler;
            AlquilerPorCliente = alquilerPorCliente;
        }

        public Cliente(string nombre, string apellidos, string nif, string direccion, string telefono, string observaciones, Garaje garaje, bool esClienteGaraje, Vehiculo vehiculo, TipoAlquiler tipoAlquiler, AlquilerPorCliente alquilerPorCliente)              // Alquilar una plaza de garaje.  
        {            
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;
            Observaciones = observaciones;
            Garaje = garaje;
            EsClienteGaraje = esClienteGaraje;
            Vehiculo = vehiculo;
            TipoAlquiler = tipoAlquiler;
            AlquilerPorCliente = alquilerPorCliente;
        }

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono, Garaje garaje, string observaciones, bool esClienteGaraje, TipoAlquiler tipoAlquiler)             // Alquilar una plaza de trastero.
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;
            Garaje = garaje;
            Observaciones = observaciones;            
            EsClienteGaraje = esClienteGaraje;            
            TipoAlquiler = tipoAlquiler;
        }

        public Cliente(int id)          // Para buscar un cliente por su Id en la lista de clientes.
        {
            Id = id;
        }

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono, string observaciones, AlquilerPorCliente alquilerPorCliente)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;
            Observaciones = observaciones;
            AlquilerPorCliente = alquilerPorCliente;
        }
    }
}
