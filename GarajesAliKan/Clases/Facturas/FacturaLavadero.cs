using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class FacturaLavadero : Factura
    {
        public string Concepto { get; set; }
        public bool EstaPagada { get; set; }
        public ClienteLavadero Cliente { get; set; }

        public override bool Equals(object obj)
        {
            FacturaLavadero factura = obj as FacturaLavadero;
            return factura != null && Id == factura.Id;
        }

        /// <summary>
        /// Comprueba si existen facturas del lavadero.
        /// </summary>
        /// <returns>El número de facturas.</returns>
        public static bool HayFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   facturasLavadero;", conexion);

            int numFacturas = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numFacturas >= 1;
        }

        /// <summary>
        /// Obtiene todas las facturas del lavadero.
        /// </summary>
        /// <returns>Las facturas del lavadero.</returns>
        public static List<FacturaLavadero> ObtenerFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factLav.id, factLav.fecha, cliLav.nif, CONCAT(cliLav.nombre, ' ', cliLav.apellidos) AS nombre, factLav.estaPagada, factLav.concepto, factLav.baseImponible, factLav.iva, factLav.total
                                                      FROM   facturasLavadero factLav
                                                             JOIN clientesLavadero cliLav ON factLav.idCliente = cliLav.id
                                                      ORDER BY factLav.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaLavadero> listaFacturas = new List<FacturaLavadero>();

            while (cursor.Read())
            {
                FacturaLavadero factura = new FacturaLavadero();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new ClienteLavadero();
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Nombre = cursor.GetString("nombre");                
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Concepto = cursor.GetString("concepto");
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
        /// Obtiene los Ids de las facturas del lavadero.
        /// </summary>
        /// <returns>Los Ids de las facturas del lavadero.</returns>
        public static List<int> ObtenerIdsFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id
                                                      FROM   facturasLavadero                                                      
                                                      ORDER BY id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<int> listaIds = new List<int>();

            while (cursor.Read())
            {
                listaIds.Add(cursor.GetInt32("id"));
            }
            cursor.Close();
            conexion.Close();

            return listaIds;
        }

        /// <summary>
        /// Obtiene las fechas de las facturas del lavadero.
        /// </summary>
        /// <returns>Las fechas de las facturas del lavadero.</returns>
        public static List<DateTime> ObtenerFechas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fecha
                                                      FROM   facturasLavadero                                                      
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
        /// Obtiene una factura del lavadero a partir de su Id.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaLavadero ObtenerFacturaPorId(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factLav.id, factLav.fecha, cliLav.nif, CONCAT(cliLav.nombre, ' ', cliLav.apellidos) AS nombre, factLav.estaPagada, factLav.concepto,
                                                             factLav.baseImponible, factLav.iva, factLav.total
                                                      FROM   facturasLavadero factLav
                                                             JOIN clientesLavadero cliLav ON factLav.idCliente = cliLav.id
                                                      WHERE  factLav.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idFactura);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaLavadero factura = new FacturaLavadero();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new ClienteLavadero();
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");                
                factura.Concepto = cursor.GetString("concepto");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene los datos de una factura del lavadero a partir de su Id para realizar el informe.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaLavadero ObtenerDatosFacturaPorIdParaInforme(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factLav.id, factLav.fecha, cliLav.nif, CONCAT(cliLav.nombre, ' ', cliLav.apellidos) AS nombre, cliLav.direccion,
                                                             factLav.concepto, factLav.baseImponible, factLav.iva, factLav.total
                                                      FROM   facturasLavadero factLav
                                                             JOIN clientesLavadero cliLav ON factLav.idCliente = cliLav.id
                                                      WHERE  factLav.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idFactura);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaLavadero factura = new FacturaLavadero();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new ClienteLavadero();
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("direccion");
                factura.Cliente.Nombre = cursor.GetString("nombre");                
                factura.Concepto = cursor.GetString("concepto");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene los datos de una factura del lavadero a partir de su fecha.
        /// </summary>
        /// <param name="fecha">La fecha de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaLavadero ObtenerFacturaPorFecha(DateTime fecha)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factLav.id, factLav.fecha, cliLav.nif, CONCAT(cliLav.nombre, ' ', cliLav.apellidos) AS nombre, cliLav.direccion,
                                                             factLav.concepto, factLav.baseImponible, factLav.iva, factLav.total
                                                      FROM   facturasLavadero factLav
                                                             JOIN clientesLavadero cliLav ON factLav.idCliente = cliLav.id
                                                      WHERE  factLav.fecha = @fecha;", conexion);

            comando.Parameters.AddWithValue("@fecha", fecha);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaLavadero factura = new FacturaLavadero();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new ClienteLavadero();
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("direccion");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.Concepto = cursor.GetString("concepto");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene una factura del lavadero a partir de un Id de un cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaLavadero ObtenerFacturaPorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factLav.id, factLav.fecha, cliLav.nif, CONCAT(cliLav.nombre, ' ', cliLav.apellidos) AS nombre, factLav.estaPagada,
                                                             factLav.baseImponible, factLav.iva, factLav.total
                                                      FROM   facturasLavadero factLav
                                                             JOIN clientesLavadero cliLav ON factLav.idCliente = cliLav.id                                                                
                                                      WHERE  cliLav.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaLavadero factura = new FacturaLavadero();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new ClienteLavadero();
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene todas las facturas del lavadero entre una fecha de inicio y fin para realizar un informe.
        /// </summary>
        /// <returns>Todas las facturas del lavadero</returns>
        public static List<FacturaLavadero> ObtenerFacturasPorFechasInforme(DateTime desde, DateTime hasta)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factLav.id, factLav.fecha, CONCAT(cliLav.nombre, ' ', cliLav.apellidos) AS nombre, cliLav.direccion, cliLav.nif, factLav.baseImponible, factLav.iva, factLav.total
                                                      FROM   facturasLavadero factLav
		                                                     JOIN clientesLavadero cliLav ON cliLav.id = factLav.idCliente
		                                              WHERE factLav.fecha BETWEEN @desde AND @hasta
                                                      ORDER BY factLav.id;", conexion);

            comando.Parameters.AddWithValue("@desde", desde);
            comando.Parameters.AddWithValue("@hasta", hasta);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaLavadero> listaFacturas = new List<FacturaLavadero>();

            while (cursor.Read())
            {
                FacturaLavadero factura = new FacturaLavadero();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new ClienteLavadero();
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("direccion");
                factura.Cliente.Nombre = cursor.GetString("nombre");
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
        /// Inserta una factura para el lavadero.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("INSERT INTO facturasLavadero VALUES (@id, @fecha, @idCliente, @baseImponible, @iva, @total, @estaPagada, @concepto);", conexion);
            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@idCliente", Cliente.Id);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@estaPagada", EstaPagada);
            comando.Parameters.AddWithValue("@concepto", Concepto);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de una factura para el lavadero.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturasLavadero SET fecha = @fecha, estaPagada = @estaPagada, concepto = @concepto, baseImponible = @baseImponible, iva = @iva, total = @total
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@estaPagada", EstaPagada);
            comando.Parameters.AddWithValue("@concepto", Concepto);
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
            MySqlCommand comando = new MySqlCommand("DELETE FROM facturasLavadero WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        public FacturaLavadero(int id) : base(id)
        {
        }

        public FacturaLavadero()
        {
        }
    }
}
