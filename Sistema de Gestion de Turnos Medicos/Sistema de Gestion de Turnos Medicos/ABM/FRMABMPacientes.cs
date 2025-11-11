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

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class FRMABMPacientes : Form
    {
        // Inyeccion de dependencias
        private readonly IPacienteService _pacienteservice;
        public FRMABMPacientes(IPacienteService pacienteservice)
        {
            InitializeComponent();
            _pacienteservice = pacienteservice;
            RDBActivo.Checked = true;
            btnAlta.Hide();
            lblid.Hide();
            label8.Hide();
        }

      

        // Cuando en el formulario hay un pequenio cambio 
        // usa este evento para cargar los datos
        private void FRMABMPacientes_Load(object sender, EventArgs e)
        {
            // llamo al metodo para cargar los datos
            DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
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
            if (!string.IsNullOrEmpty(DGVPacientes.CurrentRow.Cells["FechaNacimiento"].Value.ToString()))
            {
                DTPFechaNacimiento.Value = Convert.ToDateTime(DGVPacientes.CurrentRow.Cells["FechaNacimiento"].Value.ToString());
            }
            else
            {
                DTPFechaNacimiento.ResetText();
            }
            string estado = DGVPacientes.CurrentRow.Cells["Estado"].Value.ToString();
            // Nose porque el activo despues tiene un espacio, se debe crear solo por ahi con el query que tengo por default
            // que tengo para crear los pacientes automaticamente que lo hice con chatgpt pero me fije en el query y no lo tiene con algun espacio
            if(estado == "Activo         ")
            {
                RBEstadoActivo.Checked = true;
            }
            else if (estado == "Desactivado    ")
            {
                RBEstadoDesactivo.Checked = true;
            }

        }

        // Evento de boton para registrar un paciente nuevo
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Hacemos un tipo de verificacion para ver que necesita y poder manejar otras excepciones
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDNI.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                // recolectamos los valores de los textbox para poder tener un mejor manejo
                string dni = txtDNI.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                if (!string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(Convert.ToString(DTPFechaNacimiento.Text)))
                {
                    string telefono = txtTelefono.Text;
                    DateTime fecha = Convert.ToDateTime(DTPFechaNacimiento.Text.ToString());


                    string estado = "Activo";
                    if (RBEstadoActivo.Checked == true)
                    {
                        estado = "Activo";

                    }
                    else if (RBEstadoDesactivo.Checked == true)
                    {
                        estado = "Desactivado";
                    }
                    // Aca llamamos al altapaciente del servicio para que haga el alta
                    // y creamos la devolucion del entero en retorna 
                    int retorna = _pacienteservice.AltaPaciente(dni, nombre, apellido, email, telefono, fecha, estado);
                    // si retorna es mayor a 0 quiere decir que se hizo bien el alta
                    if (retorna > 0)
                    {
                        MessageBox.Show("Paciente registrado con exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Registrar el Paciente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Reinicia el programa porque salio un error que no hay ningun tipo de estado disponible para cargar");
                }
            }
            else
            {
                MessageBox.Show("Por favor completar todos los campos");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblid.Text = null;
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            RBEstadoDesactivo.Checked = false;
            RBEstadoActivo.Checked = false;
            DTPFechaNacimiento.ResetText();
            txtDNI.Focus();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Hacemos un tipo de verificacion para ver que necesita y poder manejar otras excepciones
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDNI.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                int id = Convert.ToInt32(lblid.Text);
                string dni = txtDNI.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                if (!string.IsNullOrEmpty(txtTelefono.Text) && !string.IsNullOrEmpty(Convert.ToString(DTPFechaNacimiento.Text)))
                {
                    string telefono = txtTelefono.Text;
                    DateTime fecha = Convert.ToDateTime(DTPFechaNacimiento.Text.ToString());

                    string estado = "Activo";
                    if (RBEstadoActivo.Checked == true)
                    {
                        estado = "Activo";

                    }
                    else if(RBEstadoDesactivo.Checked == true)
                    {
                        estado = "Desactivado";
                    }
                    int retorna = _pacienteservice.ModificarPaciente(id, dni, nombre, apellido, email, telefono, fecha, estado);
                    if (retorna > 0)
                    {
                        MessageBox.Show("Paciente Modificado con exito");
                        DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar el paciente");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor Agregale un telefono y una Fecha de Nacimiento para validar los datos");
                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblid.Text);
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            DateTime fecha = Convert.ToDateTime(DTPFechaNacimiento.Text.ToString());
            if (id > 0)
            {
                string estado = "Desactivado";
                _pacienteservice.BajaPaciente(id, dni, nombre, apellido, email, telefono, fecha, estado);
                MessageBox.Show("Se dio de Baja el Paciente: " + id);
            }
            else
            {
                MessageBox.Show("Error al eliminar el paciente");
            }
            DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
        }



        private void btnAlta_Click(object sender, EventArgs e)
        {
            // La logica de este boton que aparece cuando vemos la lista de pacientes desactivados seria 
            // volver a darle el estado de Activo para ponerlos en la lista con los demas 
            // entonces lo que tengo que hacer es agarrar el paciente entero y modificarle el estado a activo nomas
            string estado = "Activo";
            int id = Convert.ToInt32(lblid.Text);
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            DateTime fecha = Convert.ToDateTime(DTPFechaNacimiento.Text.ToString());
            if (id > 0)
            {
                _pacienteservice.ActivarPaciente(id, dni, nombre, apellido, email, telefono, fecha, estado);
                MessageBox.Show("Se volvio a Activar el Paciente " + id);
            }
            DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
        }



        // Funciones para "decorar"

        private void RDBActivo_Click(object sender, EventArgs e)
        {
            var activo = RDBActivo.Checked = true;
            var desactivado = RDBDesactivados.Checked = false;
            if ((activo == true) && (desactivado == false))
            {
                btnAlta.Hide();
                btnRegistrar.Show();
                btnBaja.Enabled = true;
                btnModificar.Enabled = true;
                DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
            }
        }

        private void RDBDesactivados_Click(object sender, EventArgs e)
        {

            var activo = RDBActivo.Checked = false;
            var desactivado = RDBDesactivados.Checked = true;
            if ((desactivado == true) && (activo == false))
            {
                btnRegistrar.Hide();
                btnAlta.Show();
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;
                DGVPacientes.DataSource = _pacienteservice.ListarPacientesEstado(CUAL());
            }
        }

        private void RBEstadoActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RBEstadoDesactivo_CheckedChanged(object sender, EventArgs e)
        {

        }



        public string CUAL()
        {
            var activo = RDBActivo.Checked;
            var desactivado = RDBDesactivados.Checked;

            if (((activo == true) && (desactivado == false)) || ((activo == false) && (desactivado == true)))
            {
                if (activo == true)
                {
                    string a = "Activo";
                    return a;
                }
                else if (desactivado == true)
                {
                    string r = "Desactivado";
                    return r;
                }
            }
            else
            {
                MessageBox.Show("No se pudo cargar ninguna lista en el DGV");
            }
            return "Empty";
        }

       
    }
}
