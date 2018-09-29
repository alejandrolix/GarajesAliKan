using System.Collections.Generic;
using PetaPoco;

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
        public static List<Garaje> ObtenerGarajes()
        {
            Database conexion = Foo.ConexionABd();
            List<Garaje> listaNombresGarajes = conexion.Fetch<Garaje>("SELECT id, nombre FROM garajes;");
            conexion.CloseSharedConnection();

            return listaNombresGarajes;
        }

        public Garaje(int id)
        {
            Id = id;
        }

        public Garaje(string nombre)
        {
            Nombre = nombre;
        }

        public Garaje()
        {
        }
    }
}
