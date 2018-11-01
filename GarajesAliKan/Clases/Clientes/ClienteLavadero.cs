using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class ClienteLavadero : Cliente
    {
        /// <summary>
        /// Comprueba si existen clientes del lavadero guardados.
        /// </summary>
        /// <returns>El número de clientes.</returns>
        public static bool HayClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   clientesLavadero;", conexion);

            int numClientes = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numClientes >= 1;
        }

        /// <summary>
        /// Obtiene todos los clientes del lavedero.
        /// </summary>
        /// <returns>Los clientes existentes del lavadero.</returns>
        public static List<ClienteLavadero> ObtenerClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nombre, apellidos, nif, direccion, telefono
                                                      FROM   clientesLavadero                                                                            
                                                      ORDER BY apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteLavadero> listaClientes = new List<ClienteLavadero>();

            while (cursor.Read())
            {
                ClienteLavadero cliente = new ClienteLavadero();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");
                cliente.Apellidos = cursor.GetString("apellidos");
                cliente.Nif = cursor.GetString("nif");
                cliente.Direccion = cursor.GetString("direccion");
                cliente.Telefono = cursor.GetString("telefono");
                listaClientes.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaClientes;
        }

        /// <summary>
        /// Obtiene los datos de un cliente del lavadero a partir de su Id.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del cliente del lavadero.</returns>
        public static ClienteLavadero ObtenerClientePorId(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nombre, apellidos, nif, direccion, telefono
                                                      FROM   clientesLavadero		                                                                 
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            ClienteLavadero cliente = new ClienteLavadero();

            while (cursor.Read())
            {
                cliente.Id = cursor.GetInt32("id");
                cliente.Nombre = cursor.GetString("nombre");
                cliente.Apellidos = cursor.GetString("apellidos");
                cliente.Nif = cursor.GetString("nif");
                cliente.Direccion = cursor.GetString("direccion");
                cliente.Telefono = cursor.GetString("telefono");
            }
            cursor.Close();
            conexion.Close();

            return cliente;
        }

        /// <summary>
        /// Obtiene todos los apellidos de los clientes del lavadero.
        /// </summary>
        /// <returns>Los apellidos de los clientes del lavadero.</returns>
        public static List<ClienteLavadero> ObtenerApellidosClientes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, apellidos
                                                      FROM   clientesLavadero                                                      
                                                      ORDER BY apellidos;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteLavadero> listaApellidos = new List<ClienteLavadero>();

            while (cursor.Read())
            {
                ClienteLavadero cliente = new ClienteLavadero(cursor.GetInt32("id"), cursor.GetString("apellidos"));
                listaApellidos.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaApellidos;
        }

        /// <summary>
        /// Obtiene todos los NIFs de los clientes del lavadero.
        /// </summary>
        /// <returns>Los NIFs de los clientes del lavadero.</returns>
        public static List<ClienteLavadero> ObtenerNifsClientesLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, nif
                                                      FROM   clientesLavadero                                                      
                                                      ORDER BY nif;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteLavadero> listaNifs = new List<ClienteLavadero>();

            while (cursor.Read())
            {
                ClienteLavadero cliente = new ClienteLavadero();
                cliente.Id = cursor.GetInt32("id");
                cliente.Nif = cursor.GetString("nif");
                listaNifs.Add(cliente);
            }
            cursor.Close();
            conexion.Close();

            return listaNifs;
        }

        /// <summary>
        /// Obtiene todos los nombres y apellidos de los clientes del lavadero.
        /// </summary>
        /// <returns>La lista con los nombres y apellidos de los clientes del lavadero.</returns>
        public static List<ClienteLavadero> ObtenerNombresYApellidos()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, CONCAT(nombre, ' ', apellidos) AS nombre
                                                      FROM   clientesLavadero;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<ClienteLavadero> listaClientes = new List<ClienteLavadero>();

            while (cursor.Read())
            {
                ClienteLavadero cliente = new ClienteLavadero();
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
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO clientesLavadero (nombre, apellidos, nif, direccion, telefono) VALUES (
                                                                                   @nombre, @apellidos, @nif, @direccion, @telefono);", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);            

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
            MySqlCommand comando = new MySqlCommand(@"UPDATE clientesLavadero SET nombre = @nombre, apellidos = @apellidos, nif = @nif, direccion = @direccion, telefono = @telefono
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nif", Nif);
            comando.Parameters.AddWithValue("@direccion", Direccion);
            comando.Parameters.AddWithValue("@telefono", Telefono);            
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
            MySqlCommand comando = new MySqlCommand("DELETE FROM clientesLavadero WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public override bool Equals(object obj)
        {
            ClienteLavadero cliente = obj as ClienteLavadero;
            return cliente != null && Id == cliente.Id;
        }

        public ClienteLavadero(int id) : base(id)
        {
        }

        public ClienteLavadero(int id, string apellidos) : base(id, apellidos)
        {            
        }

        public ClienteLavadero()
        {
        }
    }
}
