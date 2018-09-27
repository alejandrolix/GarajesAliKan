using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace GarajesAliKan.Clases
{
    class Garaje
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("subId")]
        public string SubId { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("llave")]
        public int Llave { get; set; }

        /// <summary>
        /// Obtiene todos los garajes.
        /// </summary>
        /// <returns>Los Garajes.</returns>
        public static List<Garaje> ObtenerGarajes()
        {
            return Foo.ConexionABd().GetCollection<Garaje>("garajes").Find<Garaje>("{}").Project<Garaje>("{ _id: 0, nombre: 1 }").ToList();
        }
    }
}
