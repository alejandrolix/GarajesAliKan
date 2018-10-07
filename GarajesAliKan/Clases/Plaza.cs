using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace GarajesAliKan.Clases
{
    class Plaza
    {
        public int IdCliente { get; set; }
        [Column("plaza")]
        public string NombrePlaza { get; set; }

        /// <summary>
        /// Obtiene todas las plazas de garajes y trasteros de los clientes.
        /// </summary>
        /// <returns>Las plazas de garajes y trasteros de los clientes.</returns>
        public static List<Plaza> ObtenerPlazas()
        {
            Database conexion = Foo.ConexionABd();
            List<Plaza> listaPlazas = conexion.Fetch<Plaza>("SELECT idCliente, plaza FROM plazaCliente ORDER BY plaza;");

            conexion.CloseSharedConnection();
            return listaPlazas;
        }
    }
}
