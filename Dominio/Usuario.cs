using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public enum TipoUsuario
        {
            VENDEDOR=1,
            ADMIN=2
        }
        public int id { get; set; } 
        public string nombreUser { get; set; }
        public string contraseña { get; set; }
        public TipoUsuario tipoUser { get; set; }


        

    }
}
