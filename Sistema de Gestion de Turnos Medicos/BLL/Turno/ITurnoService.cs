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
        int AgregarTurnoCompleto(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo,string observaciones);
        int AgregarTurnoIncompleto(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo);

        int ModificarTurno(int idturno,int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones);
        int EliminarTurno(int idturno,int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones);
        List<TurnoBE> ObtenerTodos();
        List<TurnoBE> VerificoDuplicado(int idprofesional, int idpaciente);
        List<TurnoBE> Verifico(int idturno);
        List<TurnoBE> FiltrarPacienteHistorial(int idpaciente, string estado1, string estado2);
    }
}
