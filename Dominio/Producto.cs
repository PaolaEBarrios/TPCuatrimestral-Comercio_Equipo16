using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int codigo { get; set; }
        public string producto { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int ganancia { get; set; }
        public int stock { get; set; }
        public int stockMin { get; set; }


    }
}
