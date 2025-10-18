using BE;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public int ModificarPaciente(int id,string dni, string nombre, string apellido,string email, string telefono,DateTime fechanacimiento, string estado)
        {
            PacienteBE paciente = new PacienteBE();
            paciente.ID_Paciente = id;
            paciente.DNI = dni;
            paciente.Nombre = nombre;
            paciente.Apellido = apellido;
            paciente.Email = email;
            paciente.Telefono = telefono;
            paciente.FechaNacimiento = fechanacimiento;
            paciente.Estado = estado;
            paciente.UpdatedAtUtc = DateTime.Now;
            var retorna = _repo.ModificarPaciente(paciente);
            return retorna;
        }

        public int BajaPaciente(int id,string dni, string nombre, string apellido, string email, string telefono, DateTime fechanacimiento, string estado)
        {
            PacienteBE paciente = new PacienteBE();
            paciente.ID_Paciente = id;
            paciente.DNI = dni;
            paciente.Nombre = nombre;
            paciente.Apellido = apellido;
            paciente.Email = email;
            paciente.Telefono = telefono;
            paciente.FechaNacimiento = fechanacimiento;
            paciente.Estado = estado;
            var retorna = _repo.BajaPaciente(paciente);
            return retorna;
        }

        public List<PacienteBE> ListarPacientes(string cual)
        {
            // Aqui van  las reglas de negocio, validaciones, filtros, etc.
            var pacientes = _repo.ObtenerTodos(cual);
            // Ejemplo: filtrar los pacientes inactivos
            // pacientes = pacientes.where(p => p.Activo).ToList();
            return pacientes;
        }
        public int AltaPaciente(string dni, string nombre, string apellido, string email, string telefono, DateTime fechanacimiento, string estado)
        {
            PacienteBE paciente = new PacienteBE();
            paciente.DNI = dni;
            paciente.Nombre = nombre;
            paciente.Apellido = apellido;
            paciente.Email = email;
            paciente.Telefono = telefono;
            paciente.FechaNacimiento = fechanacimiento;
            paciente.Estado= estado;
            var retorna = _repo.AltaPaciente(paciente);
            return retorna;
        }

        public int ActivarPaciente(int id, string dni, string nombre, string apellido, string email, string telefono, DateTime fechanacimiento, string estado)
        {
            PacienteBE paciente = new PacienteBE();
            paciente.ID_Paciente = id;
            paciente.DNI = dni;
            paciente.Nombre = nombre;
            paciente.Apellido= apellido;
            paciente.Email = email;
            paciente.Telefono= telefono;
            paciente.FechaNacimiento = fechanacimiento;
            paciente.Estado = estado;
            var retorna = _repo.ActivarPaciente(paciente);
            return retorna;
        }
    }
}
