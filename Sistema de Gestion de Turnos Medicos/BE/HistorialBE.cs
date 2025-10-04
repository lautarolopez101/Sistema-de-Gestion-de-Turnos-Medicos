using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HistorialBE
    {
        public int ID_Historial { get; set; }
        public string Diagnostico { get; set; }
        public string Indicaciones { get; set; }
        public string  Notas { get; set; }

        public HistorialBE(int id, string diagnostico, string indicaciones, string notas)
        {
            ID_Historial = id;
            Diagnostico = diagnostico;
            Indicaciones = indicaciones;
            Notas = notas;
        }
        public HistorialBE()
        {
            //usar para ver si funciona el codigo
            
        }
        public HistorialBE(string diagnostico,string indicaciones,string notas)
        {
            Diagnostico = diagnostico;
            Indicaciones = indicaciones;
            Notas = notas;
        }
    }
}
