using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario:Cliente
    {
        public string usuario { get; set; }
        public string contraseña { get; set; }
    }
}
