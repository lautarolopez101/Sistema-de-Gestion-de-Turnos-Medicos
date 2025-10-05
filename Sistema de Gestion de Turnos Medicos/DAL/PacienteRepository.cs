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
        public List<PacienteBE> ObtenerTodos()
        {
            // Logica de acceso a la BD
            var lista = PacienteDAL.ListarPacientes(); // el metodo que ejecuta el SQL 
            // Si devuelve lista la convierte a una Lista de entidades de los pacientes para ya tenerlos como objetos
            return lista ?? new List<PacienteBE>();
        }
    }
}
