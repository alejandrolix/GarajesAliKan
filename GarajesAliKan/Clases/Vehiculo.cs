using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace GarajesAliKan.Clases
{
    class Vehiculo
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("marca")]
        public string Marca { get; set; }
        [BsonElement("modelo")]
        public string Modelo { get; set; }
        [BsonElement("matricula")]
        public string Matricula { get; set; }
        [BsonElement("plaza")]
        public string Plaza { get; set; }
    }
}
