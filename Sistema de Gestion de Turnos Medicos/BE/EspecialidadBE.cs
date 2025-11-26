using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EspecialidadBE
    {
        public int ID_Especialidad { get; set; }
        public string Especialidad { get; set; }
        public string Descripcion { get; set; }

        public EspecialidadBE()
        {
            //Constructor para uso de prueba para cuando se crea el objeto

        }
        public EspecialidadBE(int id, string especialidad, string descripcion)
        {
            ID_Especialidad = id;
            Especialidad = especialidad;
            Descripcion = descripcion;
        }
        public EspecialidadBE(string especialidad)
        {
            Especialidad = especialidad;
        }
        public EspecialidadBE(string especialidad, string descripcion)
        {
            Especialidad = especialidad;
            Descripcion = descripcion;
        }
    }
}
