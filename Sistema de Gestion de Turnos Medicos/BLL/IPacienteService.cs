using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPacienteService
    {
        int RegistrarPaciente(PacienteBE paciente);
        int EliminarPaciente(PacienteBE paciente);
        int ModificarPaciente(PacienteBE paciente);
        List<PacienteBE> ListarPacientes();
        List<PacienteBE> ListarPacientesDesactivados();

    }
}
