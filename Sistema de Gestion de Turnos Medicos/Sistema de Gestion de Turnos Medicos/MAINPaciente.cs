using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class MAINPaciente : Form
    {
        public MAINPaciente()
        {
            InitializeComponent();
        }



        // Eventos de los botones de la ventana
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Eventos para mover la ventana
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);

        private void MAINPaciente_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            // Agrega un try...catch para que podamos ver cualquier error
            try
            {
                // Esta línea nos confirma que el clic funciona
                MessageBox.Show("1. Se detectó el clic. Cargando formulario...");

                // Aquí llamas a la función que te pasé
                CargarFormularioEnPanel(new Turnos());

                // Esta línea nos confirma que no hubo error al cargar
                MessageBox.Show("2. Formulario cargado.");
            }
            catch (Exception ex)
            {
                // Si algo falla, ESTO nos dirá qué es
                MessageBox.Show("¡ERROR! No se pudo cargar el formulario: \n\n" + ex.Message);
            }
        }

        // Esta función recibe cualquier formulario y lo carga en tu panel
        private void CargarFormularioEnPanel(Form formHijo)
        {
            // 1. Limpia el panel
            // Si ya hay un control (otro form) en el panel, lo quita
            if (this.panelmain.Controls.Count > 0)
                this.panelmain.Controls.RemoveAt(0);

            // 2. Configura el formulario hijo
            formHijo.TopLevel = false; // Le dice que no es una ventana de nivel superior
            formHijo.FormBorderStyle = FormBorderStyle.None; // Le quita el borde
            formHijo.Dock = DockStyle.Fill; // Hace que llene todo el panel

            // 3. Agrega el formulario hijo al panel
            this.panelmain.Controls.Add(formHijo);
            this.panelmain.Tag = formHijo;

            // 4. Muestra el formulario
            formHijo.Show();
        }
    }
}
