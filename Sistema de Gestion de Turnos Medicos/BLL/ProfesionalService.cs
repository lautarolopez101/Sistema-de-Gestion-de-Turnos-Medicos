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
        private readonly IProfesionalRepository _repo;
        private static List<ProfesionalBE> listaprofesionales = new List<ProfesionalBE>();

        // Especialidades 
        private readonly IEspecialidadRepository _especialidadrepository;
        private static List<EspecialidadBE> listaespecialidades = new List<EspecialidadBE>();

        // Profesionales Especialidades 
        private readonly IProfesionales_EspecialidadesRepository _profesionales_EspecialidadesRepository;
        private static List<Profesionales_EspecialidadesBE> listaprofesionalesespecialidades = new List<Profesionales_EspecialidadesBE>();

        public ProfesionalService(IProfesionalRepository repo)
        {
            _repo = repo;
        }
        public int AgregarProfesional(string matricula, string nombre, string apellido, string telefono, string email)
        {
            ProfesionalBE profesional = new ProfesionalBE();
            profesional.Matricula = matricula;
            profesional.Nombre = nombre;
            profesional.Apellido = apellido;
            profesional.Telefono = telefono;
            profesional.Email = email; 
            return _repo.AgregarProfesional(profesional);
        }
        public int EliminarProfesional(int id,bool activo)
        {
            ProfesionalBE profesional = new ProfesionalBE();
            profesional.ID_Profesional = id;
            activo = false;
            profesional.Activo = activo;
            return _repo.EliminarProfesional(profesional);
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
            return _repo.ModificarProfesional(profesional);
        }
        public List<ProfesionalBE> ListarProfesionales(bool cual)
        {
            listaprofesionales = _repo.ListarProfesionales(cual);
            return listaprofesionales;
        }
        public List<EspecialidadBE> ListarEspecialidadesdelProfesional(int idprofesional)
        {
            var conector = _profesionales_EspecialidadesRepository.ObtenerTodos()
                .Where(x => x.ID_Profesional == idprofesional)
                .Select(x => x.ID_Especialidad)
                .ToList();
            var todos = _especialidadrepository.ObtenerTodas();

            var resultado = todos
                .Where(todo => conector.Contains(todo.ID_Especialidad))
                .OrderBy(todo => todo.Especialidad)
                .ToList();

            return resultado;

         //   listaespecialidades = _especialidadrepository.ObtenerTodas();
            
           // return listaespecialidades;
        }
    }
}
