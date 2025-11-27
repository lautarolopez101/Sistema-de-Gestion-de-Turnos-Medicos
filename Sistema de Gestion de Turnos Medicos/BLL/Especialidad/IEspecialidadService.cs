using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IEspecialidadService
    {
        int AgregarEspecialidad(string especialidad,string descripcion);
        int ModificarEspecialidad(int id,string especialidad, string descripcion);
        int EliminarEspecialidad(int id,string especialidad, string descripcion);
        List<EspecialidadBE> ListarEspecialidades();
        EspecialidadBE BuscarPorNombre(string nombre);
    }
}
