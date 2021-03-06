﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class FacturaGaraje : Factura
    {
        public string Plaza { get; set; }
        public bool EstaPagada { get; set; }
        public ClienteGaraje Cliente { get; set; }
        public Garaje Garaje { get; set; }
        public Alquiler Alquiler { get; set; }

        public override bool Equals(object obj)
        {
            FacturaGaraje factura = obj as FacturaGaraje;
            return factura != null && Id == factura.Id;
        }

        /// <summary>
        /// Comprueba si existen facturas de todos los garajes.
        /// </summary>
        /// <returns>Si existen facturas de todos los garajes.</returns>
        public static bool HayFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT COUNT(id)
                                                      FROM   facturasGarajes;", conexion);

            int numFacturas = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return numFacturas >= 1;
        }

        /// <summary>
        /// Obtiene todas las facturas de los garajes.
        /// </summary>
        /// <returns>Las facturas de los garajes.</returns>
        public static List<FacturaGaraje> ObtenerFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, cliGaj.nif, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos) AS nombre, factGaj.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     alqCli.plaza, factGaj.baseImponible, factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
                                                             JOIN clientesGarajes cliGaj ON factGaj.idCliente = cliGaj.id
                                                             JOIN tiposAlquileres tAlq ON factGaj.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON factGaj.idGaraje = gaj.id
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      ORDER BY factGaj.id;", conexion);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaGaraje> listaFacturas = new List<FacturaGaraje>();

            while (cursor.Read())
            {
                FacturaGaraje factura = new FacturaGaraje();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Plaza = cursor.GetString("plaza");
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
        /// Obtiene la suma de las bases imponibles de las facturas a partir del subId de un garaje y el número del mes.
        /// </summary>
        /// <param name="subId">El subId de un garaje.</param>
        /// <param name="mes">El número del mes.</param>
        /// <returns>La suma de las bases imponibles de las facturas a partir del subId de un garaje y el número del mes.</returns>
        public static decimal ObtenerSumaBaseImponiblePorSubIdGarajeYMes(string subId, int mes)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT SUM(factGaj.baseImponible) AS factsEmitidas
                                                      FROM   facturasGarajes factGaj	                                                     		                                                     
                                                      WHERE  MONTH(factGaj.fecha) = @mes AND YEAR(factGaj.fecha) = YEAR(CURDATE()) AND factGaj.idGaraje IN (
									                                                        SELECT id
									                                                        FROM   garajes
									                                                        WHERE  subId LIKE @subId);", conexion);
            comando.Parameters.AddWithValue("@mes", mes);
            comando.Parameters.AddWithValue("@subId", subId + "%");

            MySqlDataReader cursor = comando.ExecuteReader();
            decimal total = 0;

            while (cursor.Read())
                if (!cursor.IsDBNull(0))
                    total = cursor.GetDecimal("factsEmitidas");
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
            MySqlCommand comando = new MySqlCommand(@"SELECT SUM(factGaj.baseImponible) AS factsEmitidas
                                                      FROM   facturasGarajes factGaj	                                                     		                                                     
                                                      WHERE  YEAR(factGaj.fecha) = @anio AND factGaj.idGaraje IN (
									                                                        SELECT id
									                                                        FROM   garajes
									                                                        WHERE  subId LIKE @subId);", conexion);
            comando.Parameters.AddWithValue("@anio", anio);
            comando.Parameters.AddWithValue("@subId", subId + "%");

            MySqlDataReader cursor = comando.ExecuteReader();
            decimal total = 0;

            while (cursor.Read())
                if (!cursor.IsDBNull(0))
                    total = cursor.GetDecimal("factsEmitidas");
            cursor.Close();
            conexion.Close();

            return total;
        }

        /// <summary>
        /// Obtiene los Ids de las facturas de todos los garajes.
        /// </summary>
        /// <returns>Los Ids de las facturas de todos los garajes.</returns>
        public static List<int> ObtenerIdsFacturas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT id
                                                      FROM   facturasGarajes                                                      
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
        public static List<DateTime> ObtenerFechas()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT fecha
                                                      FROM   facturasGarajes                                                      
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
        /// Obtiene los datos de una factura a partir de su Id para realizar el informe.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaGaraje ObtenerDatosFacturaPorId(int idFactura)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, cliGaj.nif, cliGaj.direccion, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos) AS nombre, factGaj.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     alqCli.plaza, factGaj.baseImponible, factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
                                                             JOIN clientesGarajes cliGaj ON factGaj.idCliente = cliGaj.id
                                                             JOIN tiposAlquileres tAlq ON factGaj.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON factGaj.idGaraje = gaj.id
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      WHERE  factGaj.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idFactura);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaGaraje factura = new FacturaGaraje();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Direccion = cursor.GetString("direccion");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Plaza = cursor.GetString("plaza");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene una factura a partir de un Id de un cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaGaraje ObtenerFacturaPorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, cliGaj.nif, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos) AS nombre, factGaj.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     alqCli.plaza, factGaj.baseImponible, factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
                                                             JOIN clientesGarajes cliGaj ON factGaj.idCliente = cliGaj.id
                                                             JOIN tiposAlquileres tAlq ON factGaj.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON factGaj.idGaraje = gaj.id
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      WHERE  cliGaj.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaGaraje factura = new FacturaGaraje();

            while (cursor.Read())
            {
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Alquiler.Plaza = cursor.GetString("plaza");
                factura.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Iva = cursor.GetDecimal("iva");
                factura.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene todas las facturas a partir de un Id de un cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos de las facturas.</returns>
        public static List<FacturaGaraje> ObtenerFacturasPorIdCliente(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, cliGaj.nif, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos) AS nombre, factGaj.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     alqCli.plaza, factGaj.baseImponible, factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
                                                             JOIN clientesGarajes cliGaj ON factGaj.idCliente = cliGaj.id
                                                             JOIN tiposAlquileres tAlq ON factGaj.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON factGaj.idGaraje = gaj.id
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      WHERE  cliGaj.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaGaraje> facturas = new List<FacturaGaraje>();

            while (cursor.Read())
            {
                FacturaGaraje factura = new FacturaGaraje();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nif = cursor.GetString("nif");
                factura.Cliente.Nombre = cursor.GetString("nombre");
                factura.EstaPagada = cursor.GetBoolean("estaPagada");
                factura.Alquiler.Concepto = cursor.GetString("concepto");
                factura.Garaje.Nombre = cursor.GetString("nombreGaraje");
                factura.Alquiler.Plaza = cursor.GetString("plaza");
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
        /// Obtiene una factura a partir de una fecha.
        /// </summary>
        /// <param name="fecha">La fecha.</param>
        /// <returns>Los datos de la factura.</returns>
        public static FacturaGaraje ObtenerFacturaPorFecha(DateTime fecha)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, cliGaj.nif, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos) AS nombre, factGaj.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     alqCli.plaza, factGaj.baseImponible, factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
                                                             JOIN clientesGarajes cliGaj ON factGaj.idCliente = cliGaj.id
                                                             JOIN tiposAlquileres tAlq ON factGaj.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON factGaj.idGaraje = gaj.id
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      WHERE  factGaj.fecha = @fecha;", conexion);

            comando.Parameters.AddWithValue("@fecha", fecha);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaGaraje factura = new FacturaGaraje();

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
        /// Obtiene todas las facturas a partir de una fecha.
        /// </summary>
        /// <param name="fecha">La fecha.</param>
        /// <returns>Los datos de la facturas.</returns>
        public static List<FacturaGaraje> ObtenerFacturasPorFecha(DateTime fecha)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, cliGaj.nif, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos) AS nombre, factGaj.estaPagada, tAlq.concepto, gaj.nombre AS nombreGaraje,
    	                                                     alqCli.plaza, factGaj.baseImponible, factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
                                                             JOIN clientesGarajes cliGaj ON factGaj.idCliente = cliGaj.id
                                                             JOIN tiposAlquileres tAlq ON factGaj.idTipoAlquiler = tAlq.id
                                                             JOIN garajes gaj ON factGaj.idGaraje = gaj.id
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      WHERE  factGaj.fecha = @fecha;", conexion);

            comando.Parameters.AddWithValue("@fecha", fecha);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaGaraje> facturas = new List<FacturaGaraje>();

            while (cursor.Read())
            {
                FacturaGaraje factura = new FacturaGaraje();
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
                facturas.Add(factura);
            }
            cursor.Close();
            conexion.Close();

            return facturas;
        }

        /// <summary>
        /// Obtiene todas las facturas a partir de dos fechas para realizar un informe.
        /// </summary>
        /// <returns>Todas las facturas.</returns>
        public static List<FacturaGaraje> ObtenerFacturasPorFechasInforme(DateTime desde, DateTime hasta)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT factGaj.id, factGaj.fecha, IF (cliGaj.apellidos IS NOT NULL, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos), cliGaj.nombre) AS nombre, cliGaj.nif, cliGaj.direccion, gaj.nombre AS nombreGaraje, factGaj.baseImponible,
		                                                     factGaj.iva, factGaj.total
                                                      FROM   facturasGarajes factGaj
		                                                     JOIN clientesGarajes cliGaj ON cliGaj.id = factGaj.idCliente
		                                                     JOIN garajes gaj ON gaj.id = factGaj.idGaraje
                                                      WHERE  factGaj.fecha BETWEEN @desde AND @hasta
                                                      ORDER BY factGaj.id;", conexion);

            comando.Parameters.AddWithValue("@desde", desde);
            comando.Parameters.AddWithValue("@hasta", hasta);

            MySqlDataReader cursor = comando.ExecuteReader();
            List<FacturaGaraje> listaFacturas = new List<FacturaGaraje>();

            while (cursor.Read())
            {
                FacturaGaraje factura = new FacturaGaraje();
                factura.Id = cursor.GetInt32("id");
                factura.Fecha = cursor.GetDateTime("fecha");
                factura.Cliente.Nombre = cursor.GetString("nombre");

                if (cursor.IsDBNull(3))
                    factura.Cliente.Nif = null;
                else
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
        /// Obtiene los datos de un cliente de un garaje a partir de su Id para realizar una factura de un trastero.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos del cliente del garaje.</returns>
        public static FacturaGaraje ObtenerClientePorIdParaFacturaTrastero(int idCliente)
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT IF (cliGaj.apellidos IS NOT NULL, CONCAT(cliGaj.nombre, ' ', cliGaj.apellidos), cliGaj.nombre) AS nombre, cliGaj.nif, cliGaj.direccion, cliGaj.telefono,
                                                             alqCli.plaza, alqCli.baseImponible, alqCli.iva, alqCli.total                                                           
                                                      FROM   clientesGarajes cliGaj		 
                                                             JOIN alquilerClientesGarajes alqCli ON alqCli.idCliente = cliGaj.id
                                                      WHERE  cliGaj.id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", idCliente);

            MySqlDataReader cursor = comando.ExecuteReader();
            FacturaGaraje factura = new FacturaGaraje();

            while (cursor.Read())
            {
                factura.Cliente.Nombre = cursor.GetString("nombre");

                if (cursor.IsDBNull(1))
                    factura.Cliente.Nif = null;
                else
                    factura.Cliente.Nif = cursor.GetString("nif");

                factura.Cliente.Direccion = cursor.GetString("direccion");

                if (cursor.IsDBNull(3))
                    factura.Cliente.Telefono = null;
                else
                    factura.Cliente.Telefono = cursor.GetString("telefono");

                factura.Cliente.Alquiler = new Alquiler();
                factura.Cliente.Alquiler.Plaza = cursor.GetString("plaza");
                factura.Cliente.Alquiler.BaseImponible = cursor.GetDecimal("baseImponible");
                factura.Cliente.Alquiler.Iva = cursor.GetDecimal("iva");
                factura.Cliente.Alquiler.Total = cursor.GetDecimal("total");
            }
            cursor.Close();
            conexion.Close();

            return factura;
        }

        /// <summary>
        /// Obtiene el número para hacer una factura.
        /// </summary>
        /// <returns>El nuevo Id.</returns>
        public static int ObtenerNumFactura()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"SELECT IF (MAX(id) + 1 IS NULL, 1, MAX(id) + 1)
                                                      FROM   facturasGarajes;", conexion);

            int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();

            return nuevoId;
        }

        /// <summary>
        /// Inserta una factura para un garaje.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("INSERT INTO facturasGarajes VALUES (@id, @fecha, @idCliente, @idTipoAlquiler, @idGaraje, @baseImponible, @iva, @total, @estaPagada);", conexion);
            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@idCliente", Cliente.Id);
            comando.Parameters.AddWithValue("@idTipoAlquiler", Cliente.Alquiler.IdTipoAlquiler);
            comando.Parameters.AddWithValue("@idGaraje", Garaje.Id);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);
            comando.Parameters.AddWithValue("@estaPagada", EstaPagada);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        /// <summary>
        /// Modifica los datos de una factura para un garaje.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturasGarajes SET fecha = @fecha, estaPagada = @estaPagada, baseImponible = @baseImponible, iva = @iva, total = @total
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
        /// Elimina una factura.
        /// </summary>        
        /// <returns>La factura se ha eliminado.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABd();
            MySqlCommand comando = new MySqlCommand("DELETE FROM facturasGarajes WHERE id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);

            int numFila = comando.ExecuteNonQuery();
            conexion.Close();

            return numFila >= 1;
        }

        public FacturaGaraje() : base()
        {
            Cliente = new ClienteGaraje();
            Alquiler = new Alquiler();
            Garaje = new Garaje();
        }

        public FacturaGaraje(DateTime fecha)
        {
            Fecha = fecha;
        }

        public FacturaGaraje(int id)
        {
            Id = id;
        }
    }
}
