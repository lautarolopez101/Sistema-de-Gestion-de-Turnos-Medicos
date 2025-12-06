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
    public partial class TurnosAsignados : Form
    {
        private readonly ITurnoService _turnoservice;
        private readonly IPacienteService _pacienteservice;
        public TurnosAsignados(ITurnoService turnoService, IPacienteService pacienteservice)
        {
            InitializeComponent();
            // Redondeamos los paneles
            RedondearPanel(panelbtn, 20);
            RedondearPanel(paneldgv, 20);

            // Declaramos las interfaces
            _turnoservice = turnoService;
            _pacienteservice = pacienteservice;
        }

        private void TurnosAsignados_Load(object sender, EventArgs e)
        {
            Recargamos();
        }
        private void Recargamos()
        {
            // Aca usariamos la funcion para poder llamarla para mostrar y recargar el dgv 
            // La idea es mostrar los turnos en estado "Confirmado","Cancelado" y "Pendiente"

            // Tendriamos que usar un BLL que nos muestre directamente la lista 
            // Traemos la funcion ya hecha
            int idprofesional = AppSession.Profesional.ID_Profesional;
            var lista = _turnoservice.TurnosProfesional(idprofesional);


          
            

            var listafiltrada = from tun in lista
                                select new
                                {
                                    Motivo = tun.Motivo
                                };
                                

            dgvturnos.DataSource = lista;

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

        private void panelbtn_Click(object sender, EventArgs e)
        {
            // Aca tendriamos que obtener los datos que estan en el dgv para poder ir a otro form para atenderlo 

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Aca tenemos que tomar los datos necesarios para poder atender el turno seleccionado
            //  Tenemos que mostrar los siguentes datos => Nombre y Apellido del paciente, DNI, Fecha y Hora del turno, Motivo de consulta  



        }

      
    }
}
