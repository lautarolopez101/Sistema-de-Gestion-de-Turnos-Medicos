using BLL;
using Sistema_de_Gestion_de_Turnos_Medicos.ABM_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ITurnoService turnoservice = AppBootstrap.BuildTurnoService();
            IProfesional_EspecialidadService profesionalespecialidadservice = AppBootstrap.BuildProfesionalEspecialidadService();
            IPacienteService pacienteservice = AppBootstrap.BuildPacienteService();
            IEspecialidadService especialidadService = AppBootstrap.BuildEspecialidadService();
            IProfesionalService profesionalService = AppBootstrap.BuildProfesionalService();
            Application.Run(new FRMABMTurnos(turnoservice,pacienteservice,profesionalService));
        }
    }
}
