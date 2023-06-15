using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public int codigo { get; set; }
        public Venta venta { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
    }
}
