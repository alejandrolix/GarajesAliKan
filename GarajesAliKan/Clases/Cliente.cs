using MySql.Data.MySqlClient;
using NPoco;
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
        public Alquiler Alquiler { get; set; }

        /// <summary>
        /// Comprueba si existen clientes de los garajes guardados.
        /// </summary>
        /// <returns>El número de clientes.</returns>
        public static bool HayClientesGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM clientes
                                                      WHERE esClienteGaraje IS TRUE;", conexion);

            int numClientes = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numClientes >= 1;
        }

        /// <summary>
        /// Comprueba si existen clientes del lavadero guardados.
        /// </summary>
        /// <returns>El número de clientes.</returns>
        public static bool HayClientesLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   clientes
                                                      WHERE esClienteGaraje IS FALSE;", conexion);

            int numClientes = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numClientes >= 1;
        }

        /// <summary>
        /// Obtiene todos los clientes de los garajes.
        /// </summary>
        /// <returns>Los clientes existentes de los garajes.</returns>
        public static List<Cliente> ObtenerClientesGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, gaj.nombre AS garaje, veh.matricula, veh.marca, veh.modelo, alqPc.baseImponible, 
                                                             alqPc.iva, alqPc.total, plzCli.plaza, alqPc.llave, tAlq.concepto
                                                      FROM   clientes cli
                                                             JOIN alquilerPorCliente alqPc ON alqPc.idCliente = cli.id
                                                             JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                             JOIN garajes gaj ON gaj.id = alqPc.idGaraje
                                                             JOIN vehiculos veh ON veh.id = alqPc.idVehiculo
                                                             JOIN tiposAlquileres tAlq ON tAlq.id = alqPc.idTipoAlquiler
                                                      WHERE   cli.esClienteGaraje IS TRUE
                                                      ORDER BY cli.apellidos;", conexion);            

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaClientes = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");
                cliente.Apellidos = cursor.GetString("apellidos");
                cliente.Nif = cursor.GetString("nif");
                cliente.Direccion = cursor.GetString("direccion");
                cliente.Telefono = cursor.GetString("telefono");
                cliente.Observaciones = cursor.GetString("observaciones");
                cliente.Garaje.Nombre = cursor.GetString("garaje");
                cliente.Vehiculo = new Vehiculo(cursor.GetString("matricula"), cursor.GetString("marca"), cursor.GetString("modelo"));
                cliente.Alquiler.BaseImponible = cursor.GetDecimal("baseImponible");
                cliente.Alquiler.Iva = cursor.GetDecimal("iva");
                cliente.Alquiler.Total = cursor.GetDecimal("total");
                cliente.Alquiler.Plaza = cursor.GetString("plaza");
                cliente.Alquiler.Llave = cursor.GetInt32("llave");
                cliente.Alquiler.Concepto = cursor.GetString("concepto");
                listaClientes.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaClientes;
        }

        /// <summary>
        /// Obtiene los clientes de todos los garajes para realizar un informe.
        /// </summary>
        /// <returns>Los clientes de todos los garajes.</returns>
        public static List<Cliente> ObtenerClientesGarajesInforme()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaClientes = conexion.Fetch<Cliente>(@"SELECT plzCli.plaza, cli.nombre, cli.apellidos, cli.telefono, alqPc.total, cli.observaciones
                                                                    FROM   plazaCliente plzCli
		                                                                   JOIN clientes cli ON cli.id = plzCli.idCliente
		                                                                   JOIN alquilerPorCliente alqPc ON cli.id = alqPc.idCliente;");
            conexion.CloseSharedConnection();
            return listaClientes;
        }

        /// <summary>
        /// Obtiene todos los clientes del lavedero.
        /// </summary>
        /// <returns>Los clientes existentes del lavadero.</returns>
        public static List<Cliente> ObtenerClientesLavadero()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaClientes = conexion.Fetch<Cliente>(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono
                                                                    FROM   clientes cli                                                                            
                                                                    WHERE  cli.esClienteGaraje IS FALSE
                                                                    ORDER BY cli.apellidos;");
            conexion.CloseSharedConnection();
            return listaClientes;
        }

        /// <summary>
        /// Obtiene los datos de un cliente de un garaje a partir de su Id.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del cliente del garaje.</returns>
        public static Cliente ObtenerClienteGarajePorId(int idCliente)
        {
            Database conexion = Foo.ConexionABd();
            Cliente cliente = conexion.Single<Cliente>(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, gaj.nombre, veh.matricula, veh.marca, veh.modelo, alqPc.baseImponible, alqPc.iva, alqPc.total, alqPc.plaza, alqPc.llave, tAlq.concepto
                                                         FROM   clientes cli		 
                                                                JOIN alquilerPorCliente alqPc ON alqPc.idCliente = cli.id
                                                                JOIN garajes gaj ON gaj.id = alqPc.idGaraje
                                                                LEFT JOIN vehiculos veh ON veh.id = alqPc.idVehiculo
                                                                JOIN tiposAlquileres tAlq ON tAlq.id = alqPc.idTipoAlquiler
                                                         WHERE  cli.id = @0;", idCliente);
            conexion.CloseSharedConnection();
            return cliente;
        }

        /// <summary>
        /// Obtiene los datos de un cliente del lavadero a partir de su Id.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del cliente del lavadero.</returns>
        public static Cliente ObtenerClienteLavaderoPorId(int idCliente)
        {
            Database conexion = Foo.ConexionABd();
            Cliente cliente = conexion.Single<Cliente>(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono
                                                         FROM   clientes cli		                                                                 
                                                         WHERE  cli.id = @0;", idCliente);
            conexion.CloseSharedConnection();
            return cliente;
        }

        /// <summary>
        /// Obtiene todos los apellidos de los clientes de los garajes.
        /// </summary>
        /// <returns>Los apellidos de los clientes de los garajes.</returns>
        public static List<Cliente> ObtenerApellidosClientesGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, apellidos
                                                      FROM   clientes
                                                      WHERE esClienteGaraje IS TRUE
                                                      ORDER BY apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaApellidos = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente(cursor.GetInt32("id"), cursor.GetString("apellidos"));
                listaApellidos.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaApellidos;
        }

        /// <summary>
        /// Obtiene todos los apellidos de los clientes del lavadero.
        /// </summary>
        /// <returns>Los apellidos de los clientes del lavadero.</returns>
        public static List<Cliente> ObtenerApellidosClientesLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, apellidos
                                                      FROM   clientes
                                                      WHERE esClienteGaraje IS FALSE
                                                      ORDER BY apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaApellidos = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente(cursor.GetInt32("id"), cursor.GetString("apellidos"));                             
                listaApellidos.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaApellidos;
        }

        /// <summary>
        /// Obtiene todos los NIFs de los clientes de los garajes.
        /// </summary>
        /// <returns>Los NIFs de los clientes de los garajes.</returns>
        public static List<Cliente> ObtenerNifsClientesGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nif
                                                      FROM   clientes
                                                      WHERE  esClienteGaraje IS TRUE
                                                      ORDER BY nif;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaNifs = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nif = cursor.GetString("nif");
                listaNifs.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaNifs;
        }

        /// <summary>
        /// Obtiene todos los NIFs de los clientes del lavadero.
        /// </summary>
        /// <returns>Los NIFs de los clientes del lavadero.</returns>
        public static List<Cliente> ObtenerNifsClientesLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nif
                                                      FROM   clientes
                                                      WHERE  esClienteGaraje IS FALSE
                                                      ORDER BY nif;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaNifs = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = cursor.GetInt32("id");                
                cliente.Nif = cursor.GetString("nif");               
                listaNifs.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaNifs;
        }

        /// <summary>
        /// Obtiene el último Id insertado.
        /// </summary>
        /// <param name="comando">Un objeto de la clase MySqlCommand para obtener el último id.</param>
        /// <returns>El último Id insertado.</returns>
        private int ObtenerUltimoId(MySqlCommand comando)
        {
            comando.CommandText = "SELECT MAX(id) FROM clientes;";
            int ultimoId = Convert.ToInt32(comando.ExecuteScalar());

            return ultimoId;
        }

        /// <summary>
        /// Obtiene todos los nombres y apellidos de los clientes de los garajes.
        /// </summary>
        /// <returns>La lista con los nombres y apellidos de los clientes de los garajes.</returns>
        public static List<Cliente> ObtenerNombresYApellidosGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, CONCAT(nombre, ' ', apellidos) AS nombre
                                                      FROM   clientes
                                                      WHERE  esClienteGaraje IS TRUE;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaClientes = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");                
                listaClientes.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaClientes;
        }

        /// <summary>
        /// Obtiene todos los nombres y apellidos de los clientes del lavadero.
        /// </summary>
        /// <returns>La lista con los nombres y apellidos de los clientes del lavadero.</returns>
        public static List<Cliente> ObtenerNombresYApellidosLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, CONCAT(nombre, ' ', apellidos) AS nombre
                                                      FROM   clientes
                                                      WHERE  esClienteGaraje IS FALSE;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Cliente> listaClientes = new List<Cliente>();

            while (cursor.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");                
                listaClientes.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaClientes;
        }

        /// <summary>
        /// Inserta un cliente.
        /// </summary>        
        /// <returns>El cliente se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO clientes (nombre, apellidos, nif, direccion, telefono, observaciones, esClienteGaraje) VALUES (
                                                      @nombre, @apellidos, @nif, @direccion, @telefono, @observaciones, @esClienteGaraje);", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);
            comando.Parameters.AddWithValue("@observaciones", Observaciones == "" ? null : Observaciones);
            comando.Parameters.AddWithValue("@esClienteGaraje", EsClienteGaraje);

            int numFila = comando.ExecuteNonQuery();
            if (EsClienteGaraje)
            {
                Id = ObtenerUltimoId(comando);
            }
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

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <returns>Se ha eliminado el cliente.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("DELETE FROM clientes WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public override bool Equals(object obj)
        {
            Cliente cliente = obj as Cliente;
            return cliente != null && Id == cliente.Id;
        }

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono, string observaciones, Garaje garaje, bool esClienteGaraje, Vehiculo vehiculo, Alquiler alquilerPorCliente)              // Alquilar una plaza de garaje.  
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
            Alquiler = alquilerPorCliente;
        }

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono, Garaje garaje, string observaciones, bool esClienteGaraje)             // Alquilar una plaza de trastero.
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
        }

        public Cliente(int id)          // Para buscar un cliente por su Id en la lista de clientes.
        {
            Id = id;
        }

        public Cliente(int id, string apellidos)
        {
            Id = id;
            Apellidos = apellidos;
        }

        public Cliente(string nif, string nombre)
        {
            Nif = nif;
            Nombre = nombre;
        }

        public Cliente()
        {
            Garaje = new Garaje();
            Alquiler = new Alquiler();
        }
    }
}
