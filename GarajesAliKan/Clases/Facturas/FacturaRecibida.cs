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
                                                             JOIN garajes gaj ON gaj.id = factRec.idGaraje
                                                             JOIN proveedores prov ON prov.id = factRec.idProveedor                                                      
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
        /// Obtiene todos los años de las facturas recibidas.
        /// </summary>
        /// <returns>Los años de las facturas recibidas.</returns>
        public static List<int> ObtenerAniosFechas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT YEAR(fecha) AS anio
                                                      FROM   facturasRecibidas
                                                      GROUP BY anio
                                                      ORDER BY anio;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<int> listaAnios = new List<int>();

            while (cursor.Read())            
                listaAnios.Add(cursor.GetInt32("anio"));            
            cursor.Close();
            conexion.Close();

            return listaAnios;
        }

        /// <summary>
        /// Obtiene la suma de las bases imponibles de las facturas a partir del subId de un garaje y el número de un mes.
        /// </summary>
        /// <param name="subId">El subId de un garaje.</param>
        /// <param name="mes">El número de un mes.</param>
        /// <returns>La suma de las bases imponibles de las facturas a partir del subId de un garaje y el número de un mes.</returns>
        public static decimal ObtenerSumaBaseImponiblePorSubIdGarajeYMes(string subId, int mes)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT SUM(factRec.baseImponible) AS factsRecibidas
                                                      FROM   facturasRecibidas factRec		                                                     		                                                     
                                                      WHERE  MONTH(factRec.fecha) = @mes AND YEAR(factRec.fecha) = YEAR(CURDATE()) AND factRec.idGaraje IN (
									                                               SELECT id
									                                               FROM   garajes
									                                               WHERE  subId LIKE @subId);", conexion);
            comando.Parameters.AddWithValue("@mes", mes);
            comando.Parameters.AddWithValue("@subId", subId + "%");

            MySqlDataReader cursor = comando.ExecuteReader();
            decimal total = 0;

            while (cursor.Read())
                if (!cursor.IsDBNull(0))
                    total = cursor.GetDecimal("factsRecibidas");
            cursor.Close();
            conexion.Close();

            return total;
        }

        /// <summary>
        /// Obtiene la suma de las bases imponibles de las facturas a partir del subId de un garaje y el año.
        /// </summary>
        /// <param name="subId">El subId de un garaje.</param>
        /// <param name="anio">El año.</param>
        /// <returns>La suma de las bases imponibles de las facturas a partir del subId de un garaje y el año.</returns>
        public static decimal ObtenerSumaBaseImponiblePorSubIdGarajeYAnio(string subId, int anio)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT SUM(factRec.baseImponible) AS factsRecibidas
                                                      FROM   facturasRecibidas factRec	                                                     		                                                     
                                                      WHERE  YEAR(factRec.fecha) = @anio AND factRec.idGaraje IN (
									                                                        SELECT id
									                                                        FROM   garajes
									                                                        WHERE  subId LIKE @subId);", conexion);
            comando.Parameters.AddWithValue("@anio", anio);
            comando.Parameters.AddWithValue("@subId", subId + "%");

            MySqlDataReader cursor = comando.ExecuteReader();
            decimal total = 0;

            while (cursor.Read())
                if (!cursor.IsDBNull(0))
                    total = cursor.GetDecimal("factsRecibidas");
            cursor.Close();
            conexion.Close();

            return total;
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
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, prov.empresa, prov.cif, gaj.nombre, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor
                                                             JOIN garajes gaj ON gaj.id = fact.idGaraje
                                                      WHERE  factRec.fecha BETWEEN @desde AND @hasta
                                                      ORDER BY fact.id;", conexion);

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
        /// Obtiene todas las facturas recibidas a partir del Id de un proveedor.
        /// </summary>
        /// <param name="idProveedor">El Id de un proveedor.</param>
        /// <returns>Los datos de las facturas.</returns>
        public static List<FacturaRecibida> ObtenerFacturasPorIdProveedor(int idProveedor)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, gaj.nombre, prov.empresa, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN proveedores prov ON prov.id = factRec.idProveedor
                                                             JOIN garajes gaj ON gaj.id = factRec.idGaraje
                                                      WHERE  prov.id = @id
                                                      ORDER BY factRec.id;", conexion);

            comando.Parameters.AddWithValue("@id", idProveedor);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaRecibida> facturas = new List<FacturaRecibida>();            

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
                facturas.Add(factura);
            }
            cursor.Close();
            conexion.Close();

            return facturas;
        }

        /// <summary>
        /// Obtiene todas las facturas recibidas a partir del Id de un garaje.
        /// </summary>
        /// <param name="idGaraje">El Id de un garaje.</param>
        /// <returns>Los datos de las facturas.</returns>
        public static List<FacturaRecibida> ObtenerFacturasPorIdGaraje(int idGaraje)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, gaj.nombre, prov.empresa, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN proveedores prov ON prov.id = factRec.idProveedor
                                                             JOIN garajes gaj ON gaj.id = factRec.idGaraje
                                                      WHERE  gaj.id = @id
                                                      ORDER BY factRec.id;", conexion);

            comando.Parameters.AddWithValue("@id", idGaraje);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaRecibida> facturas = new List<FacturaRecibida>();

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
                facturas.Add(factura);
            }
            cursor.Close();
            conexion.Close();

            return facturas;
        }

        /// <summary>
        /// Obtiene todas las facturas recibidas entre una fecha de inicio y fin para realizar un informe.
        /// </summary>
        /// <param name="desde"></param>
        /// <returns>Todas las facturas recibidas</returns>
        public static List<FacturaRecibida> ObtenerFacturasPorFechasInforme(DateTime desde, DateTime hasta)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factRec.id, factRec.fecha, prov.empresa, prov.cif, gaj.nombre, factRec.baseImponible, factRec.iva, factRec.total
                                                      FROM   facturasRecibidas factRec
                                                             JOIN proveedores prov ON prov.id = factRec.idProveedor
                                                             JOIN garajes gaj ON gaj.id = factRec.idGaraje
                                                      WHERE  factRec.fecha BETWEEN @desde AND @hasta
                                                      ORDER BY factRec.id;", conexion);

            comando.Parameters.AddWithValue("@desde", desde);
            comando.Parameters.AddWithValue("@hasta", hasta);

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
