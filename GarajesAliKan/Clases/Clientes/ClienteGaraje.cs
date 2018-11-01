using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class ClienteGaraje : Cliente
    {
        public string Observaciones { get; set; }
        public Garaje Garaje { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Alquiler Alquiler { get; set; }

        /// <summary>
        /// Comprueba si existen clientes de los garajes guardados.
        /// </summary>
        /// <returns>El número de clientes.</returns>
        public static bool HayClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   clientesGarajes;", conexion);

            int numClientes = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numClientes >= 1;
        }

        /// <summary>
        /// Obtiene todos los clientes de los garajes.
        /// </summary>
        /// <returns>Los clientes existentes de los garajes.</returns>
        public static List<ClienteGaraje> ObtenerClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT cliGaj.id, cliGaj.nombre, cliGaj.apellidos, cliGaj.nif, cliGaj.direccion, cliGaj.telefono, cliGaj.observaciones, gaj.nombre AS garaje, veh.matricula, veh.marca, veh.modelo, alqCli.baseImponible, 
                                                             alqCli.iva, alqCli.total, plzCli.plaza, alqCli.llave, tAlq.concepto
                                                      FROM   clientesGarajes cliGaj
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                             JOIN plazaClientes plzCli ON cliGaj.id = plzCli.idCliente
                                                             JOIN garajes gaj ON gaj.id = alqCli.idGaraje
                                                             JOIN vehiculos veh ON veh.id = alqCli.idVehiculo
                                                             JOIN tiposAlquileres tAlq ON tAlq.id = alqCli.idTipoAlquiler                                                      
                                                      ORDER BY cliGaj.apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteGaraje> listaClientes = new List<ClienteGaraje>();

            while (cursor.Read())
            {                
                ClienteGaraje cliente = new ClienteGaraje();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");
                cliente.Apellidos = cursor.GetString("apellidos");
                cliente.Nif = cursor.GetString("nif");
                cliente.Direccion = cursor.GetString("direccion");
                cliente.Telefono = cursor.GetString("telefono");

                if (cursor.IsDBNull(6))                
                    cliente.Observaciones = "";
                else
                    cliente.Observaciones = cursor.GetString("observaciones");
                          
                cliente.Garaje = new Garaje();
                cliente.Garaje.Nombre = cursor.GetString("garaje");
                cliente.Vehiculo = new Vehiculo(cursor.GetString("matricula"), cursor.GetString("marca"), cursor.GetString("modelo"));
                cliente.Alquiler = new Alquiler();
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
        public static List<ClienteGaraje> ObtenerClientesParaInforme()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT plzCli.plaza, cliGaj.nombre, cliGaj.apellidos, cliGaj.telefono, alqCli.total, cliGaj.observaciones
                                                      FROM   plazaClientes plzCli
  	                                                         JOIN clientesGarajes cliGaj ON cliGaj.id = plzCli.idCliente
  		                                                     JOIN alquilerClientesGarajes alqCli ON cliGaj.id = alqCli.idCliente
                                                      ORDER BY cliGaj.apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteGaraje> listaClientes = new List<ClienteGaraje>();

            while (cursor.Read())
            {
                ClienteGaraje cliente = new ClienteGaraje();
                cliente.Nombre = cursor.GetString("nombre");
                cliente.Apellidos = cursor.GetString("apellidos");
                cliente.Telefono = cursor.GetString("telefono");
                cliente.Observaciones = cursor.GetString("observaciones");
                cliente.Alquiler = new Alquiler();
                cliente.Alquiler.Total = cursor.GetDecimal("total");
                cliente.Alquiler.Plaza = cursor.GetString("plaza");
                listaClientes.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaClientes;
        }

        /// <summary>
        /// Obtiene los datos de un cliente de un garaje a partir de su Id.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del cliente del garaje.</returns>
        public static ClienteGaraje ObtenerClientePorId(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT cliGaj.id, cliGaj.nombre, cliGaj.apellidos, cliGaj.nif, cliGaj.direccion, cliGaj.telefono, cliGaj.observaciones, gaj.nombre AS garaje, veh.matricula, veh.marca, veh.modelo,
                                                             alqCli.baseImponible, alqCli.iva, alqCli.total, plzCli.plaza, alqCli.llave, tAlq.concepto
                                                      FROM   clientesGarajes cliGaj		 
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                             JOIN garajes gaj ON gaj.id = alqCli.idGaraje
                                                             JOIN vehiculos veh ON veh.id = alqCli.idVehiculo
                                                             JOIN tiposAlquileres tAlq ON tAlq.id = alqCli.idTipoAlquiler
                                                             JOIN plazaClientes plzCli ON cliGaj.id = plzCli.idCliente
                                                      WHERE  cliGaj.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            ClienteGaraje cliente = new ClienteGaraje();

            while (cursor.Read())
            {
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");
                cliente.Apellidos = cursor.GetString("apellidos");
                cliente.Nif = cursor.GetString("nif");
                cliente.Direccion = cursor.GetString("direccion");
                cliente.Telefono = cursor.GetString("telefono");
                cliente.Observaciones = cursor.GetString("observaciones");
                cliente.Garaje = new Garaje();
                cliente.Garaje.Nombre = cursor.GetString("garaje");
                cliente.Vehiculo = new Vehiculo(cursor.GetString("matricula"), cursor.GetString("marca"), cursor.GetString("modelo"));
                cliente.Alquiler = new Alquiler();
                cliente.Alquiler.BaseImponible = cursor.GetDecimal("baseImponible");
                cliente.Alquiler.Iva = cursor.GetDecimal("iva");
                cliente.Alquiler.Total = cursor.GetDecimal("total");
                cliente.Alquiler.Plaza = cursor.GetString("plaza");
                cliente.Alquiler.Llave = cursor.GetInt32("llave");
                cliente.Alquiler.Concepto = cursor.GetString("concepto");
            }
            cursor.Close();
            conexion.Close();

            return cliente;
        }

        /// <summary>
        /// Obtiene todos los apellidos de los clientes de los garajes.
        /// </summary>
        /// <returns>Los apellidos de los clientes de los garajes.</returns>
        public static List<ClienteGaraje> ObtenerApellidosClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, apellidos
                                                      FROM   clientesGarajes                                                      
                                                      ORDER BY apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteGaraje> listaApellidos = new List<ClienteGaraje>();

            while (cursor.Read())
            {
                ClienteGaraje cliente = new ClienteGaraje(cursor.GetInt32("id"), cursor.GetString("apellidos"));
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
        public static List<ClienteGaraje> ObtenerNifsClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nif
                                                      FROM   clientesGarajes                                                      
                                                      ORDER BY nif;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteGaraje> listaNifs = new List<ClienteGaraje>();

            while (cursor.Read())
            {
                ClienteGaraje cliente = new ClienteGaraje();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nif = cursor.GetString("nif");
                listaNifs.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaNifs;
        }

        /// <summary>
        /// Obtiene todos los nombres y apellidos de los clientes de los garajes.
        /// </summary>
        /// <returns>La lista con los nombres y apellidos de los clientes de los garajes.</returns>
        public static List<ClienteGaraje> ObtenerNombresYApellidos()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, CONCAT(nombre, ' ', apellidos) AS nombre
                                                      FROM   clientesGarajes;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteGaraje> listaClientes = new List<ClienteGaraje>();

            while (cursor.Read())
            {
                ClienteGaraje cliente = new ClienteGaraje();
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
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO clientesGarajes (nombre, apellidos, nif, direccion, telefono, observaciones) VALUES (
                                                                                   @nombre, @apellidos, @nif, @direccion, @telefono, @observaciones);", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);
            comando.Parameters.AddWithValue("@observaciones", Observaciones == "" ? null : Observaciones);            

            int numFila = comando.ExecuteNonQuery();
            Id = (int)comando.LastInsertedId;
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de un cliente.
        /// </summary>
        /// <returns>Los datos se han modificado.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE clientesGarajes SET nombre = @nombre, apellidos = @apellidos, nif = @nif, direccion = @direccion, telefono = @telefono, observaciones = @observaciones
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);
            comando.Parameters.AddWithValue("@observaciones", Observaciones == "" ? null : Observaciones);
            comando.Parameters.AddWithValue("@id", Id);

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
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("DELETE FROM clientesGarajes WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public override bool Equals(object obj)
        {
            ClienteGaraje cliente = obj as ClienteGaraje;
            return cliente != null && Id == cliente.Id;
        }

        public ClienteGaraje()
        {            
        }

        public ClienteGaraje(int id) : base(id)          // Para buscar un cliente por su Id en la lista de clientes.
        {            
        }

        public ClienteGaraje(int id, string apellidos) : base(id, apellidos)
        {
        }
    }
}
