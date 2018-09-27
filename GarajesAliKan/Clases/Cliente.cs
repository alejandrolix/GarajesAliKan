using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GarajesAliKan.Clases
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
        [BsonElement("vehiculo")]
        public Vehiculo Vehiculo { get; set; }
        [BsonElement("alquiler")]
        public TipoAlquiler TipoAlquiler { get; set; }
        [BsonElement("observaciones")]
        public string Observaciones { get; set; }        
        [BsonElement("esClienteGaraje")]
        public bool EsClienteGaraje { get; set; }

        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        /// <returns>Los clientes existentes.</returns>
        public static List<Cliente> ObtenerClientes()
        {
            return Foo.ConexionABd().GetCollection<Cliente>("clientes").Find<Cliente>("{}").ToList();
        }
    }
}
