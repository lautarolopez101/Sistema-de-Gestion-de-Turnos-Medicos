using BLL; // Agregado para poder mover el formulario
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
using System.Drawing.Drawing2D;
using System.CodeDom; // Agregamos para redondear los paneles 

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Register : Form
    {
        private readonly IUsuarioService _usuarioService;
        public Register(IUsuarioService usuarioservice)
        {
            InitializeComponent();
            _usuarioService = usuarioservice;
            RedondearPanel(panelregister, 20);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);
        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    string email = txtEmail.Text;
                    string user = txtUsername.Text;
                    string password = txtPassword.Text;

                    // Validacion que no ingrese el mismo correo u el mismo usuario
                    bool ExisteUser = _usuarioService.BuscarUsuario(user);
                    if (ExisteUser)
                        throw new Exception($"Hay un Usuario que tiene el mismo Nombre de Usuario: '{user}', asi que por favor cambielo a otro distinto o recupere el password");

                    bool ExisteEmail = _usuarioService.BuscarEmail(email);
                    if (ExisteEmail)
                        throw new Exception($"Hay un Usuario que tiene el mismo Email: '{email}', asi que por favor cambielo a otro distinto o recupere el password");
                    int retorna = _usuarioService.CrearUsuario(user, password, email);
                    if (retorna > 0)
                    {
                        MessageBox.Show("Creado Correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }




        // DESIGN

        // USERNAME
        bool moveupusername = false;
        bool movedownusername = false;
        private void timerusername_Tick(object sender, EventArgs e)
        {
            if(moveupusername  && lblUsername.Top > 0)
            {
                lblUsername.Top -= 2;
                if(lblUsername.Top <= 0)
                {
                    timerusername.Stop();
                    moveupusername = false;
                }
            }
            else if(movedownusername && lblUsername.Top < 12)
            {
                lblUsername.Top += 2;
                if(lblUsername.Top >= 12)
                {
                    timerusername.Stop();
                    movedownusername = false;
                }
            }
            {
                
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                moveupusername = true;
                movedownusername = false;
                timerusername.Start();
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                moveupusername = false;
                movedownusername = true;
                timerusername.Start();
            }
        }

        // PASSWORD
        bool moveuppassword = false;
        bool movedownpassword = false;
        private void timerpassword_Tick(object sender, EventArgs e)
        {
            if(moveuppassword && lblpassword.Top > 0)
            {
                lblpassword.Top -= 2;
                if(lblpassword.Top <= 0)
                {
                    timerpassword.Stop();
                    moveuppassword = false;
                }
            }
            else if(movedownpassword && lblpassword.Top < 12)
            {
                lblpassword.Top += 2;
                if(lblpassword.Top >= 12)
                {
                    timerpassword.Stop();
                    movedownpassword = false;
                }
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                moveuppassword = true;
                movedownpassword = false;
                timerpassword.Start();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                moveuppassword = false;
                movedownpassword = true;
                timerpassword.Start();
            }
        }


        // EMAIL
        bool moveupemail = false;
        bool movedownemail = false;
        private void timeremail_Tick(object sender, EventArgs e)
        {
            if(moveupemail && lblemail.Top > 0)
            {
                lblemail.Top -= 2;
                if(lblemail.Top <= 0)
                {
                    timeremail.Stop();
                    moveupemail = false;
                }
            }
            else if (movedownemail && lblemail.Top < 12)
            {
                lblemail.Top += 2;
                if(lblemail.Top >= 12)
                {
                    timeremail.Stop();
                    movedownemail = false;
                }
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                moveupemail = true;
                movedownemail = false;
                timeremail.Start();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                moveupemail = false;
                movedownemail = true;
                timeremail.Start();
            }
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
