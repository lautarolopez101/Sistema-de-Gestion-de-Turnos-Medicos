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
using BLL; // Agregado para poder mover el formulario

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Register : Form
    {
        private readonly IUsuarioService _usuarioService;
        public Register(IUsuarioService usuarioservice)
        {
            InitializeComponent();
            _usuarioService = usuarioservice;
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
                if(!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    string email = txtEmail.Text;
                    string user = txtUsername.Text;
                    string password = txtPassword.Text;

                    // Validacion que no ingrese el mismo correo u el mismo usuario
                    bool ExisteUser = _usuarioService.BuscarUsuario(user);
                    if (ExisteUser)
                    {
                        MessageBox.Show($"Hay un Usuario que tiene el mismo Nombre de Usuario: '{user}', asi que por favor cambielo a otro distinto o recupere el password","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    bool ExisteEmail = _usuarioService.BuscarEmail(email);
                    if(ExisteEmail)
                    {
                        MessageBox.Show($"Hay un Email que tiene el mismo Email de Usuario: '{email}', asi que por favor cambielo a otro distinto o recupere el password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int retorna = _usuarioService.CrearUsuario(user, password, email);
                    if( retorna > 0 )
                    {
                        MessageBox.Show("Creado Correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear el usuario");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }
    }
}
