using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Profesional_EspecialidadService : IProfesional_EspecialidadService
    {
        private readonly IProfesionales_EspecialidadesRepository _profesional_especialidadrepository;
        public Profesional_EspecialidadService(IProfesionales_EspecialidadesRepository profesional_especialidadrepository)
        {
            _profesional_especialidadrepository = profesional_especialidadrepository;
        }
        public int AgregarProfesional_Especialidad(int idespecialidad, int idprofesional)
        {
            Profesionales_EspecialidadesBE nodo = new Profesionales_EspecialidadesBE();
            nodo.ID_Especialidad = idespecialidad;
            nodo.ID_Profesional = idprofesional;
            return _profesional_especialidadrepository.AgregarProfesionalesEspecialidades(nodo);
        }
        public int ModificarProfesional_Especialidad(int idespecialidad, int idprofesional)
        {

            Profesionales_EspecialidadesBE nodo = new Profesionales_EspecialidadesBE();
            nodo.ID_Especialidad = idespecialidad;
            nodo.ID_Profesional = idprofesional;
            return _profesional_especialidadrepository.ModificarProfesionalesEspecialidades(nodo);
        }
        public int EliminarProfesional_Especialidad(int idespecialidad, int idprofesional)
        {
            Profesionales_EspecialidadesBE nodo = new Profesionales_EspecialidadesBE();
            nodo.ID_Especialidad = idespecialidad;
            nodo.ID_Profesional = idprofesional;
            return _profesional_especialidadrepository.EliminarProfesionalesEspecialidades(nodo);
        }
        public List<Profesionales_EspecialidadesBE> ListarProfesionales_Especialidades()
        {
            // Solamente hacemos un pasamanos porque tenemos que traer toda la lista entera
            return _profesional_especialidadrepository.ObtenerTodos();
        }

        //Este metodo es para cuando eliminamos el profesional y necesitamos eliminar cualquier vinculo conectado con el 
        public int EliminarProfesional(int idprofesional)
        {
            return _profesional_especialidadrepository.EliminarProfesional(idprofesional);
        }

    }
}
