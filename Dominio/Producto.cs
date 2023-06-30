using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string NombreProducto { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Ganancia { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }





    }
}
