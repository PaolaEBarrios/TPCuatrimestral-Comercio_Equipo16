using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Contacto
    {
        public string domicilio { get; set; }

        public override string ToString()
        {
            return domicilio;
        }
        public string telefono { get; set; }


        public string email { get; set; }
        public string cp { get; set; }

    }
}
