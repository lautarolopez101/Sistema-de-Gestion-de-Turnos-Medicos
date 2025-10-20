using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FamiliaBE
    {
        public int ID_Familia { get; set; }
        public string  Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public List<PatenteBE> patentes { get; set; } = new List<PatenteBE>();
        public List<FamiliaBE> Familias { get; set; } = new List<FamiliaBE>();

        public FamiliaBE()
        {
            
        }
        public FamiliaBE(string nombre, string descipcion)
        {
            Nombre = nombre;
            Descripcion = descipcion;
            Activo = true;
        }
    }
}
