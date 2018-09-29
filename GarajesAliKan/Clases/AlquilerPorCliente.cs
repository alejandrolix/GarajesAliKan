using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajesAliKan.Clases
{
    class AlquilerPorCliente
    {
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public int IdTipoAlquiler { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Plaza { get; set; }
        public int Llave { get; set; }

        public AlquilerPorCliente(decimal baseImponible, decimal iva, decimal total, string plaza, int llave)
        {
            BaseImponible = baseImponible;
            Iva = iva;
            Total = total;
            Plaza = plaza;
            Llave = llave;
        }

        //public AlquilerPorCliente()
        //{

        //}
    }
}
