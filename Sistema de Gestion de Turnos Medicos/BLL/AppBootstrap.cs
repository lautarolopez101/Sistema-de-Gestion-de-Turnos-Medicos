using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class AppBootstrap
    {
        public static IProfesional_EspecialidadService BuildProfesionalEspecialidadService()
        {
            var repo = new Profesionales_EspecialidadesRepository();
            var service = new Profesional_EspecialidadService(repo);
            return service;
        }
        public static IPacienteService BuildPacienteService()
        {
            var repo = new PacienteRepository();
            var service = new PacienteService(repo);
            return service;
        }
        public static IProfesionalService BuildProfesionalService()
        {
            var profesionalrepository = new ProfesionalRepository();
            var especialidadrepository  = new EspecialidadRepository();
            var profesional_especialidadrespository = new Profesionales_EspecialidadesRepository();
            var service = new ProfesionalService(profesionalrepository,especialidadrepository,profesional_especialidadrespository);
            return service;
        }

        public static IEspecialidadService BuildEspecialidadService()
        {
            var repo = new EspecialidadRepository();
            var service = new EspecialidadService(repo);
            return service;
        }
    }
}
