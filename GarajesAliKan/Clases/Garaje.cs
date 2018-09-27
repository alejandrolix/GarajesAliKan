using System.Collections.Generic;

namespace GarajesAliKan.Clases
{
    class Garaje
    {
        public int Id { get; set; }
        public string SubId { get; set; }
        public string Nombre { get; set; }        

        /// <summary>
        /// Obtiene todos los garajes.
        /// </summary>
        /// <returns>Los Garajes.</returns>
        public static List<string> ObtenerGarajes()
        {
            List<string> listaNombresGarajes = Foo.ConexionABd().Fetch<string>("SELECT nombre FROM garajes;");
            Foo.ConexionABd().CloseSharedConnection();

            return listaNombresGarajes;
        }
    }
}
