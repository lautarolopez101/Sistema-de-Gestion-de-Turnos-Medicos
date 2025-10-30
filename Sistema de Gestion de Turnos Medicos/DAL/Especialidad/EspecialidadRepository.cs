using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        public int AgregarEspecialidad(EspecialidadBE especialidad)
        {
            return EspecialidadDAL.AgregarEspecialidad(especialidad);
        }   

        public int ModificarEspecialidad(EspecialidadBE especialidad)
        {
            return EspecialidadDAL.ModificarEspecialidad(especialidad);
        }

        public int EliminarEspecialidad(EspecialidadBE especialidad)
        {
            return EspecialidadDAL.EliminarEspecialidad(especialidad);
        }

        public List<EspecialidadBE> ObtenerTodas()
        {
            return EspecialidadDAL.ObtenerEspecialidades();
        }
    }
}
