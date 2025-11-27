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
using BE;
using BLL;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Complete : Form
    {
        private readonly IPacienteService _pacienteservice;
        private readonly IUsuarioService _usuarioservice;
        private readonly IProfesionalService _profesionalservice;
        private readonly IEspecialidadService _especialidadservice;
        private readonly ITurnoService _turnoservice;
        public Complete(IPacienteService pacienteservice,IUsuarioService usuarioService, IProfesionalService profesionalservice, IEspecialidadService especialidadservice, ITurnoService turnoservice)
        {
            InitializeComponent();
            _pacienteservice = pacienteservice;
            _usuarioservice = usuarioService;
            _profesionalservice = profesionalservice;
            _especialidadservice = especialidadservice;
            _turnoservice = turnoservice;
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);
        private void Complete_MouseDown(object sender, MouseEventArgs e)
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

        // boton completar datos para poder crear el paciente
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(!string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text))
                {
                    string apellido = txtApellido.Text;
                    string nombre = txtNombre.Text;
                    string telefono = txtTelefono.Text;
                    string dni = txtDNI.Text;
                    DateTime fechanacimiento = uiDatePicker1.Value;
                    UsuarioBE usuario = LOGIN._usuario;

                    string estado = "Activo";

                    // Igualamos el email para poder crear en la bll el paciente
                    string email = usuario.Email;

                    int retorna = _pacienteservice.AltaPaciente(dni, nombre, apellido, email, telefono, fechanacimiento, estado);
                    if(retorna > 0)
                    {
                        // Aca necesitariamos traer el paciente recientemente creado para poder ponerle el id paciente al usuario
                        
                        // Traemos todos los pacientes
                        List<PacienteBE> lista = _pacienteservice.ObtenerTodos();
                        // y ahora los ordenamos de mayor a menor por el id para que despues podamos sacar el id mas alto y de ahi agregarle un uno para insertarlo en el usuario
                        List<PacienteBE> idmasalto= lista.OrderByDescending(x => x.ID_Paciente).ToList();
                        // ahora seleccionamos al primer paciente de la lista ya ordenada y lo pasamos como pacientebe
                        PacienteBE ultimopaciente= idmasalto.FirstOrDefault();

                        usuario.ID_Paciente = ultimopaciente.ID_Paciente;

                        // Ahora agregamos el id de paciente en usuario
                        int retornamos = _usuarioservice.AgregarIDPaciente(usuario);

                        if(retornamos > 0)
                        {
                           DialogResult respuesta  = MessageBox.Show("Terminamos de Completar los datos necesarios, Ahora te ingresaremos como Paciente \n  Quieres Continuar?", "EXITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if(respuesta == DialogResult.Yes)
                            {
                                // Si toco si entonces...
                                this.Close();

                                // Mostramos la vista de paciente
                                MAINPaciente paciente = new MAINPaciente(_profesionalservice,_especialidadservice, _turnoservice);
                                paciente.ShowDialog();
                            }
                            else
                            {
                                Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Vincular al Usuario con el Paciente", "ERROR");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Agregar la Informacion Adicional necesaria para poder Terminar de Crear al Paciente", "ERROR");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de Error: " + ex.Message);
            }
        }



        // DESIGN


        //DNI 
        bool updni = false;
        bool downdni = false;
        private void TimerDNI_Tick(object sender, EventArgs e)
        {
            if(updni && lblDNI.Top > 0)
            {
                lblDNI.Top -= 2;
                if(lblDNI.Top <= 0)
                {
                    TimerDNI.Stop();
                    updni = false;
                }
            }
            else  if(downdni && lblDNI.Top < 12)
            {
                lblDNI.Top += 12;
                if(lblDNI.Top >= 12)
                {
                    TimerDNI.Stop();
                    downdni = false;
                }
            }
        }

        private void lblDNI_Click(object sender, EventArgs e)
        {
            txtDNI.Focus();
        }
        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                updni = true;
                downdni = false;
                TimerDNI.Start();
            }
        }
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                updni = false;
                downdni = true;
                TimerDNI.Start();
            }
        }

        // NOMBRE
        bool upnombre = false;
        bool downnombre = false;
        private void TimerNombre_Tick(object sender, EventArgs e)
        {
            if(upnombre && lblnombre.Top> 0)
            {
                lblnombre.Top -= 2;
                if(lblnombre.Top <= 0)
                {
                    TimerNombre.Stop();
                    upnombre = false;
                }
            }
            else if(downnombre && lblnombre.Top < 12)
            {
                lblnombre.Top += 2;
                if(lblnombre.Top >= 12)
                {
                    TimerNombre.Stop();
                    downnombre = false;
                }
            }
        }

        private void lblnombre_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

      

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                upnombre = true;
                downnombre = false;
                TimerNombre.Start();
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                upnombre = false;
                downnombre = true;
                TimerNombre.Start();
            }
        }


        // APELLIDO 
        bool upapellido = false;
        bool downapellido = false;
        private void lblApellido_Click(object sender, EventArgs e)
        {
            txtApellido.Focus();
        }

        private void TimerApellido_Tick(object sender, EventArgs e)
        {
            if(upapellido && lblapellido.Top > 0)
            {
                lblapellido.Top -= 2;
                if(lblapellido.Top <= 0)
                {
                    TimerApellido.Stop();
                    upapellido=false;
                }
            }
            else if(downapellido && lblapellido.Top < 12)
            {
                lblapellido.Top += 2;
                if(lblapellido.Top >= 12)
                {
                    TimerApellido.Stop();
                    downapellido = false;
                }
            }
        }
        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                upapellido = true;
                downapellido=false;
                TimerApellido.Start();
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                upapellido = false;
                downapellido = true;
                TimerApellido.Start();
            }
        }


        // TELEFONO

        bool uptelefono = false;
        bool downtelefono = false;

        private void TimerTelefono_Tick(object sender, EventArgs e)
        {
            if(uptelefono && lbltelefono.Top > 0)
            {
                lbltelefono.Top -= 2;
                if(lbltelefono.Top <= 0)
                {
                    TimerTelefono.Stop();
                    uptelefono = false;
                }
            }
            else if(downtelefono && lbltelefono.Top < 12)
            {
                lbltelefono.Top += 2;
                if(lbltelefono.Top >= 12)
                {
                    TimerTelefono.Stop();
                    downtelefono = false;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            txtTelefono.Focus();
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                uptelefono = true;
                downtelefono = false;
                TimerTelefono.Start();
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                uptelefono = false;
                downtelefono = true;
                TimerTelefono.Start();
            }
        }
    }
}
