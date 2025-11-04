using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProfesionalRepository
    {
        int AgregarProfesional(ProfesionalBE profesional);
        int ModificarProfesional(ProfesionalBE profesional);
        int EliminarProfesional(ProfesionalBE profesional);
        List<ProfesionalBE> ObtenerProfesionales();

        List<ProfesionalBE> ListarProfesionales(bool cual);
    }
}
