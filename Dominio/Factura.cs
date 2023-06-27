using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public int Codigo { get; set; }
        public Venta Venta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
