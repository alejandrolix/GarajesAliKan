using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajesAliKan.Clases
{
    class Vehiculo
    {        
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }        
        public string Modelo { get; set; }                        
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }        
        public string Plaza { get; set; }
    }
}
