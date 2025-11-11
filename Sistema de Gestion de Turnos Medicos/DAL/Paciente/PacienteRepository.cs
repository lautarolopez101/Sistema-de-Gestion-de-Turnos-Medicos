using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PacienteRepository : IPacienteRepository
    {
        public int AltaPaciente(PacienteBE paciente)
        {
            var retorna = PacienteDAL.AltaPaciente(paciente);
            if (paciente.Estado == "Desactivado")
            {
                retorna = DesactivarPaciente(paciente);
            }
            return retorna;

        }
        public int BajaPaciente(PacienteBE paciente)
        {
            var retorna = PacienteDAL.BajaPaciente(paciente);
            retorna = PacienteDAL.DesactivarPaciente(paciente);
            return retorna;
        }

        public int ModificarPaciente(PacienteBE paciente)
        {
            var retorna = PacienteDAL.ModificarPaciente(paciente);
            if (paciente.Estado == "Desactivado")
            {
                retorna = DesactivarPaciente(paciente);
            }
            return retorna;
        }
        public PacienteBE ObtenerPaciente(int idpaciente)
        {
            return PacienteDAL.ObtenerPaciente(idpaciente);
        }
        public PacienteBE ObtenerPacienteEmail(string email)
        {
            return PacienteDAL.ObtenerPacienteEmail(email);
        }
        public List<PacienteBE> ListarPacientesEstado(string cual)
        {
            // Logica de acceso a la BD
            var lista = PacienteDAL.ListarPacientesEstado(cual); // el metodo que ejecuta el SQL 
            // Si devuelve lista la convierte a una Lista de entidades de los pacientes para ya tenerlos como objetos
            return lista ?? new List<PacienteBE>();
        }

        public List<PacienteBE> ObtenerTodos()
        {
            var lista = PacienteDAL.ObtenerTodos(); // el metodo que ejecuta el SQL 
            return lista;
        }
        public int ActivarPaciente(PacienteBE paciente)
        {
            string estado = paciente.Estado;
            if (estado == "Activo")
            {
                int retorname = PacienteDAL.ActivoPaciente(paciente);
                return retorname;
            }
            int retorna = 0;
            return retorna;
        }
        public int DesactivarPaciente(PacienteBE paciente)
        {
            string estado = paciente.Estado;
            if (estado == "Desactivado")
            {
                int retornamos = PacienteDAL.DesactivarPaciente(paciente);
                return retornamos;
            }
            int retorna = 0;
            return retorna;
        }
    }
}
