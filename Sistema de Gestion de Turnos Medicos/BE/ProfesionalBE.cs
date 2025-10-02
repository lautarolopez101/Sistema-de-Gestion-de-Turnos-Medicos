using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProfesionalBE
    {
        public int ID_Profesional { get; set; }
        public int ID_Especialidad { get; set; }
        public string Matricula { get; set; }
        public string Apellido { get; set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
