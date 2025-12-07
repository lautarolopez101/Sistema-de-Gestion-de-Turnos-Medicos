using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProfesionalService : IProfesionalService
    {
        // Profesionales
        private readonly IProfesionalRepository _profesional;
        private static List<ProfesionalBE> listaprofesionales = new List<ProfesionalBE>();

        // Especialidades 
        private readonly IEspecialidadRepository _especialidadrepository;
        private static List<EspecialidadBE> listaespecialidades = new List<EspecialidadBE>();

        // Profesionales Especialidades 
        private readonly IProfesionales_EspecialidadesRepository _profesionales_EspecialidadesRepository;
        private static List<Profesionales_EspecialidadesBE> listaprofesionalesespecialidades = new List<Profesionales_EspecialidadesBE>();

        public ProfesionalService(IProfesionalRepository profesional,IEspecialidadRepository especialidad ,IProfesionales_EspecialidadesRepository profesionales_Especialidades)
        {
            _profesional = profesional;
            _especialidadrepository = especialidad;
            _profesionales_EspecialidadesRepository = profesionales_Especialidades;
        }
        public int AgregarProfesional(string matricula, string nombre, string apellido, string telefono, string email)
        {
            ProfesionalBE profesional = new ProfesionalBE();
            profesional.Matricula = matricula;
            profesional.Nombre = nombre;
            profesional.Apellido = apellido;
            profesional.Telefono = telefono;
            profesional.Email = email; 
            return _profesional.AgregarProfesional(profesional);
        }
        public int EliminarProfesional(int id,bool activo)
        {
            ProfesionalBE profesional = new ProfesionalBE();
            profesional.ID_Profesional = id;
            activo = false;
            profesional.Activo = activo;
            return _profesional.EliminarProfesional(profesional);
        }
        public int ModificarProfesional(int id,string matricula, string nombre, string apellido, string telefono, string email,bool activo)
        {
            ProfesionalBE profesional = new ProfesionalBE();
            profesional.ID_Profesional = id;
            profesional.Matricula = matricula;
            profesional.Nombre = nombre;
            profesional.Apellido = apellido;
            profesional.Telefono = telefono;
            profesional.Email = email;
            profesional.Activo = activo;
            return _profesional.ModificarProfesional(profesional);
        }
        public List<ProfesionalBE> ListarProfesionales(bool cual)
        {
            listaprofesionales = _profesional.ListarProfesionales(cual);
            return listaprofesionales;
        }
        public List<ProfesionalBE> ObtenerProfesional(int idprofesional)
        {
            ProfesionalBE profesional = _profesional.ObtenerProfesional(idprofesional);
            List<ProfesionalBE> lista = new List<ProfesionalBE>();  
            lista.Add(profesional);
            return lista;
        }
        public ProfesionalBE ObtenerProfesionalPorMatricula(string Matricula)
        {
            ProfesionalBE profesional = _profesional.ObtenerProfesionalPorMatricula(Matricula);
            return profesional;
        }
        public List<ProfesionalBE> ObtenerProfesionales()
        {
            listaprofesionales = _profesional.ObtenerProfesionales();
            return listaprofesionales;
        }
        public List<EspecialidadBE> ListarEspecialidadesdelProfesional(int idprofesional)
        {
            var listaprofesionales_especialidades = _profesionales_EspecialidadesRepository.ObtenerTodos()
                .Where(x => x.ID_Profesional == idprofesional)
                .Select(x => x.ID_Especialidad)
                .ToList();
            List<EspecialidadBE> listaespecialidades = _especialidadrepository.ObtenerTodas();

           List<EspecialidadBE> listafinal = listaespecialidades
                .Where(todo => listaprofesionales_especialidades.Contains(todo.ID_Especialidad))
                .OrderBy(todo => todo.Especialidad)
                .ToList();

            return listafinal;
        }
        public List<ProfesionalBE> ListarProfesionalesDesdeEspecialidades(int idespecialidad)
        {
            var listaprofesionales_especialidades = _profesionales_EspecialidadesRepository.ObtenerTodos()
                .Where(x => x.ID_Especialidad == idespecialidad)
                .Select(x => x.ID_Profesional)
                .ToList();
            List<ProfesionalBE> listaprofesionales = _profesional.ListarProfesionales(true);

            List<ProfesionalBE> listafinal = listaprofesionales
                 .Where(todo => listaprofesionales_especialidades.Contains(todo.ID_Profesional))
                 .OrderBy(todo => todo.Nombre)
                 .ToList();

            return listafinal;
        }

        public int AgregarEspecialidadAlProfesionalPorNombre(string nombre,int idprofesional)
        {
            // Primero traemos el objeto de especialidad por su nombre
            EspecialidadBE especialidad = _especialidadrepository.BuscarPorNombre(nombre);
            // Creamos el objeto de Profesionales_EspecialidadesBE
            Profesionales_EspecialidadesBE profesional_Especialidades = new Profesionales_EspecialidadesBE();
            // Asignamos los valores correspondientes al objeto creado
            profesional_Especialidades.ID_Especialidad = especialidad.ID_Especialidad;
            profesional_Especialidades.ID_Profesional = idprofesional;

            // Ahora hacemos una validacion que si ya esta asignada la especialidad al profesional no se pueda agregar otra vez
            List<Profesionales_EspecialidadesBE> lista = _profesionales_EspecialidadesRepository.ObtenerTodos();
            Profesionales_EspecialidadesBE buscamos = lista
                            .FirstOrDefault(x => x.ID_Especialidad == profesional_Especialidades.ID_Especialidad && x.ID_Profesional == profesional_Especialidades.ID_Profesional);
            if(buscamos != null)
                throw new ValidationException("La especialidad ya se encuentra asignada al profesional.");


            // Ahora agregamos uno la relacion en la tabla de Profesionales_Especialidades
            return _profesionales_EspecialidadesRepository.AgregarProfesionalesEspecialidades(profesional_Especialidades);


        }
        public int QuitarEspecialidadAlProfesionalPorNombre(string nombre, int idprofesional)
        {
            // Primero traemos el objeto de especialidad por su nombre
            EspecialidadBE especialidad = _especialidadrepository.BuscarPorNombre(nombre);
            // Creamos el objeto de Profesionales_EspecialidadesBE
            Profesionales_EspecialidadesBE profesional_Especialidades = new Profesionales_EspecialidadesBE();
            // Aca usamos una funcion que tenemos en el repositorio del objeto tal y le hacemos un LinQ que traiga al primero que coincida con el idespecialidad y el idprofesional
            Profesionales_EspecialidadesBE objetoencontrado = _profesionales_EspecialidadesRepository
                                                                .ObtenerTodos()
                                                                .FirstOrDefault(x => x.ID_Especialidad == especialidad.ID_Especialidad && x.ID_Profesional == idprofesional);
            // ahora usamos otra funcion y le damos el objeto entero
            int retornamos = _profesionales_EspecialidadesRepository.EliminarProfesionalesEspecialidades(objetoencontrado);

            return retornamos;
        }
    }
}
