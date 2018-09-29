using System.Collections.Generic;
using PetaPoco;

namespace GarajesAliKan.Clases
{    
    class TipoAlquiler
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        
        /// <summary>
        /// Obtiene todos los conceptos.
        /// </summary>
        /// <returns>Los conceptos.</returns>
        public static List<TipoAlquiler> ObtenerConceptos()
        {
            Database conexion = Foo.ConexionABd();
            List<TipoAlquiler> listaTiposAlquileres = conexion.Fetch<TipoAlquiler>("SELECT id, concepto FROM tiposAlquileres;");
            conexion.CloseSharedConnection();

            return listaTiposAlquileres;
        }

        public TipoAlquiler(int id)
        {
            Id = id;
        }

        public TipoAlquiler()
        {
        }
    }
}
