using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PatenteBE
    {
        public int ID_Patente { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public PatenteBE()
        {
            
        }
        public PatenteBE(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion; 
            Activo = true;
        }
    }
}
