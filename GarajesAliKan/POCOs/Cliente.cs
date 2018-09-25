using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace GarajesAliKan.POCOs
{
    class Cliente
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("apellidos")]
        public string Apellidos { get; set; }
        [BsonElement("nif")]
        public string Nif { get; set; }
        [BsonElement("direccion")]
        public string Direccion { get; set; }
        [BsonElement("telefono")]
        public string Telefono { get; set; }
        [BsonElement("garaje")]
        public Garaje Garaje { get; set; }
        [BsonElement("observaciones")]
        public string Observaciones { get; set; }
        [BsonElement("llaveMando")]
        public int LlaveMando { get; set; }
        [BsonElement("esClienteGaraje")]
        public bool EsClienteGaraje { get; set; }
    }
}
