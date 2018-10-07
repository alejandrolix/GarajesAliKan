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
        //public Alquiler Alquiler { get; set; }
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
		                                                                   fact.plaza, fact.baseImponible, fact.iva, fact.total
                                                                    FROM   facturas fact
		                                                                   JOIN clientes cli ON fact.idCliente = cli.id
		                                                                   JOIN tiposAlquileres tAlq ON fact.idTipoAlquiler = tAlq.id
		                                                                   JOIN garajes gaj ON fact.idGaraje = gaj.id
                                                                    WHERE  fact.esFacturaGaraje IS TRUE
                                                                    ORDER BY fact.id;");            
            conexion.CloseSharedConnection();
            return listaFacturas;
        }
    }
}
