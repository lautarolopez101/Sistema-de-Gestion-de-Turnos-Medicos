using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class AppBootstrap
    {
        public static IPacienteService BuildPacienteService()
        {
            var repo = new PacienteRepository();
            var service = new PacienteService(repo);
            return service;
        }
    }
}
