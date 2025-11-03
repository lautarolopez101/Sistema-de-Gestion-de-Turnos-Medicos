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
    }
}
