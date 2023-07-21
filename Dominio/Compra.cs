using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int Codigo { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }//productos

        public string FormaPago { get; set; }

        public DateTime FechaCompra { get; set; }

        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public decimal Total { get; set; }
    }
}
