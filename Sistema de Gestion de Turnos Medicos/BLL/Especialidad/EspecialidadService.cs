using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IEspecialidadRepository _repo;
        private static List<EspecialidadBE> listaespecialidades = new List<EspecialidadBE>();
        public EspecialidadService(IEspecialidadRepository repo)
        {
            _repo = repo;
        }

        public int AgregarEspecialidad(string especialidad,string descripcion)
        {           
            EspecialidadBE espe = new EspecialidadBE();
            espe.Especialidad = especialidad;
            espe.Descripcion = descripcion;
            return _repo.AgregarEspecialidad(espe);
        }

        public int ModificarEspecialidad(int id,string especialidad, string descripcion)
        {
            bool buscaid = listaespecialidades.Any(e => e.ID_Especialidad == id);
            if (!buscaid)
            {
                // El ID no existe, no se puede modificar
                return 0;
            }


            EspecialidadBE especialidadBE = new EspecialidadBE();
            especialidadBE.ID_Especialidad = id;
            especialidadBE.Especialidad = especialidad;
            especialidadBE.Descripcion = descripcion;
            return _repo.ModificarEspecialidad(especialidadBE);
        }

        public int EliminarEspecialidad(int id,string especialidad, string descripcion)
        {
            bool buscaid = listaespecialidades.Any(e => e.ID_Especialidad == id);
            if (!buscaid)
            {
                // El ID no existe, no se puede modificar
                return 0;
            }

            EspecialidadBE especialidadBE = new EspecialidadBE();
            especialidadBE.ID_Especialidad = id;
            especialidadBE.Especialidad = especialidad;
            especialidadBE.Descripcion = descripcion;
            return _repo.EliminarEspecialidad(especialidadBE);
        }

        public List<EspecialidadBE> ListarEspecialidades()
        {
            listaespecialidades = _repo.ObtenerTodas();
            return _repo.ObtenerTodas();
        }
        public EspecialidadBE BuscarPorNombre(string nombre)
        {
            return _repo.BuscarPorNombre(nombre);
        }
    }
}
