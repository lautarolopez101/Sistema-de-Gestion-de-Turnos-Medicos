using BE;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repo;

        public PacienteService(IPacienteRepository repo)
        {
            _repo = repo;
        }
        public int ModificarPaciente(PacienteBE paciente)
        {
            var retorna = _repo.ModificarPaciente(paciente);
            return retorna;
        }

        public int EliminarPaciente(PacienteBE paciente)
        {
            var retorna = _repo.EliminarPaciente(paciente);
            return retorna;
        }

        public List<PacienteBE> ListarPacientes()
        {
            // Aqui van  las reglas de negocio, validaciones, filtros, etc.
            var pacientes = _repo.ObtenerTodos();
            // Ejemplo: filtrar los pacientes inactivos
            // pacientes = pacientes.where(p => p.Activo).ToList();
            return pacientes;
        }
        public int RegistrarPaciente(PacienteBE paciente)
        {
            var retorna = _repo.AgregarPaciente(paciente);
            return retorna;
        }
        public List<PacienteBE> ListarPacientesDesactivados()
        {
            // Aqui van  las reglas de negocio, validaciones, filtros, etc.
            var pacientes = _repo.ObtenerTodosDesactivados();
            // Ejemplo: filtrar los pacientes inactivos
            // pacientes = pacientes.where(p => p.Activo).ToList();
            return pacientes;
        }
    }
}
