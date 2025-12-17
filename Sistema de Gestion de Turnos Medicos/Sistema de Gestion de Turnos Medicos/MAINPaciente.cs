using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class MAINPaciente : Form
    {
        private readonly IProfesionalService _profesionalservice;
        private readonly IEspecialidadService _especialidadservice;
        private readonly ITurnoService _turnoservice;
        private readonly IUsuarioService _usuarioService;
        public MAINPaciente(IProfesionalService profesionalservice, IEspecialidadService especialidadService, ITurnoService turnoservice, IUsuarioService usuarioService)
        {
            InitializeComponent();
            _profesionalservice = profesionalservice;
            _especialidadservice = especialidadService;
            _usuarioService = usuarioService;
            _turnoservice = turnoservice;
            PacienteBE paciente = AppSession.Paciente;
            lblusuario.Text = "Bienvenido, " + AppSession.Paciente.Nombre + " " + AppSession.Paciente.Apellido;
        }
        private void MAINPaciente_Load(object sender, EventArgs e)
        {
            RedondearPanel(panel3, 15);
            RedondearPanel(panel4, 15);
            RedondearPanel(panel5, 15);
            RedondearPanel(panel6, 15);
            RedondearPanel(panel7, 15);
            RedondearPanel(panel8, 15);

        }


        // Eventos de los botones de la ventana
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            AppSession.Usuario.LastLogin = DateTime.Now;
            int retorna = _usuarioService.Logout(AppSession.Usuario);
            AppSession.Logout();
            // Carpeta simple y con permisos (evitá Program Files)
            string carpeta = @"D:\SQLBackups";

            bool hizo = BLL.BackupService.AsegurarBackupDiario(
                "Sistema de Gestion de Turnos Medicos",
                carpeta
            );

            if (hizo)
                MessageBox.Show("✅ Backup diario generado.");
            Close();
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


        // Evento para el sidebar
        private void imagenlogo_Click(object sender, EventArgs e)
        {
            sidebartransition.Start();
        }
        bool sidebarExpandido = true;
        private void sidebartimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpandido)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == 59)
                {
                    sidebarExpandido = false;
                    sidebartransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == 188)
                {
                    sidebarExpandido = true;
                    sidebartransition.Stop();
                }
            }
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



        private Panel _panelActivo;

        // Colores (ajustalos a tu paleta)
        private Color _colorNormal = Color.FromArgb(48, 74, 111);       // fondo menú normal
        private Color _colorSeleccionado = Color.FromArgb(73, 99, 136); // fondo menú seleccionado en teoria tiene que ser mas claro que el original para que se identifique en cual esta
        private Color _textoNormal = Color.White;
        private Color _textoSeleccionado = Color.White;  // o un celestito si querés

        private void ActivarPanel(Panel panel)
        {
            // 1) Resetear el panel anterior
            if (_panelActivo != null)
            {
                _panelActivo.BackColor = _colorNormal;

                foreach (Label lbl in _panelActivo.Controls.OfType<Label>())
                    lbl.ForeColor = _textoNormal;
            }

            // 2) Activar el nuevo
            _panelActivo = panel;
            _panelActivo.BackColor = _colorSeleccionado;

            foreach (Label lbl in _panelActivo.Controls.OfType<Label>())
                lbl.ForeColor = _textoSeleccionado;
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







        private void Turnos_Click(object sender, EventArgs e)
        {
            // Agrega un try...catch para que podamos ver cualquier error
            try
            {
                // Aquí llamas a la función que te pasé
                ActivarPanel(panel3);   // cambia color del menú
                CargarFormularioEnPanel(new Turnos(_profesionalservice, _especialidadservice, _turnoservice));
            }
            catch (Exception ex)
            {
                // Si algo falla, ESTO nos dirá qué es
                MessageBox.Show("¡ERROR! No se pudo cargar el formulario: \n\n" + ex.Message);
            }
        }
        private void MisTurnos_Click(object sender, EventArgs e)
        {
            // Agrega un try...catch para que podamos ver cualquier error
            try
            {
                // Aquí llamas a la función que te pasé
                ActivarPanel(panel5);   // cambia color del menú
                // Aquí llamas a la función que te pasé
                CargarFormularioEnPanel(new MisTurnos(_turnoservice));
            }
            catch (Exception ex)
            {
                // Si algo falla, ESTO nos dirá qué es
                MessageBox.Show("¡ERROR! No se pudo cargar el formulario: \n\n" + ex.Message);
            }
        }
        private void Historial_Click(object sender, EventArgs e)
        {
            // Agrega un try...catch para que podamos ver cualquier error
            try
            {                // Aquí llamas a la función que te pasé
                ActivarPanel(panel4);   // cambia color del menú
                // Aquí llamas a la función que te pasé
                CargarFormularioEnPanel(new Historial(_turnoservice));
            }
            catch (Exception ex)
            {
                // Si algo falla, ESTO nos dirá qué es
                MessageBox.Show("¡ERROR! No se pudo cargar el formulario: \n\n" + ex.Message);
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            AppSession.Usuario.LastLogin = DateTime.Now;
            int retorna = _usuarioService.Logout(AppSession.Usuario);
            AppSession.Logout();
            // Carpeta simple y con permisos (evitá Program Files)
            string carpeta = @"D:\SQLBackups";

            bool hizo = BLL.BackupService.AsegurarBackupDiario(
                "Sistema de Gestion de Turnos Medicos",
                carpeta
            );

            if (hizo)
                MessageBox.Show("✅ Backup diario generado.");
            Close();
        }

        private void CambiarPerfil_Click(object sender, EventArgs e)
        {

        }

        private void Perfil_Click(object sender, EventArgs e)
        {
            // Agrega un try...catch para que podamos ver cualquier error
            try
            {                // Aquí llamas a la función que te pasé
                ActivarPanel(panel7);   // cambia color del menú
                // Aquí llamas a la función que te pasé
                CargarFormularioEnPanel(new Perfil());
            }
            catch (Exception ex)
            {
                // Si algo falla, ESTO nos dirá qué es
                MessageBox.Show("¡ERROR! No se pudo cargar el formulario: \n\n" + ex.Message);
            }
        }

       
    }
}
