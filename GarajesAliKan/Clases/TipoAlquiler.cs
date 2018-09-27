using System.Collections.Generic;

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
        public static List<string> ObtenerConceptos()
        {
            return Foo.ConexionABd().Fetch<string>("SELECT concepto FROM tiposAlquileres;");
        }
    }
}
