using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ITurnoRepository
    {
        int AgregarTurno(TurnoBE turno);
        int ModificarTurno(TurnoBE turno);
        int EliminarTurno(TurnoBE turno);
        List<TurnoBE> ObtenerTodos();
        List<TurnoBE> FiltrarPacienteHistorial(int idpaciente,string estado1,string estado2);
    }
}
