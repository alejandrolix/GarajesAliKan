using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace GarajesAliKan.Clases
{
    class TipoAlquiler
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene todos los tipos de alquileres.
        /// </summary>
        /// <returns>Los tipos de alquileres</returns>
        public static List<TipoAlquiler> ObtenerTiposAlquileres()
        {
            return Foo.ConexionABd().GetCollection<TipoAlquiler>("tiposAlquileres").Find<TipoAlquiler>("{}").Project<TipoAlquiler>("{ _id: 0, descripcion: 1 }").ToList();            
        }
    }
}
