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
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
            RedondearPanel(panelinformacion, 20);
            RedondearPanel(paneleditar, 20);
            RedondearPanel(panelusuario, 20);
        }
        private void Perfil_Load(object sender, EventArgs e)
        {

            // Tenemos que hacer aca para que cargue los datos del paciente o del profesional
            if(AppSession.Paciente == null)
            {
                lblApellido.Text = AppSession.Profesional.Apellido;
                lblNombre.Text = AppSession.Profesional.Nombre;
                lblmatricula.Text = "Matricula: " + AppSession.Profesional.Matricula.ToString();
                lblDni.Hide(); // Los profesionales no tienen DNI en este sistema
                lblTelefono.Text = AppSession.Profesional.Telefono;
                lblEmail.Text = AppSession.Profesional.Email;
                lblnacimiento.Hide(); // Los profesionales no tienen fecha de nacimiento en este sistema
                lblFecha.Hide(); // Los profesionales no tienen fecha de nacimiento en este sistema
            }
            else if(AppSession.Profesional == null)
            {
                lblApellido.Text = AppSession.Paciente.Apellido;
                lblNombre.Text = AppSession.Paciente.Nombre;
                lblDni.Text = AppSession.Paciente.DNI.ToString();
                lblTelefono.Text = AppSession.Paciente.Telefono;
                lblEmail.Text = AppSession.Paciente.Email;
                lblFecha.Text = AppSession.Paciente.FechaNacimiento.ToShortDateString();
            }
            lblLastLogin.Text = AppSession.Usuario.LastLogin.ToString();
            lblusuario.Text = AppSession.Usuario.Username;
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

        private void Editar_Click(object sender, EventArgs e)
        {

        }
    }
}
