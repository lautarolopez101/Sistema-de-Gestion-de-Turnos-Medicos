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
        public List<PacienteBE> ObtenerPacientesBD()
        {
            List<PacienteBE> lista = new List<PacienteBE>();
            lista = PacienteDAL.ListarPacientes();
            return lista;
        }
    }
}
