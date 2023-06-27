using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor:Persona
    {
        public int Codigo { get; set; }
        public Producto Producto { get; set; }
        
    }
}
