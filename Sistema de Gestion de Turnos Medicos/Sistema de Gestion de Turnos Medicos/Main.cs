using BLL;
using Sistema_de_Gestion_de_Turnos_Medicos.ABM_s;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Main : Form
    {
        private readonly IPacienteService pacienteservice;
        private readonly IProfesionalService profesionalService;
        private readonly IProfesional_EspecialidadService profesionalEspecialidadService;
        private readonly ITurnoService turnoService;
        private readonly IEspecialidadService especialidadService;
        public Main(IProfesionalService profesionalService, IProfesional_EspecialidadService profesionalEspecialidadService, ITurnoService turnoService, IEspecialidadService especialidadService,IPacienteService pacienteService)
        {
            InitializeComponent();
            this.profesionalService = profesionalService;
            this.profesionalEspecialidadService = profesionalEspecialidadService;
            this.turnoService = turnoService;
            this.especialidadService = especialidadService;
            this.pacienteservice = pacienteService;

            this.IsMdiContainer = true;
            

        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FRMABMTurnos turnos = new FRMABMTurnos(turnoService,pacienteservice,profesionalService);
                turnos.MdiParent = this;
                turnos.TopLevel = false;
                turnos.FormBorderStyle = FormBorderStyle.None;
                turnos.Dock = DockStyle.Fill;
                turnos.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FRMABMPacientes pacientes = new FRMABMPacientes(pacienteservice);
                pacientes.MdiParent = this;
                pacientes.TopLevel = false;
                pacientes.FormBorderStyle = FormBorderStyle.None;
                pacientes.Dock = DockStyle.Fill;
                pacientes.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FRMABMEspecialidades especialidades = new FRMABMEspecialidades(especialidadService);
                especialidades.MdiParent = this;
                especialidades.TopLevel = false;
                especialidades.FormBorderStyle = FormBorderStyle.None;
                especialidades.Dock = DockStyle.Fill;
                especialidades.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void profesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FRMABMProfesionales profesionales = new FRMABMProfesionales(profesionalService, especialidadService, profesionalEspecialidadService);
                profesionales.MdiParent = this;
                profesionales.TopLevel = false;
                profesionales.Dock = DockStyle.Fill;
                profesionales.FormBorderStyle = FormBorderStyle.None;
                profesionales.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
