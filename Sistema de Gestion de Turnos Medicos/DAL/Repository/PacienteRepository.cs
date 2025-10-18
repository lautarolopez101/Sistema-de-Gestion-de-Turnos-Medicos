using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PacienteRepository : IPacienteRepository
    {
        public int AltaPaciente(PacienteBE paciente)
        {
            var retorna = PacienteDAL.AltaPaciente(paciente);
            if(paciente.Estado == "Desactivado")
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
            if(paciente.Estado == "Desactivado")
            {
                retorna = DesactivarPaciente(paciente);
            }
            return retorna;
        }
        public List<PacienteBE> ObtenerTodos(string cual)
        {
            // Logica de acceso a la BD
            var lista = PacienteDAL.ListarPacientes(cual); // el metodo que ejecuta el SQL 
            // Si devuelve lista la convierte a una Lista de entidades de los pacientes para ya tenerlos como objetos
            return lista ?? new List<PacienteBE>();
        }

        public int ActivarPaciente(PacienteBE paciente)
        {
            string estado = paciente.Estado;
            if(estado == "Activo")
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
            if(estado == "Desactivado")
            {
                int retornamos = PacienteDAL.DesactivarPaciente(paciente);
                return retornamos;
            }
            int retorna = 0;
            return retorna;
        }
    }
}
