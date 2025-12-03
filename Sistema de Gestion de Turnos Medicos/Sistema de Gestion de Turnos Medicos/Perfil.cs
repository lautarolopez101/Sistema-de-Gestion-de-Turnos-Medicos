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
            lblApellido.Text = AppSession.Paciente.Apellido;
            lblNombre.Text = AppSession.Paciente.Nombre;
            lblDni.Text = AppSession.Paciente.DNI.ToString();
            lblTelefono.Text = AppSession.Paciente.Telefono;
            lblEmail.Text = AppSession.Paciente.Email;
            lblFecha.Text = AppSession.Paciente.FechaNacimiento.ToShortDateString();
            lblLastLogin.Text = AppSession.Usuario.LastLogin.ToString();
            lblusuario.Text = AppSession.Usuario.Username;
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

        private void Editar_Click(object sender, EventArgs e)
        {

        }
    }
}
