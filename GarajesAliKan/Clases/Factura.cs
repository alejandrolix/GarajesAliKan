using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using MySql.Data.MySqlClient;

namespace GarajesAliKan.Clases
{
    class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }   
        public Garaje Garaje { get; set; }        
        public string Plaza { get; set; }
        public bool EstaPagada { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        /// <summary>
        /// Comprueba si existen facturas de todos los garajes.
        /// </summary>
        /// <returns></returns>
        public static bool HayFacturasGarajes()
        {
            Database conexion = Foo.ConexionABd();
            int numFacturas = conexion.ExecuteScalar<int>(@"SELECT COUNT(id)
                                                            FROM   facturas
                                                            WHERE  esFacturaGaraje IS TRUE;");
            conexion.CloseSharedConnection();
            return numFacturas >= 1;
        }

        /// <summary>
        /// Obtiene todas las facturas de los garajes.
        /// </summary>
        /// <returns>Las facturas de los garajes.</returns>
        public static List<Factura> ObtenerFacturasGarajes()
        {
            Database conexion = Foo.ConexionABd();
            List<Factura> listaFacturas = conexion.Fetch<Factura>(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                                   plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                                    FROM   facturas fact
                                                                           JOIN clientes cli ON fact.idCliente = cli.id
                                                                           JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                                           JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                                           JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                                    WHERE  fact.esFacturaGaraje IS TRUE
                                                                    ORDER BY fact.id;");            
            conexion.CloseSharedConnection();
            return listaFacturas;
        }

        /// <summary>
        /// Obtiene los Ids de las facturas de todos los garajes.
        /// </summary>
        /// <returns>Los Ids de las facturas de todos los garajes.</returns>
        public static List<int> ObtenerIdsFacturasGarajes()
        {
            Database conexion = Foo.ConexionABd();
            List<int> listaIds = conexion.Fetch<int>("SELECT id FROM facturas ORDER BY id;");

            conexion.CloseSharedConnection();            
            return listaIds;
        }

        /// <summary>
        /// Obtiene las fechas de todas las facturas.
        /// </summary>
        /// <returns>Las fechas de todas las facturas.</returns>
        public static List<DateTime> ObtenerFechas()
        {
            Database conexion = Foo.ConexionABd();
            List<DateTime> listaFechas = conexion.Fetch<DateTime>("SELECT fecha FROM facturas ORDER BY fecha;");

            conexion.CloseSharedConnection();
            return listaFechas;
        }

        /// <summary>
        /// Elimina una factura.
        /// </summary>        
        /// <returns>La factura se ha eliminado.</returns>
        public bool Eliminar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand("DELETE FROM facturas WHERE id = @id;", conexion);

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
        /// Inserta una factura.
        /// </summary>        
        /// <returns>La factura se ha insertado.</returns>
        public bool Insertar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
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
        /// Modifica los datos de una factura.
        /// </summary>
        /// <returns>Se han modificado los datos de la factura.</returns>
        public bool Modificar()
        {
            MySqlConnection conexion = Foo.ConexionABdMySQL();
            MySqlCommand comando = new MySqlCommand(@"UPDATE facturas SET fecha = @fecha, estaPagada = @estaPagada, baseImponible = @baseImponible, iva = @iva,
                                                                          total = @total
                                                      WHERE  id = @id;", conexion);

            comando.Parameters.AddWithValue("@id", Id);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@estaPagada", EstaPagada);
            comando.Parameters.AddWithValue("@baseImponible", BaseImponible);
            comando.Parameters.AddWithValue("@iva", Iva);
            comando.Parameters.AddWithValue("@total", Total);            

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
        /// Obtiene una factura a partir de su Id.
        /// </summary>
        /// <param name="idFactura">El Id de una factura-</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaPorId(int idFactura)
        {
            Database conexion = Foo.ConexionABd();
            Factura factura = conexion.Single<Factura>(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                        plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                         FROM   facturas fact
                                                                JOIN clientes cli ON fact.idCliente = cli.id
                                                                JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                                JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                                JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                         WHERE  fact.id = @0;", idFactura);
            conexion.CloseSharedConnection();
            return factura;
        }

        /// <summary>
        /// Obtiene una factura a partir de un Id de un cliente.
        /// </summary>
        /// <param name="idCliente">El Id de un cliente.</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaPorIdCliente(int idCliente)
        {
            Database conexion = Foo.ConexionABd();
            Factura factura = conexion.Single<Factura>(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                        plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                         FROM   facturas fact
                                                                JOIN clientes cli ON fact.idCliente = cli.id
                                                                JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                                JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                                JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                         WHERE  cli.id = @0;", idCliente);
            conexion.CloseSharedConnection();
            return factura;
        }

        /// <summary>
        /// Obtiene una factura a partir de una fecha.
        /// </summary>
        /// <param name="fecha">La fecha.</param>
        /// <returns>Los datos de la factura.</returns>
        public static Factura ObtenerFacturaPorFecha(DateTime fecha)
        {
            Database conexion = Foo.ConexionABd();
            Factura factura = conexion.Single<Factura>(@"SELECT fact.id, fact.fecha, cli.nif, CONCAT(cli.nombre, ' ', cli.apellidos) AS nombre, fact.estaPagada, tAlq.concepto, gaj.nombre,
    	                                                        plzCli.plaza, fact.baseImponible, fact.iva, fact.total
                                                         FROM   facturas fact
                                                                JOIN clientes cli ON fact.idCliente = cli.id
                                                                JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
                                                                JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                                JOIN plazaCliente plzCli ON cli.id = plzCli.idCliente
                                                         WHERE  fact.fecha = @0;", fecha);
            conexion.CloseSharedConnection();
            return factura;
        }

        public Factura(bool crearFactura)
        {
            if (crearFactura)
            {
                Cliente = new Cliente();
                Cliente.Alquiler = new Alquiler();
                Garaje = new Garaje();
            }            
        }

        public Factura()
        {
        }
    }
}
