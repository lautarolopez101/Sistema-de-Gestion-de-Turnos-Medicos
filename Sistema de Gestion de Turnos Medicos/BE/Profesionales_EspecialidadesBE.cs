using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Profesionales_EspecialidadesBE
    {
        public int ID_Profesional { get; set; }
        public int ID_Especialidad { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public Profesionales_EspecialidadesBE()
        {
            
        }
        public Profesionales_EspecialidadesBE(int profe,int espe,DateTime create)
        {
            ID_Profesional = profe;
            ID_Especialidad = espe;
            CreatedAtUtc = create;
        }
    }
}
