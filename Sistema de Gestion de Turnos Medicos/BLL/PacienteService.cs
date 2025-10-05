using BE;
using System;
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

        public List<PacienteBE> ListarPacientes()
        {
            // Aqui van  las reglas de negocio, validaciones, filtros, etc.
            var pacientes = _repo.ObtenerTodos();
            // Ejemplo: filtrar los pacientes inactivos
            // pacientes = pacientes.where(p => p.Activo).ToList();
            return pacientes;
        }
    }
}
