using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace GarajesAliKan.Clases
{
    class TipoAlquiler
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("concepto")]
        public string Concepto { get; set; }
        [BsonElement("baseImponible")]
        public double BaseImponible { get; set; }
        [BsonElement("iva")]
        public double Iva { get; set; }
        [BsonElement("total")]
        public double Total { get; set; }

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
