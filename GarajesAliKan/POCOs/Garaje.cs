using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace GarajesAliKan.POCOs
{
    class Garaje
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("subId")]
        public string SubId { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
    }
}
