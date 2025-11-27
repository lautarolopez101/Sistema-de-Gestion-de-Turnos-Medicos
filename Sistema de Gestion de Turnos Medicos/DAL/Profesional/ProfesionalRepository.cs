using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProfesionalRepository : IProfesionalRepository
    {
        public int AgregarProfesional(ProfesionalBE profesional)
        {
            return ProfesionalDAL.AgregarProfesional(profesional);
        }
        public int EliminarProfesional(ProfesionalBE profesional)
        {
            return ProfesionalDAL.EliminarProfesional(profesional);
        }
        public int ModificarProfesional(ProfesionalBE profesional)
        {
            return ProfesionalDAL.ModificarProfesional(profesional);
        }
        public ProfesionalBE ObtenerProfesional(int idprofesional)
        {
            return ProfesionalDAL.ObtenerProfesional(idprofesional);
        }
        public ProfesionalBE ObtenerProfesionalPorMatricula(string Matricula)
        {
            return ProfesionalDAL.ObtenerProfesionalPorMatricula(Matricula);
        }
        public List<ProfesionalBE> ObtenerProfesionales()
        {
            return ProfesionalDAL.ObtenerProfesionales();
        }
        public List<ProfesionalBE> ListarProfesionales(bool cual)
        {
            return ProfesionalDAL.ListarProfesionales(cual);
        }
    }
}
