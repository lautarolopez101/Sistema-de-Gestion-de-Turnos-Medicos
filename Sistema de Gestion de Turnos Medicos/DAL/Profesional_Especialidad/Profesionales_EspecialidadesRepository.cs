using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Profesionales_EspecialidadesRepository : IProfesionales_EspecialidadesRepository
    {
        public List<Profesionales_EspecialidadesBE> ObtenerTodos()
        {
            return Profesionales_EspecialidadesDAL.ListarProfesionalesEspecialidades();
        }

        public int AgregarProfesionalesEspecialidades(Profesionales_EspecialidadesBE nodo)
        {
            return Profesionales_EspecialidadesDAL.AgregarProfesional_Especialidad(nodo);
        }

        public int ModificarProfesionalesEspecialidades(Profesionales_EspecialidadesBE nodo)
        {
            return Profesionales_EspecialidadesDAL.ModificarProfesional_Especialidad(nodo);
        }

        public int EliminarProfesionalesEspecialidades(Profesionales_EspecialidadesBE nodo)
        {
            return Profesionales_EspecialidadesDAL.EliminarProfesional_Especialidad(nodo);
        }
        public int EliminarProfesional(int idprofesional)
        {
            return Profesionales_EspecialidadesDAL.EliminarProfesional(idprofesional);
        }
    }
}
