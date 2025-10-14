using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using System.Net.Sockets;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class FRMABMPacientes : Form
    {
        // Inyeccion de dependencias
        private readonly IPacienteService _pacienteservice;
        public FRMABMPacientes(IPacienteService pacienteservice)
        {
            InitializeComponent();
            RDBActivo.AutoCheck = true;
            _pacienteservice = pacienteservice;
        }


        // Cuando en el formulario hay un pequenio cambio 
        // usa este evento para cargar los datos
        private void FRMABMPacientes_Load(object sender, EventArgs e)
        {
            // llamo al metodo para cargar los datos
          //  DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
        }

        // Evento para cuando selecciono un objeto en el DGV
        private void DGVPacientes_SelectionChanged(object sender, EventArgs e)
        {
            //Se ponene en los textbox la informacion del objeto
            lblid.Text = DGVPacientes.CurrentRow.Cells["ID_Paciente"].Value.ToString();
            txtNombre.Text = DGVPacientes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = DGVPacientes.CurrentRow.Cells["Apellido"].Value.ToString();
            txtDNI.Text = DGVPacientes.CurrentRow.Cells["DNI"].Value.ToString();
            txtEmail.Text = DGVPacientes.CurrentRow.Cells["Email"].Value.ToString();
            txtTelefono.Text = DGVPacientes.CurrentRow.Cells["Telefono"].Value.ToString();
            if(!string.IsNullOrEmpty(DGVPacientes.CurrentRow.Cells["FechaNacimiento"].Value.ToString()))
            {
             DTPFechaNacimiento.Value = Convert.ToDateTime(DGVPacientes.CurrentRow.Cells["FechaNacimiento"].Value.ToString());

            }
            else
            {
                DTPFechaNacimiento.ResetText();
            }
        }

        // Evento de boton para registrar un paciente nuevo
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            // Tengo que pasar todo lo de paciente a la BLL 

            // Creamos un nuevo paciente para poder agregarlo
            PacienteBE paciente = new PacienteBE();
               // Hacemos un tipo de verificacion para ver que necesita y poder manejar otras excepciones
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDNI.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(Convert.ToString(DTPFechaNacimiento.Text)))
                {
                    paciente.DNI= txtDNI.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.Apellido = txtApellido.Text;
                    paciente.Email = txtEmail.Text;
                    paciente.Telefono = txtTelefono.Text;
                    paciente.FechaNacimiento = DTPFechaNacimiento.Value;
                    int retorna = _pacienteservice.RegistrarPaciente(paciente);
                    if (retorna > 0)
                    {
                        MessageBox.Show("Paciente registrado con exito");
                        DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el paciente");
                    }
                }
                else
                {
                    paciente.DNI = txtDNI.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.Apellido = txtApellido.Text;
                    paciente.Email = txtEmail.Text;
                    int retorna = _pacienteservice.RegistrarPaciente(paciente);
                    if(retorna > 0)
                    {
                        MessageBox.Show("Paciente registrado con exito");
                        DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el paciente");
                    }

                }
            }
                // Hay que hacer excepciones para ver si tiene algunos datos necesarios y si no los tiene 
                // dependiendo que datos tenga que instancia del constructor va a usar
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblid.Text = null;
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            DTPFechaNacimiento.ResetText();

            // DGVPacientes.ClearSelection();

            txtDNI.Focus();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Creamos un nuevo paciente para poder agregarlo
            PacienteBE paciente = new PacienteBE();
            // Hacemos un tipo de verificacion para ver que necesita y poder manejar otras excepciones
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDNI.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(Convert.ToString(DTPFechaNacimiento.Text)))
                {
                    paciente.ID_Paciente = Convert.ToInt32(lblid.Text);
                    paciente.DNI = txtDNI.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.Apellido = txtApellido.Text;
                    paciente.Email = txtEmail.Text;
                    paciente.Telefono = txtTelefono.Text;
                    paciente.FechaNacimiento = DTPFechaNacimiento.Value;
                    int retorna = _pacienteservice.ModificarPaciente(paciente);
                    if (retorna > 0)
                    {
                        MessageBox.Show("Paciente Modificado con exito");
                        DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar el paciente");
                    }
                }
                else
                {
                    paciente.DNI = txtDNI.Text;
                    paciente.Nombre = txtNombre.Text;
                    paciente.Apellido = txtApellido.Text;
                    paciente.Email = txtEmail.Text;
                    int retorna = _pacienteservice.ModificarPaciente(paciente);
                    if (retorna > 0)
                    {
                        MessageBox.Show("Paciente Modificado con exito");
                        DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificado el paciente");
                    }
                }
            }
        
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            PacienteBE paciente = new PacienteBE();
            paciente.ID_Paciente = Convert.ToInt32(lblid.Text);
            paciente.DNI = txtDNI.Text;
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            paciente.Email = txtEmail.Text;
            paciente.Telefono = txtTelefono.Text;
            paciente.FechaNacimiento = DTPFechaNacimiento.Value; 
            if (paciente.ID_Paciente> 0)
            {
                _pacienteservice.EliminarPaciente(paciente);
                if (RDBActivo.Checked)
                {
                    DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
                }
                else
                {
                    DGVPacientes.DataSource = _pacienteservice.ListarPacientesDesactivados();
                }
                    MessageBox.Show("Paciente eliminado con exito");
            }
            else
            {
                MessageBox.Show("Error al eliminar el paciente");
            }

        }

        private void RDBActivo_Click(object sender, EventArgs e)
        {
            DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
        }

        private void RDBDesactivado_Click(object sender, EventArgs e)
        {
            DGVPacientes.DataSource = _pacienteservice.ListarPacientesDesactivados();
        }

        private void RDBActivo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
