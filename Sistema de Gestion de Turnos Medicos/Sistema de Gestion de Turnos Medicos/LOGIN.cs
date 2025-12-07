using BE; // Libreria para poder arrastar con el mouse la ventana
using BLL;
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
using System.Drawing.Drawing2D; // Agregamoso la libreria para hacer los bordes redondos

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class LOGIN : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPacienteService _pacienteservice;
        private readonly IProfesionalService _profesionalservice;
        private readonly IEspecialidadService _especialidadService;
        private readonly ITurnoService _turnoservice;
        private readonly IProfesional_EspecialidadService _profesional_EspecialidadService;

        public static UsuarioBE _usuario = new UsuarioBE();
        public LOGIN(IUsuarioService usuario, IPacienteService paciente, IProfesionalService profesionalservice, IEspecialidadService especialidadService, ITurnoService turnoservice, IProfesional_EspecialidadService profesionalespecialidad)
        {
            InitializeComponent();

            RedondearPanel(panellogin, 20);

            _usuarioService = usuario;
            _pacienteservice = paciente;
            _profesionalservice = profesionalservice;
            _especialidadService = especialidadService;
            _turnoservice = turnoservice;
            _profesional_EspecialidadService = profesionalespecialidad;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);

        private void LOGIN_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      



        // DESIGN 


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



        bool movingUpUsername = false;
        bool movingDownUsername = false;

        bool movingUpPassword = false;
        bool movingDownPassword = false;

        // USERNAME
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                movingUpUsername = true;
                movingDownUsername = false;
                aintTimer.Start();
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                movingUpUsername = false;
                movingDownUsername = true;
                aintTimer.Start();
            }
        }

        private void lblusername_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void aintTimer_Tick(object sender, EventArgs e)
        {
            if (movingUpUsername && lblusername.Top > 0)
            {
                lblusername.Top -= 2;
                if (lblusername.Top <= 0)
                {
                    aintTimer.Stop();
                    movingUpUsername = false;
                }
            }
            else if (movingDownUsername && lblusername.Top < 12)
            {
                lblusername.Top += 2;
                if (lblusername.Top >= 12)
                {
                    aintTimer.Stop();
                    movingDownUsername = false;
                }
            }
        }


        // PASSWORD
        private void lblPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (movingUpPassword && lblPassword.Top > 0)
            {
                lblPassword.Top -= 2;
                if (lblPassword.Top <= 0)
                {
                    Timer.Stop();
                    movingUpPassword= false;
                }
            }
            else if (movingDownPassword && lblPassword.Top < 12)
            {
                lblPassword.Top += 2;
                if (lblPassword.Top >= 12)
                {
                    Timer.Stop();
                    movingDownPassword= false;
                }
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                movingUpPassword = true;
                movingDownPassword = false;
                Timer.Start();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                movingUpPassword = false;
                movingDownPassword = true;
                Timer.Start();
            }
        }





        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Register win = new Register(_usuarioService);
                win.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }

        private void btnForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // un form especial para recuperar la contrasenia?
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // mi idea seria que le ingresamos los datos y si coinciden entonces hago una validacion y ahi ingresamos al form de paciente o para completar
                string username = txtUsername.Text;
                string password = txtPassword.Text;
 

                if(username == "admin" && password == "admin123")
                {
                    // FORM ADMIN
                    MainAdmin formadmin = new MainAdmin(_usuarioService,_turnoservice,_pacienteservice,_especialidadService,_profesionalservice,_profesional_EspecialidadService);
                    formadmin.ShowDialog();
                    txtPassword.Clear();
                    txtUsername.Clear();
                    txtUsername.Focus();
                    return;
                }


                UsuarioBE usuario = _usuarioService.ObtenerUsuario(username, password);

                // Vemos si pudo pasar la verificacion de la password 
                if (usuario == null)
                    throw new ValidationException("No se pudo Ingresar con este Usuario.");
               

                // Validamos para tener acceso completo al usuario para vincularlo ya sea con el paciente o el profesional
                _usuario = usuario;

                // tendriamos que hacer una validacion para saber si tiene o no un vinculo con paciente o profesional
                int paciente = usuario.ID_Paciente;
                int profesional = usuario.ID_Profesional;

                // Si los id's tienen  0, osea no existe entonces me salta para seguir completando y crear el paciente "TAL"
                if (profesional == 0 && paciente == 0)
                {
                    // entonces nos abrira un form para poder completar los datos faltantes
                    Complete completar = new Complete(_pacienteservice, _usuarioService, _profesionalservice, _especialidadService, _turnoservice);
                    completar.ShowDialog();
                }
                // y si ya tiene entonces me salta en el main
                else if (profesional > 0 || paciente > 0)
                {
                    if (profesional > 0)
                    {
                        // Lo que hacemos aca es poder permanecer logueado al usuario
                        AppSession.Login(usuario.ID, usuario.Username, usuario.ID_Paciente, usuario.ID_Profesional);
                        AppSession.Profesional = _usuarioService.GetByIDProfesional(usuario.ID);
                        AppSession.Usuario = usuario;
                        // FORM Profesional
                        MainProfesional formprofesional = new MainProfesional(_usuarioService,_turnoservice,_pacienteservice,_especialidadService,_profesionalservice);
                        formprofesional.ShowDialog();
                    }
                    else if (paciente > 0)
                    {
                        // Lo que hacemos aca es poder permanecer logueado al usuario
                        AppSession.Login(usuario.ID, usuario.Username, usuario.ID_Paciente, usuario.ID_Profesional);
                        AppSession.Paciente = _usuarioService.GetByIDPaciente(usuario.ID);
                        AppSession.Usuario = usuario;
                        // FORM Paciente
                        MAINPaciente formpaciente = new MAINPaciente(_profesionalservice, _especialidadService, _turnoservice, _usuarioService);
                        formpaciente.ShowDialog();
                    }
                    // iremos directo dependiendo si es un paciente o un profesional a la vista main
                }
                txtPassword.Clear();
                txtUsername.Clear();
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }

    }
}
