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
        int AltaPaciente(string dni, string nombre, string apellido, string email, string telefono, DateTime fechanacimiento, string estado);
        int BajaPaciente(int id,string dni, string nombre, string apellido, string email, string telefono, DateTime fechanacimiento, string estado);
        int ModificarPaciente(int id,string dni, string nombre, string apellido, string email, string telefono, DateTime fechanacimiento, string estado);
        int ActivarPaciente(int id, string dni, string nombre, string apellido , string email, string telefono , DateTime fechanacimiento,string estado);
        List<PacienteBE> ObtenerTodos();
        List<PacienteBE> ListarPacientesEstado(string cual);
    }
}
