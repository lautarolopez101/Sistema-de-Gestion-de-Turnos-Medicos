using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProfesionalService
    {
        int AgregarProfesional(string matricula, string nombre, string apellido, string telefono, string email);
        int EliminarProfesional(int id, bool activo);
        int ModificarProfesional(int id, string matricula, string nombre, string apellido, string telefono, string email,bool activo);
        List<ProfesionalBE> ListarProfesionales(bool cual);
        List<EspecialidadBE> ListarEspecialidadesdelProfesional(int idprofesional);
    }
}
