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
            Database conexion = Foo.ConexionABd();
            int numClientes = conexion.ExecuteScalar<int>("SELECT COUNT(id) FROM clientes WHERE esClienteGaraje IS TRUE;");

            conexion.CloseSharedConnection();
            return numClientes >= 1;
        }

        /// <summary>
        /// Comprueba si existen clientes del lavadero guardados.
        /// </summary>
        /// <returns>El número de clientes.</returns>
        public static bool HayClientesLavadero()
        {
            Database conexion = Foo.ConexionABd();
            int numClientes = conexion.ExecuteScalar<int>("SELECT COUNT(id) FROM clientes WHERE esClienteGaraje IS FALSE;");

            conexion.CloseSharedConnection();
            return numClientes >= 1;
        }

        /// <summary>
        /// Obtiene todos los clientes de los garajes.
        /// </summary>
        /// <returns>Los clientes existentes de los garajes.</returns>
        public static List<Cliente> ObtenerClientesGarajes()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaClientes = conexion.Fetch<Cliente>(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, gaj.nombre, veh.matricula, veh.marca, veh.modelo, alqPc.baseImponible, alqPc.iva, alqPc.total, alqPc.plaza, alqPc.llave, tAlq.concepto
                                                                    FROM   clientes cli
                                                                            JOIN alquilerPorCliente alqPc ON alqPc.idCliente = cli.id
                                                                            JOIN garajes gaj ON gaj.id = alqPc.idGaraje
                                                                            LEFT JOIN vehiculos veh ON veh.id = alqPc.idVehiculo
                                                                            JOIN tiposAlquileres tAlq ON tAlq.id = alqPc.idTipoAlquiler
                                                                    WHERE  cli.esClienteGaraje IS TRUE
                                                                    ORDER BY cli.apellidos;");
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
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaApellidos = conexion.Fetch<Cliente>(@"SELECT id, apellidos
                                                                     FROM   clientes
                                                                     WHERE esClienteGaraje IS TRUE
                                                                     ORDER BY apellidos;");
            conexion.CloseSharedConnection();
            return listaApellidos;
        }

        /// <summary>
        /// Obtiene todos los apellidos de los clientes del lavadero.
        /// </summary>
        /// <returns>Los apellidos de los clientes del lavadero.</returns>
        public static List<Cliente> ObtenerApellidosClientesLavadero()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaApellidos = conexion.Fetch<Cliente>(@"SELECT id, apellidos
                                                                     FROM   clientes
                                                                     WHERE esClienteGaraje IS FALSE
                                                                     ORDER BY apellidos;");
            conexion.CloseSharedConnection();
            return listaApellidos;
        }

        /// <summary>
        /// Obtiene todos los NIFs de los clientes de los garajes.
        /// </summary>
        /// <returns>Los NIFs de los clientes de los garajes.</returns>
        public static List<Cliente> ObtenerNifsClientesGarajes()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaNifs = conexion.Fetch<Cliente>(@"SELECT id, nif
                                                                FROM   clientes
                                                                WHERE  esClienteGaraje IS TRUE
                                                                ORDER BY nif;");
            conexion.CloseSharedConnection();
            return listaNifs;
        }

        /// <summary>
        /// Obtiene todos los NIFs de los clientes del lavadero.
        /// </summary>
        /// <returns>Los NIFs de los clientes del lavadero.</returns>
        public static List<Cliente> ObtenerNifsClientesLavadero()
        {
            Database conexion = Foo.ConexionABd();
            List<Cliente> listaNifs = conexion.Fetch<Cliente>(@"SELECT id, nif
                                                                FROM   clientes
                                                                WHERE  esClienteGaraje IS FALSE
                                                                ORDER BY nif;");
            conexion.CloseSharedConnection();
            return listaNifs;
        }

        /// <summary>
        /// Obtiene el último Id insertado.
        /// </summary>
        /// <param name="conexion">La conexión con la base de datos. Opcional.</param>
        /// <returns>El último Id insertado.</returns>
        public static int ObtenerUltimoId(Database conexion = null)
        {
            int ultimoId = conexion.ExecuteScalar<int>("SELECT MAX(id) FROM clientes;");
            conexion.CloseSharedConnection();

            return ultimoId;
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

            int numFila = 0;
            try
            {
                numFila = comando.ExecuteNonQuery();
                if (EsClienteGaraje)
                {
                    Id = ObtenerUltimoId(Foo.ConexionABd());
                }                
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

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <returns>Se ha eliminado el cliente.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("DELETE FROM clientes WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

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

        public Cliente(string nombre, string apellidos, string nif, string direccion, string telefono, string observaciones, Garaje garaje, bool esClienteGaraje, Vehiculo vehiculo, Alquiler alquilerPorCliente)              // Alquilar una plaza de garaje.  
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

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono, string observaciones, Alquiler alquilerPorCliente)           // Para modificar los datos de un cliente del garaje.
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;
            Observaciones = observaciones;
            Alquiler = alquilerPorCliente;
        }

        public Cliente(int id, string nombre, string apellidos, string nif, string direccion, string telefono)           // Para modificar los datos de un cliente del lavadero.
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Nif = nif;
            Direccion = direccion;
            Telefono = telefono;
        }

        public Cliente(string nombre, string apellidos, string direccion, string nif, string telefono, bool esClienteGaraje)              // Para crear un cliente del lavadero.
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Nif = nif;
            Telefono = telefono;
            EsClienteGaraje = esClienteGaraje;
        }

        public Cliente()
        {
        }
    }
}
