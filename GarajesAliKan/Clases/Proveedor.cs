using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NPoco;

namespace GarajesAliKan.Clases
{
    class Proveedor
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Cif { get; set; }
        public string Concepto { get; set; }

        /// <summary>
        /// Comprueba si existen proveedores.
        /// </summary>
        /// <returns>Si existen proveedores.</returns>
        public static bool ExistenProveedores()
        {
            Database conexion = Foo.ConexionABd();
            int numProveedores = conexion.ExecuteScalar<int>(@"SELECT COUNT(id)
                                                               FROM   proveedores;");
            conexion.CloseSharedConnection();
            return numProveedores >= 1;
        }

        /// <summary>
        /// Obtiene todos los nombres de las empresas.
        /// </summary>
        /// <returns>Los nombres de las empresas.</returns>
        public static List<Proveedor> ObtenerNombresEmpresas()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, empresa
                                                      FROM   proveedores
                                                      ORDER BY empresa;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Proveedor> listaNombres = new List<Proveedor>();

            while (cursor.Read())
            {                
                listaNombres.Add(new Proveedor(cursor.GetInt32("id"), cursor.GetString("empresa")));
            }
            cursor.Close();
            conexion.Close();

            return listaNombres;
        }

        /// <summary>
        /// Obtiene todos los proveedores.
        /// </summary>
        /// <returns>Los proveedores.</returns>
        public static List<Proveedor> ObtenerProveedores()
        {
            Database conexion = Foo.ConexionABd();
            List<Proveedor> listaProveedores = conexion.Fetch<Proveedor>(@"SELECT *
                                                                           FROM   proveedores
                                                                           ORDER BY empresa;");
            conexion.CloseSharedConnection();
            return listaProveedores;
        }

        /// <summary>
        /// Elimina un proveedor a partir de su Id.
        /// </summary>
        /// <returns>Se ha eliminado el proveedor.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("DELETE FROM proveedores WHERE id = @id;", conexion);

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

        /// <summary>
        /// Inserta un proveedor.
        /// </summary>
        /// <returns>Se ha insertado el proveedor.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("INSERT INTO proveedores (empresa, cif, concepto) VALUES (@empresa, @cif, @concepto);", conexion);

            comando.Parameters.AddWithValue("@empresa", Empresa);
            comando.Parameters.AddWithValue("@cif", Cif);
            comando.Parameters.AddWithValue("@concepto", Concepto);

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
        /// Modifica los datos de un proveedor.
        /// </summary>
        /// <returns>Se han modificado los datos del proveedor.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"UPDATE proveedores SET empresa = @empresa, cif = @cif, concepto = @concepto
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@empresa", Empresa);
            comando.Parameters.AddWithValue("@cif", Cif);
            comando.Parameters.AddWithValue("@concepto", Concepto);

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

        public Proveedor(int id, string empresa)
        {
            Id = id;
            Empresa = empresa;
        }

        public Proveedor()
        {
        }
    }
}
