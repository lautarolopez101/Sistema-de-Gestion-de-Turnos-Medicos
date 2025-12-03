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
        private readonly IPacienteRepository _pacienterepository;
        private readonly IProfesionalRepository _profesionalrepository;
        public TurnoService(ITurnoRepository repository, IPacienteRepository pacienterepository, IProfesionalRepository profesionalrepository)
        {
            _repo = repository;
            _pacienterepository = pacienterepository;
            _profesionalrepository = profesionalrepository;
        }
        public int AgregarTurnoCompleto(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones)
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
        public int AgregarTurnoIncompleto(int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo)
        {
            TurnoBE turno = new TurnoBE();
            turno.ID_Paciente = idpaciente;
            turno.ID_Profesional = idprofesional;
            turno.Estado = estado;
            turno.Motivo = motivo;
            turno.FechaHora = fecha;
            return _repo.AgregarTurno(turno);
        }
        public int ModificarTurno(int idturno, int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones)
        {
            TurnoBE turno = new TurnoBE();
            turno.ID_Turno = idturno;
            turno.ID_Paciente = idpaciente;
            turno.ID_Profesional = idprofesional;
            turno.Estado = estado;
            turno.Motivo = motivo;
            turno.Observaciones = observaciones;
            turno.FechaHora = fecha;
            return _repo.ModificarTurno(turno);
        }

        public int FechaTurno(int idturno,DateTime fecha)
        {
            // Lo que hacemos para este metodo de business es traer el turno y modificar lo que necesitamos
            // 1: Traemos la lista para que sea mas facil y rapido
            List<TurnoBE> lista = _repo.ObtenerTodos();
            // 2: Creamos una entidad de turno para hacer un LINQ seleccionando el primero 
            // que cumpla la condicion de que sean iguales los idturnos
            TurnoBE turnoencontrado = lista
                .FirstOrDefault(x => x.ID_Turno == idturno);

            if (turnoencontrado == null)
                throw new BusinessException("Turno no Encontrado.");

            // Ya con el turno completo reemplazamos el dato que necesitamos modificar
            turnoencontrado.FechaHora = fecha;
            // Ahora con el turno modificado lo tenemos que modificar en la Base de Datos
            int retorna = _repo.ModificarTurno(turnoencontrado);
            return retorna;

        }

        public int EliminarTurno(int idturno, int idpaciente, int idprofesional, string estado, DateTime fecha, string motivo, string observaciones)
        {
            TurnoBE turno = new TurnoBE();
            turno.ID_Turno = idturno;
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

        // Necesitamos este metodo para poder verificar si ya existe un turno hecho 
        public List<TurnoBE> VerificoDuplicado(int idprofesional, int idpaciente)
        {
            // Hacemos una lista de turnos porque pueden haber mas de un turno con un mismo profesional y paciente
            List<TurnoBE> listaturnos = new List<TurnoBE>();
            // Obtenemos todos los turnos hechos para poder luego
            listaturnos = _repo.ObtenerTodos();
            // Con un LINQ buscamos los que coincidan con las variables del parametro
            var resultantes = listaturnos.Where(e => e.ID_Profesional == idprofesional && e.ID_Paciente == idpaciente).ToList();
            // Devolvemos la lista con todos los resultados que veriquen lo anterior
            return resultantes;
        }

        public List<TurnoBE> Verifico(int idturno)
        {
            List<TurnoBE> listaturnos = new List<TurnoBE>();
            listaturnos = _repo.ObtenerTodos();
            var existe = listaturnos.Where(e => e.ID_Turno == idturno).ToList();
            return existe;
        }
        public List<TurnoBE> FiltrarPacienteHistorial(int idpaciente,string estado1, string estado2 )
        {
            return _repo.FiltrarPacienteHistorial(idpaciente,estado1,estado2);
        }
    }
}
