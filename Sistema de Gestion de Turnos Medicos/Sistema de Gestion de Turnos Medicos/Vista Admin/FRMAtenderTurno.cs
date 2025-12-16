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
    public partial class FRMAtenderTurno : Form
    {
        private readonly ITurnoService _turnoservice;
        private readonly IPacienteService _pacienteservice;

        private static int _idturno;
        public FRMAtenderTurno(int idturno,IPacienteService pacienteservice, ITurnoService turnoService)
        {
            InitializeComponent();
            RedondearPanel(panelAtendido, 20);
            RedondearPanel(panelCancelar, 20);
            RedondearPanel(panelObservacion, 20);
            RedondearPanel(panelInformacion, 20);
            _idturno = idturno;
            _pacienteservice = pacienteservice;
            _turnoservice = turnoService;
        }
        private void FRMAtenderTurno_Load(object sender, EventArgs e)
        {
            List<TurnoBE> listaturnos = _turnoservice.Verifico(_idturno);
            TurnoBE turno = listaturnos.FirstOrDefault();  

            List<PacienteBE> listapaciente = _pacienteservice.ObtenerPaciente(turno.ID_Paciente);
            PacienteBE Paciente = listapaciente.FirstOrDefault();

            lblnombre.Text = "Nombre: " + Paciente.Nombre;
            lblapellido.Text = "Apellido: " + Paciente.Apellido;
            lbldni.Text = "DNI: " + Paciente.DNI;
            lblemail.Text = "Email: " + Paciente.Email;
            lblmotivo.Text = "Motivo: " + turno.Motivo;
        }

        // Funcion para redondear los paneles
        // Para poder redondear los paneles necesitamos crear una funcion
        //  le damos como parametros el panel que queremos redondear y el radio de redondeo
        private void RedondearPanel(Panel pnl, int radio)
        {
            // Creamos una variable rectangulo que sera el area del panel
            var rect = pnl.ClientRectangle;
            // Inflamos el rectangulo para que no se vean los bordes cortados
            rect.Inflate(-1, -1);
            // Creamos un path para dibujar el panel redondeado
            using (GraphicsPath path = new GraphicsPath())
            {
                // Calculamos el diametro del arco
                int d = radio * 2;
                // Esquina superior izquierda
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                // Esquina superior derecha
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                // Esquina inferior derecha
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                // Esquina inferior izquierda
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                // Cerramos el path
                path.CloseFigure();
                // Asignamos el path al region del panel
                pnl.Region = new Region(path);
            }
            /*
             *  Lo que hicimos fue 
             *  1: Calcular el rectangulo interno del panel
             *  2: Lo achica un poco para que no se pegue a los bordes 
             *  3: Dibuja una figura con 4 curvas (una en cada esquina)
             *  4: Cierra esa figura
             *  5: Usa esa figura como molde para recortar el panel
             *  6: Resultado= el panel tiene esquinas redondeadas
             */
        }

        private void panelCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Atentidos
            if(string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show("Debe ingresar una observacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string observaciones = txtObservacion.Text;

            TurnoBE turno = _turnoservice.Verifico(_idturno).FirstOrDefault();

            int resultado = _turnoservice.ModificarTurno(turno.ID_Turno, turno.ID_Paciente, turno.ID_Profesional, "Atendido", turno.FechaHora, turno.Motivo, observaciones);

            if(resultado > 0)
            {
                MessageBox.Show("Turno atendido correctamente", "Atendido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error al atender el turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
    }
}
