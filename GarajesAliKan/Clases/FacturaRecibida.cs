using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class FacturaRecibida : Factura
    {
        public Proveedor Proveedor { get; set; }
        public Garaje Garaje { get; set; }
        public Cliente Cliente { get; set; }

        public override bool Equals(object obj)
        {
            FacturaRecibida factura = obj as FacturaRecibida;
            return factura != null && Id == factura.Id;
        }

        /// <summary>
        /// Comprueba si existen facturas recibidas.
        /// </summary>
        /// <returns>El número de facturas.</returns>
        public static bool HayFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   facturasRecibidas;", conexion);

            int numFacturas = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numFacturas >= 1;
        }

        /// <summary>
        /// Obtiene todas las facturas recibidas.
        /// </summary>
        /// <returns>Las facturas recibidas.</returns>
        public static List<FacturaRecibida> ObtenerFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, gaj.nombre, prov.empresa, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN garajes gaj ON gaj.id = fact.idGaraje
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor                                                      
                                                      ORDER BY factRec.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaRecibida> listaFacturas = new List<FacturaRecibida>();

            while (cursor.Read())
            {
                FacturaRecibida factura = new FacturaRecibida();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Garaje = new Garaje();
                factura.Garaje.Nombre = cursor.GetString("nombre");
                factura.Proveedor = new Proveedor();
                factura.Proveedor.Empresa = cursor.GetString("empresa");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
                listaFacturas.Add(factura);
            }
            cursor.Close();
            conexion.Close();

            return listaFacturas;
        }

        /// <summary>
        /// Obtiene las fechas de las facturas recibidas.
        /// </summary>
        /// <returns>Las fechas de las facturas recibidas.</returns>
        public static List<DateTime> ObtenerFechas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fecha
                                                      FROM   facturasRecibidas                                                      
                                                      ORDER BY fecha;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<DateTime> listaFechas = new List<DateTime>();

            while (cursor.Read())
            {
                listaFechas.Add(cursor.GetDateTime("fecha"));
            }
            cursor.Close();
            conexion.Close();

            return listaFechas;
        }

        /// <summary>
        /// Obtiene una factura recibida a partir de una fecha.
        /// </summary>
        /// <param name="fecha">La fecha.</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaRecibida ObtenerFacturaPorFecha(DateTime fecha)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, gaj.nombre, prov.empresa, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor
                                                      WHERE  factRec.fecha = @fecha;", conexion);

            comando.Parameters.AddWithValue("@fecha", fecha);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaRecibida factura = new FacturaRecibida();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Garaje = new Garaje();
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Proveedor = new Proveedor();
                factura.Proveedor.Empresa = cursor.GetString("empresa");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene todas las facturas recibidas para realizar un informe.
        /// </summary>
        /// <returns>Todas las facturas recibidas</returns>
        public static List<FacturaRecibida> ObtenerFacturasInforme()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, prov.empresa, prov.cif, gaj.nombre, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor
                                                             JOIN garajes gaj ON gaj.id = fact.idGaraje
                                                      WHERE fact.esFacturaRecibida IS TRUE
                                                      ORDER BY fact.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaRecibida> listaFacturas = new List<FacturaRecibida>();

            while (cursor.Read())
            {
                FacturaRecibida factura = new FacturaRecibida();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");                
                factura.Proveedor = new Proveedor();
                factura.Proveedor.Empresa = cursor.GetString("empresa");
                factura.Proveedor.Cif = cursor.GetString("cif");
                factura.Garaje = new Garaje();
                factura.Garaje.Nombre = cursor.GetString("nombre");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
                listaFacturas.Add(factura);
            }
            cursor.Close();
            conexion.Close();

            return listaFacturas;
        }

        /// <summary>
        /// Inserta una factura para recibida.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("INSERT INTO facturasRecibidas VALUES (@id, @fecha, @idProveedor, @idGaraje, @baseImponible, @iva, @total);", conexion);
            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@idProveedor", Proveedor.Id);
            comando.Parameters.AddWithValue("@idGaraje", Garaje.Id);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de una factura recibida.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturasRecibidas SET fecha = @fecha, idProveedor = @idProveedor, baseImponible = @baseImponible, iva = @iva, total = @total
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@idProveedor", Proveedor.Id);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        /// <summary>
        /// Elimina una factura.
        /// </summary>        
        /// <returns>La factura se ha eliminado.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("DELETE FROM facturasRecibidas WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public FacturaRecibida(int id) : base(id)
        {
        }

        public FacturaRecibida() : base()
        {
        }
    }
}
