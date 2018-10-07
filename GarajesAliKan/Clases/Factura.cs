using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace GarajesAliKan.Clases
{
    class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }   
        public Garaje Garaje { get; set; }
        public bool EstaPagada { get; set; }
        public string Plaza { get; set; }
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
            List<Factura> listaFacturas = conexion.Fetch<Factura>(@"SELECT fact.id, fact.fecha, cli.nif, cli.nombre, cli.apellidos, fact.estaPagada, tAlq.concepto, gaj.nombre,
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
        public static List<Factura> ObtenerFechas()
        {
            Database conexion = Foo.ConexionABd();
            List<Factura> listaFechas = conexion.Fetch<Factura>("SELECT id, fecha FROM facturas ORDER BY fecha;");

            conexion.CloseSharedConnection();
            return listaFechas;
        }
    }
}
