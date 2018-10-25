using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public Garaje Garaje { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Plaza { get; set; }
        public bool EstaPagada { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Concepto { get; set; }

        public override bool Equals(object obj)
        {
            Factura factura = obj as Factura;
            return factura != null && Id == factura.Id;
        }

        /// <summary>
        /// Comprueba si existen facturas de todos los garajes.
        /// </summary>
        /// <returns>Si existen facturas de todos los garajes.</returns>
        public static bool HayFacturasGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   facturas
                                                      WHERE  esFacturaGaraje IS TRUE;", conexion);

            int numFacturas = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numFacturas >= 1;
        }

        /// <summary>
        /// Comprueba si existen facturas del lavadero.
        /// </summary>
        /// <returns>El número de facturas.</returns>
        public static bool HayFacturasLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   facturas
                                                      WHERE  esFacturaLavadero IS TRUE;", conexion);

            int numFacturas = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numFacturas >= 1;
        }

        /// <summary>
        /// Comprueba si existen facturas recibidas.
        /// </summary>
        /// <returns>El número de facturas.</returns>
        public static bool HayFacturasRecibidas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   facturas
                                                      WHERE  esFacturaRecibida IS TRUE;", conexion);

            int numFacturas = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numFacturas >= 1;
        }

        /// <summary>
        /// Obtiene todas las facturas de los garajes.
        /// </summary>
        /// <returns>Las facturas de los garajes.</returns>
        public static List<Factura> ObtenerFacturasGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                             JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                      WHERE  fact.esFacturaGaraje IS TRUE
                                                      ORDER BY fact.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Factura> listaFacturas = new List<Factura>();

            while (cursor.Read())
            {
                Factura factura = new Factura();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Cliente.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Cliente.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Cliente.Alquiler.Plaza = cursor.GetString("plaza");
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
        /// Obtiene todas las facturas del lavadero.
        /// </summary>
        /// <returns>Las facturas del lavadero.</returns>
        public static List<Factura> ObtenerFacturasLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, fact.concepto, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                      WHERE  fact.esFacturaLavadero IS TRUE
                                                      ORDER BY fact.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Factura> listaFacturas = new List<Factura>();

            while (cursor.Read())
            {
                Factura factura = new Factura();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente = new Cliente(cursor.GetString("nif"), cursor.GetString("nombre"));
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
        /// Obtiene todas las facturas recibidas.
        /// </summary>
        /// <returns>Las facturas recibidas.</returns>
        public static List<Factura> ObtenerFacturasRecibidas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, gaj.nombre, prov.empresa, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN garajes gaj ON gaj.id = fact.idGaraje
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor
                                                      WHERE  fact.esFacturaRecibida IS TRUE
                                                      ORDER BY fact.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Factura> listaFacturas = new List<Factura>();

            while (cursor.Read())
            {
                Factura factura = new Factura(3);
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Garaje.Nombre = cursor.GetString("nombre");
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
        /// Obtiene los Ids de las facturas de todos los garajes.
        /// </summary>
        /// <returns>Los Ids de las facturas de todos los garajes.</returns>
        public static List<int> ObtenerIdsFacturasGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id
                                                      FROM   facturas
                                                      WHERE  esFacturaGaraje IS TRUE
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
        /// Obtiene los Ids de las facturas del lavadero.
        /// </summary>
        /// <returns>Los Ids de las facturas del lavadero.</returns>
        public static List<int> ObtenerIdsFacturasLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id
                                                      FROM   facturas
                                                      WHERE  esFacturaLavadero IS TRUE
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
        /// Obtiene las fechas de las facturas de todos los garajes.
        /// </summary>
        /// <returns>Las fechas de las facturas de todos los garajes.</returns>
        public static List<DateTime> ObtenerFechasGarajes()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fecha
                                                      FROM   facturas
                                                      WHERE  esFacturaGaraje IS TRUE
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
        /// Obtiene las fechas de las facturas del lavadero.
        /// </summary>
        /// <returns>Las fechas de las facturas del lavadero.</returns>
        public static List<DateTime> ObtenerFechasLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fecha
                                                      FROM   facturas
                                                      WHERE  esFacturaLavadero IS TRUE
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
        /// Obtiene las fechas de las facturas recibidas.
        /// </summary>
        /// <returns>Las fechas de las facturas recibidas.</returns>
        public static List<DateTime> ObtenerFechasRecibidas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fecha
                                                      FROM   facturas
                                                      WHERE  esFacturaRecibida IS TRUE
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
        /// Obtiene una factura de un garaje a partir de su Id.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaGarajePorId(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                     plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                             JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                      WHERE  fact.id = @0;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(1);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");                
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Cliente.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Cliente.Alquiler.Plaza = cursor.GetString("plaza");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene los datos de una factura de un garaje a partir de su Id para realizar el informe.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerDatosFacturaGarajePorId(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, cli.direccion, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                             JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                      WHERE  fact.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idFactura);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(1);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("direccion");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Cliente.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Cliente.Alquiler.Plaza = cursor.GetString("plaza");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene una factura del lavadero a partir de su Id.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaLavaderoPorId(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, fact.concepto, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                      WHERE  fact.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idFactura);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(2);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");                
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Cliente.Alquiler = null;
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
        public static Factura ObtenerDatosFacturaLavaderoPorId(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, cli.direccion, fact.concepto, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                      WHERE  fact.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idFactura);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(2);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("direccion");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.Cliente.Alquiler = null;
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
        /// Obtiene una factura de un garaje a partir de un Id de un cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaGarajePorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                     plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                             JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                      WHERE  cli.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(1);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");                
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Cliente.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Cliente.Alquiler.Plaza = cursor.GetString("plaza");
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
        public static Factura ObtenerFacturaLavaderoPorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id                                                                
                                                      WHERE  cli.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(2);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
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
        /// Obtiene una factura de un garaje a partir de una fecha.
        /// </summary>
        /// <param name="fecha">La fecha.</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaGarajePorFecha(DateTime fecha)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                     plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN clientes cli ON fact.idCliente = cli.id
                                                             JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                      WHERE  fact.fecha = @fecha AND fact.esFacturaGaraje IS TRUE;", conexion);

            comando.Parameters.AddWithValue("@fecha", fecha);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(1);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");                
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Cliente.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Cliente.Alquiler.Plaza = cursor.GetString("plaza");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene una factura recibida a partir de una fecha.
        /// </summary>
        /// <param name="fecha">La fecha.</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaRecibidaPorFecha(DateTime fecha)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, gaj.nombre, prov.empresa, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor
                                                      WHERE  fact.fecha = @fecha AND fact.esFacturaRecibida IS TRUE;", conexion);

            comando.Parameters.AddWithValue("@fecha", fecha);

            MySqlDataReader cursor = comando.ExecuteReader();
            Factura factura = new Factura(3);

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");                                                
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
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
        /// Obtiene todas las facturas de los garajes a partir de dos fechas para realizar un informe.
        /// </summary>
        /// <returns>Todas las facturas de los garajes</returns>
        public static List<Factura> ObtenerFacturasGarajesPorFechasInforme(DateTime desde, DateTime hasta)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, cli.nif, cli.direccion, gaj.nombre AS nombreGaraje, fact.baseImponible,
		                                                     fact.iva, fact.total
                                                      FROM   facturas fact
		                                                     JOIN clientes cli ON cli.id = fact.idCliente
		                                                     JOIN garajes gaj ON gaj.id = fact.idGaraje
                                                      WHERE  fact.fecha BETWEEN @desde AND @hasta
                                                      ORDER BY fact.id;", conexion);

            comando.Parameters.AddWithValue("@desde", desde);
            comando.Parameters.AddWithValue("@hasta", hasta);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Factura> listaFacturas = new List<Factura>();

            while (cursor.Read())
            {
                Factura factura = new Factura(1);
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("nombre");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
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
        /// Obtiene todas las facturas del lavadero para realizar un informe.
        /// </summary>
        /// <returns>Todas las facturas del lavadero</returns>
        public static List<Factura> ObtenerFacturasLavaderoInforme()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, cli.direccion, cli.nif, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
		                                                     JOIN clientes cli ON cli.id = fact.idCliente
                                                      WHERE  fact.esFacturaLavadero IS TRUE
                                                      ORDER BY fact.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Factura> listaFacturas = new List<Factura>();

            while (cursor.Read())
            {
                Factura factura = new Factura(2);
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
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
        /// Obtiene todas las facturas recibidas para realizar un informe.
        /// </summary>
        /// <returns>Todas las facturas recibidas</returns>
        public static List<Factura> ObtenerFacturasRecibidasInforme()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fact.id, fact.fecha, prov.empresa, prov.cif, gaj.nombre, fact.baseImponible, fact.iva, fact.total
                                                      FROM   facturas fact
                                                             JOIN proveedores prov ON prov.id = fact.idProveedor
                                                             JOIN garajes gaj ON gaj.id = fact.idGaraje
                                                      WHERE fact.esFacturaRecibida IS TRUE
                                                      ORDER BY fact.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<Factura> listaFacturas = new List<Factura>();
            while (cursor.Read())
            {
                Factura factura = new Factura();
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
        /// Elimina una factura.
        /// </summary>        
        /// <returns>La factura se ha eliminado.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("DELETE FROM facturas WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        /// <summary>
        /// Inserta una factura para un garaje.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool InsertarParaGaraje()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO facturas VALUES (@id, @fecha, @idCliente, @idTipoAlquiler, NULL, @idGaraje, @baseImponible, @iva, @total, @estaPagada,
                                                                                   TRUE, FALSE, FALSE, NULL);", conexion);
            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@idCliente", Cliente.Id);
            comando.Parameters.AddWithValue("@idTipoAlquiler", Cliente.Alquiler.IdTipoAlquiler);
            comando.Parameters.AddWithValue("@idGaraje", Garaje.Id);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@estaPagada", EstaPagada);

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
        /// Inserta una factura para el lavadero.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool InsertarParaLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO facturas VALUES (@id, @fecha, @idCliente, NULL, NULL, NULL, @baseImponible, @iva, @total, @estaPagada,
                                                                                   FALSE, TRUE, FALSE, @concepto);", conexion);
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
        /// Inserta una factura para recibida.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool InsertarRecibida()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"INSERT INTO facturas VALUES (@id, @fecha, NULL, NULL, @idProveedor, @idGaraje, @baseImponible, @iva, @total, NULL,
                                                                                   FALSE, FALSE, TRUE, NULL);", conexion);
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
        /// Modifica los datos de una factura para un garaje.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool ModificarParaGaraje()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturas SET fecha = @fecha, estaPagada = @estaPagada, baseImponible = @baseImponible, iva = @iva,
                                                                          total = @total
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@estaPagada", EstaPagada);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);

            int numFila = comando.ExecuteNonQuery();

            conexion.Close();
            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de una factura para el lavadero.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool ModificarParaLavadero()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturas SET fecha = @fecha, estaPagada = @estaPagada, concepto = @concepto, baseImponible = @baseImponible, iva = @iva,
                                                                          total = @total
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
        /// Modifica los datos de una factura recibida.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool ModificarRecibida()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturas SET fecha = @fecha, idProveedor = @idProveedor, baseImponible = @baseImponible, iva = @iva,
                                                                          total = @total
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

        public Factura(int tipoFactura)
        {
            switch (tipoFactura)
            {
                case 1:         // Es una factura de un garaje.
                    Cliente = new Cliente();
                    Cliente.Alquiler = new Alquiler();
                    Garaje = new Garaje();
                    break;

                case 2:         // Es una factura del lavadero.
                    Cliente = new Cliente();
                    break;

                case 3:         // Es una factura recibida.
                    Garaje = new Garaje();
                    Proveedor = new Proveedor();
                    break;

                default:
                    Id = tipoFactura;       // Para buscar un cliente a partir de su Id.
                    break;
            }
        }

        public Factura()
        {
            Cliente = new Cliente();
            Cliente.Alquiler = new Alquiler();
            Cliente.Garaje = new Garaje();
        }
    }
}
