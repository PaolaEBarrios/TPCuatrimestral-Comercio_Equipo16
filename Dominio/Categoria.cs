﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class Categoria
    {
        public int Codigo { get; set; }
        public string NombreCategoria { get; set; }



        public override string ToString()
        {
            return NombreCategoria;
        }
    }
}
