using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AuthResultBE
    {
        public bool Exito{ get; set; } // Indica si el login fue correcto
        public string Mensaje { get; set; } // Explicacion (exito o error)  
        public UsuarioBE Usuario { get; set; }  // Usuario autenticado (solo si Exito = true)

    }
}
