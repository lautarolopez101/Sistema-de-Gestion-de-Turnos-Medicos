using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Historial : Form
    {
        private readonly ITurnoService _turnoService;
        public Historial(ITurnoService turnoService)
        {
            InitializeComponent();
            _turnoService = turnoService;
        }
        private void Historial_Load(object sender, EventArgs e)
        {
            RedondearPanel(panelHistorial,20);  // Redondeamos el panel del historial para que se vea mas lindo 

            // La idea es mostrar solamente el historial de atendidos y cancelados del paciente que inicio sesion
            // para ello primero tenemos que saber a que paciente tenemos que darle esas indicaciones, 
            // por eso traeremos de la AppSession el ID_Paciente

            int idpaciente = AppSession.Paciente.ID_Paciente;
            string estado1 = "Atendido";
            string estado2 = "Cancelado";

            List<TurnoBE> listaturnos = _turnoService.FiltrarPacienteHistorial(idpaciente, estado1, estado2);

            var turnosmostrar = from turn in listaturnos
                                       select new
                                       {
                                           NombreProfesional = turn.NombreProfesional,
                                           ApellidoProfesional = turn.ApellidoProfesional,
                                           Estado = turn.Estado,
                                           Motivo = turn.Motivo,
                                           Observaciones = turn.Observaciones,
                                           Fecha = turn.FechaHora
                                       };



            dgvHistorial.DataSource = turnosmostrar.ToList();


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

        
    }
}
