using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TurnoRepository :ITurnoRepository
    {
        public int AgregarTurno(TurnoBE turno)
        {
            return TurnoDAL.AgregarTurnos(turno);
        }
        public int ModificarTurno(TurnoBE turno)
        {
            return TurnoDAL.ModificarTurnos(turno);
        }
        public int EliminarTurno(TurnoBE turno)
        {
            return TurnoDAL.EliminarTurnos(turno);
        }
        public List<TurnoBE> ObtenerTodos()
        {
            return TurnoDAL.ObtenerTodos();
        }
        public List<TurnoBE> FiltrarPacienteHistorial(int idpaciente,string estado1,string estado2)
        {
            return TurnoDAL.FiltrarPacienteHistorial(idpaciente,estado1,estado2);
        }
        public List<TurnoBE> TurnosPorProfesional(int idprofesional)
        {
            return TurnoDAL.TurnosPorProfesional(idprofesional);
        }
    }
}
