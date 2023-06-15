using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        
        public int codigo { get; set; }
        //public List<Producto> productos { get; set; }
        public Vendedor vendedor { get; set; }
        public int codigoProducto { get; set; }
        public decimal precioUnidad { get; set; }
        public decimal precioParcial { get; set; }

        public decimal precioFinal { get; set; }
        public int cantidad { get; set; }
        public Cliente cliente { get; set; }
        public decimal total { get; set; }
        
    }
}
