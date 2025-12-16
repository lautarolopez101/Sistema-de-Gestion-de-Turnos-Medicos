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
    public partial class FRMElegirProfesional : Form
    {
        private readonly IProfesionalService _profesionalservice;
        private readonly IUsuarioService _usuarioservice;

        private static int _idusuario;
        private static int _idprofesional;

        public FRMElegirProfesional(IProfesionalService profesionalservice, IUsuarioService usuarioservice, int idusuario)
        {
            InitializeComponent();
            RedondearPanel(panel1, 20);
            RedondearPanel(panel2, 20);
            RedondearPanel(panel3, 20);
            
            _idusuario = idusuario;

            _usuarioservice = usuarioservice;
            _profesionalservice = profesionalservice;
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

        private void Recargamos()
        {
            // la idea aca seria que muestre a todos los profesionales y luego verificamos si ese estan vinculado con algun usuario
            List<ProfesionalBE> lista = _profesionalservice.ObtenerProfesionales();

            dataGridView1.DataSource = lista;
        }


        private void FRMElegirProfesional_Load(object sender, EventArgs e)
        {
            // aca cargamos a todos los profesionales que no tienen ninguna vinculacion
            // entonces tendriamos que hacer una forma en la bll para que muestre los profesionales que no tienen usuario
            Recargamos();
        }

        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            _idprofesional = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_Profesional"].Value.ToString());
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            // Usamos para cancelar la operacion
            Close();
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            // Usamos para confirmar la operacion
            // con el id del usuario buscamos el id profesional para poder 

            int retorna = _usuarioservice.AgregarIDProfesional(_idusuario,_idprofesional);
            if(retorna > 0)
            {
                MessageBox.Show($"Hemos Agregado el Profesional {_idprofesional}, con el usuario {_idusuario}");
            }
            else
            {
                MessageBox.Show("No pudimos agregarlo por algun motivo.");
            }
            Close();
        }
    }
}
