using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProfesional_EspecialidadService
    {
        // Vinculos de TODO
        int EliminarProfesional(int idprofesional);


        // Vinculos de 1:1
        int AgregarProfesional_Especialidad(int idespecialidad, int profesional);
        int ModificarProfesional_Especialidad(int idespecialidad, int profesional);
        int EliminarProfesional_Especialidad(int idespecialidad, int profesional);
        List<Profesionales_EspecialidadesBE> ListarProfesionales_Especialidades();
    }
}
