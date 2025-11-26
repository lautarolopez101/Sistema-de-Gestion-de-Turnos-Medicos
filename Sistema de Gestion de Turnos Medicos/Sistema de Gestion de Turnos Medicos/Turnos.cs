using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BLL;
using BE; // Agregamos para poder modificar las propiedades de los bordes
          // de los paneles que estan detras de los DGV's

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Turnos : Form
    {
        private readonly IProfesionalService _profesionalservice;
        private readonly IEspecialidadService _especialidadservice;

        // Creamos esto para poder poner todos los profesionales "ACTIVOS"
        private bool cual = true;

        public Turnos(IProfesionalService profesionalservice,IEspecialidadService especialidadservice)
        {
            InitializeComponent();
            _profesionalservice = profesionalservice;
            _especialidadservice = especialidadservice;
            lbldni.Text = AppSession.Paciente.DNI;
            lblemail.Text = AppSession.Paciente.Email;
            lblnombre.Text = AppSession.Paciente.Nombre;
        }
        private void Turnos_Load(object sender, EventArgs e)
        {
            try
            {
                // Redondear los paneles detras de los DGV's
                RedondearPanel(panelespecialidades, 15);   // 15 = radio de la esquina
                RedondearPanel(panelprofesionales, 10);   // 10 = radio de la esquina
                RedondearPanel(panelcancelar, 10);   // 10 = radio de la esquina
                RedondearPanel(panelnuevoturno, 10);   // 10 = radio de la esquina

                // Aca tenemos que cargar las especialidades y tambien los profesionales
                dgvespecialidades.DataSource = _especialidadservice.ListarEspecialidades();
                dgvespecialidades.Columns["ID_Especialidad"].Visible = false; // Ocultamos la columna ID_Especialidad]

                dgvprofesionales.DataSource = _profesionalservice.ListarProfesionales(cual);
                dgvprofesionales.Columns["ID_Profesional"].Visible = false; // Ocultamos la columna ID_Profesional
                dgvprofesionales.Columns["Activo"].Visible = false; // Ocultamos la columna Activo
                dgvprofesionales.Columns["CreatedAtUtc"].Visible = false; // Ocultamos la columna CreatedAtUtc
                dgvprofesionales.Columns["UpdatedAtUtc"].Visible = false; // Ocultamos la columna UpdatedAtUtc
                dgvprofesionales.Columns["Matricula"].Visible = false; // Cambiamos el texto del encabezado de la columna Matricula
                dgvprofesionales.Columns["Telefono"].Visible= false; // Cambiamos el texto del encabezado de la columna Telefono   
                dgvprofesionales.Columns["Email"].Visible= false; // Cambiamos el texto del encabezado de la columna Email


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RedondearPanel(Panel pnl, int radio)
        {
            var rect = pnl.ClientRectangle;
            rect.Inflate(-1, -1);

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radio * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                pnl.Region = new Region(path);
            }
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvprofesionales_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvespecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
