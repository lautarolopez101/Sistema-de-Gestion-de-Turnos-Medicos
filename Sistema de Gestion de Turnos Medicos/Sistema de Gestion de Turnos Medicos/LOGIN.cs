using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BLL;
using BE; // Libreria para poder arrastar con el mouse la ventana

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class LOGIN : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPacienteService _paciente;


        public static UsuarioBE _usuario = new UsuarioBE();
        public LOGIN(IUsuarioService usuario, IPacienteService paciente)
        {
            InitializeComponent();
            _usuarioService = usuario;
            _paciente = paciente;
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

        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Register win = new Register(_usuarioService);
                win.ShowDialog();
            }
            catch(Exception ex)
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

                UsuarioBE usuario = new UsuarioBE();

                usuario = _usuarioService.ObtenerUsuario(username,password);

                // Validamos para tener acceso completo al usuario para vincularlo ya sea con el paciente o el profesional
                _usuario = usuario;

                // tendriamos que hacer una validacion para saber si tiene o no un vinculo con paciente o profesional
                int paciente = usuario.ID_Paciente;
                int profesional = usuario.ID_Profesional;

                // Si los id's tienen  0, osea no existe entonces me salta para seguir completando y crear el paciente "TAL"
                if(profesional == 0 || paciente == 0)
                {
                    // entonces nos abrira un form para poder completar los datos faltantes
                    Complete completar = new Complete(_paciente,_usuarioService);
                    completar.ShowDialog();
                }
                // y si ya tiene entonces me salta en el main
                else if(profesional > 0 || paciente > 0)
                {
                    MessageBox.Show("MAIN");
                    if(profesional > 0)
                    {
                        // FORM Profesional
                    }
                    else if (paciente > 0)
                    {
                        // FORM Paciente
                    }
                    // iremos directo dependiendo si es un paciente o un profesional a la vista main
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }




        // DESIGN 
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
    }
}
