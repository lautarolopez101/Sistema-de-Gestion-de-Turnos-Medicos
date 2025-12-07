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
    public partial class HistorialProfesional : Form
    {
        private readonly int _idprofesional;
        private readonly ITurnoService _turnoservice;
        public HistorialProfesional(ITurnoService turnoService)
        {
            InitializeComponent();
            _turnoservice = turnoService;
            RedondearPanel(panelhistorial, 20);
            _idprofesional = AppSession.Profesional.ID_Profesional;
        }
        // Lo que tendriamos que hacer aca serian los turnos atendidos, y que se ordenen por nombre del paciente 

        private void HistorialProfesional_Load(object sender, EventArgs e)
        {
            Recargamos();
        }
        private void Recargamos()
        {
            List<TurnoBE> lista = _turnoservice.HistorialPorProfesional(_idprofesional);
            var nuevalista = from n in lista
                             select new
                             {
                                 Nombre = n.Paciente.Nombre,
                                 Apellido = n.Paciente.Apellido,
                                 DNI = n.Paciente.DNI,
                                 Motivo = n.Motivo,
                                 Fecha = n.FechaHora,
                                 Estado = n.Estado,
                                 Observacion = n.Observaciones
                             };
            dgvhistorial.DataSource = nuevalista.ToList();
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
        private void dgvhistorial_SelectionChanged(object sender, EventArgs e)
        {

            

        }



    }
}
