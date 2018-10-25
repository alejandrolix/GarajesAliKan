using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   proveedores;", conexion);

            int numProveedores = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numProveedores >= 1;
        }

        /// <summary>
        /// Obtiene todos los nombres de las empresas.
        /// </summary>
        /// <returns>Los nombres de las empresas.</returns>
        public static List<Proveedor> ObtenerNombresEmpresas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
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
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id, empresa, cif, concepto
                                                      FROM   proveedores
                                                      ORDER BY empresa;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Proveedor> listaProveedores = new List<Proveedor>();

            while (cursor.Read())
            {
                Proveedor proveedor = new Proveedor();
                proveedor.Id = cursor.GetInt32("id");
                proveedor.Empresa = cursor.GetString("empresa");
                proveedor.Cif = cursor.GetString("cif");
                proveedor.Concepto = cursor.GetString("concepto");
                listaProveedores.Add(proveedor);
            }
            cursor.Close();
            conexion.Close();

            return listaProveedores;
        }

        /// <summary>
        /// Elimina un proveedor a partir de su Id.
        /// </summary>
        /// <returns>Se ha eliminado el proveedor.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("DELETE FROM proveedores WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        /// <summary>
        /// Inserta un proveedor.
        /// </summary>
        /// <returns>Se ha insertado el proveedor.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("INSERT INTO proveedores (empresa, cif, concepto) VALUES (@empresa, @cif, @concepto);", conexion);

            comando.Parameters.AddWithValue("@empresa", Empresa);
            comando.Parameters.AddWithValue("@cif", Cif);
            comando.Parameters.AddWithValue("@concepto", Concepto);

            int numFila = comando.ExecuteNonQuery();
            Id = (int)comando.LastInsertedId;

            conexion.Close();
            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de un proveedor.
        /// </summary>
        /// <returns>Se han modificado los datos del proveedor.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE proveedores SET empresa = @empresa, cif = @cif, concepto = @concepto
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@empresa", Empresa);
            comando.Parameters.AddWithValue("@cif", Cif);
            comando.Parameters.AddWithValue("@concepto", Concepto);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        public override bool Equals(object obj)
        {
            Proveedor proveedor = obj as Proveedor;
            return proveedor != null && Id == proveedor.Id;
        }

        public Proveedor(int id, string empresa)
        {
            Id = id;
            Empresa = empresa;
        }

        public Proveedor(int id)
        {
            Id = id;
        }

        public Proveedor()
        {
        }
    }
}
