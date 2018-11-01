using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajesAliKan.Clases
{
    class Factura
    {
        protected int id;
        protected DateTime fecha;
        protected decimal baseImponible;
        protected decimal iva;
        protected decimal total;
        
        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal BaseImponible { get => baseImponible; set => baseImponible = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Total { get => total; set => total = value; }

        public Factura(int id)
        {
            Id = id;
        }

        public Factura()
        {
        }
    }
}
