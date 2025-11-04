using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITurnoService
    {
        int AgregarTurno(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones);
        int ModificarTurno(int idturno,int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones);
        int EliminarTurno(int idturno,int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones);
        List<TurnoBE> ObtenerTodos();
        List<TurnoBE> VerificoDuplicado(int idprofesional, int idpaciente);
        List<TurnoBE> Verifico(int idturno);
    }
}
