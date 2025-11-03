using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _repo;
        public TurnoService(ITurnoRepository repository)
        {
            _repo = repository;
        }
        public int AgregarTurno(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones)
        {
            TurnoBE turno = new TurnoBE();
            turno.ID_Paciente = idpaciente;
            turno.ID_Profesional = idprofesional;
            turno.Estado = estado;
            turno.Motivo = motivo;
            turno.Observaciones = observaciones;
            turno.FechaHora = fecha;
            return _repo.AgregarTurno(turno);
        }
        public int ModificarTurno(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones)
        {
            TurnoBE turno = new TurnoBE();
            turno.ID_Paciente = idpaciente;
            turno.ID_Profesional = idprofesional;
            turno.Estado = estado;
            turno.Motivo = motivo;
            turno.Observaciones = observaciones;
            turno.FechaHora = fecha;
            return _repo.ModificarTurno(turno);
        }
        public int EliminarTurno(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones)
        {
            TurnoBE turno = new TurnoBE();
            turno.ID_Paciente = idpaciente;
            turno.ID_Profesional = idprofesional;
            turno.Estado = estado;
            turno.Motivo = motivo;
            turno.Observaciones = observaciones;
            turno.FechaHora = fecha;
            return _repo.EliminarTurno(turno);
        }
        public List<TurnoBE> ObtenerTodos()
        {
            return _repo.ObtenerTodos();
        }
    }
}
