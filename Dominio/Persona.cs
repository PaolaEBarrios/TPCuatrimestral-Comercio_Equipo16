using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Contacto contacto { get; set; }

        public Tipo tipo { get; set; }

        public string dni { get; set; }

        public string cuit { get; set; }


    }
}
