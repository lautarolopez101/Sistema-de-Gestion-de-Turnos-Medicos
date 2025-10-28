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
            CargarComboEstados();
            _pacienteservice = pacienteservice;
            RDBActivo.Checked = true;
            btnAlta.Hide();
            lblid.Hide();
            label8.Hide();
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

        // Cuando en el formulario hay un pequenio cambio 
        // usa este evento para cargar los datos
        private void FRMABMPacientes_Load(object sender, EventArgs e)
        {
            // llamo al metodo para cargar los datos
            DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
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
            CMBLista.SelectedText = DGVPacientes.CurrentRow.Cells["Estado"].Value.ToString();
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
                    if (CMBLista.Items.Count > 0)
                    {
                        if (CMBLista.Text == "Activo")
                        {
                            string estado = CMBLista.Text;
                            // Aca llamamos al altapaciente del servicio para que haga el alta
                            // y creamos la devolucion del entero en retorna 
                            int retorna = _pacienteservice.AltaPaciente(dni, nombre, apellido, email, telefono, fecha, estado);
                            // si retorna es mayor a 0 quiere decir que se hizo bien el alta
                            if (retorna > 0)
                            {
                                MessageBox.Show("Paciente registrado con exito");
                                DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
                            }
                            // si no se hizo bien el alta tira un mensaje de error
                            else
                            {
                                MessageBox.Show("Error al registrar el paciente");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Primeo se debe Crear el paciente para luego poder darlo de baja");
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
            CMBActivo();
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
                    if (CMBLista.Items.Count > 0)
                    {
                        if ((CMBLista.Text == "Activo") || (CMBLista.Text == "Desactivado"))
                        {
                            string estado = CMBLista.Text;
                            int retorna = _pacienteservice.ModificarPaciente(id, dni, nombre, apellido, email, telefono, fecha, estado);
                            if (retorna > 0)
                            {
                                MessageBox.Show("Paciente Modificado con exito");
                                DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
                            }
                            else
                            {
                                MessageBox.Show("Error al Modificar el paciente");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por Favor Selecciona de vuelta el tipo de Estado del Paciente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay ningun tipo de Estado disponible para elegir, por favor reinicia el programa");
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
            DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
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
            DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
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

                BackColor = Color.Green;

                //Botones
                btnBaja.BackColor = Color.White;
                btnLimpiar.BackColor = Color.White;
                btnModificar.BackColor = Color.White;
                btnRegistrar.BackColor = Color.White;

                // Labels Fore color
                lblid.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                // Labels Back Color
                lblid.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;
                label3.BackColor = Color.Green;
                label4.BackColor = Color.Green;
                label5.BackColor = Color.Green;
                label6.BackColor = Color.Green;
                label7.BackColor = Color.Green;
                label8.BackColor = Color.Green;
                DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
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

                BackColor = Color.Red;

                //Botones
                btnBaja.BackColor = Color.White;
                btnLimpiar.BackColor = Color.White;
                btnModificar.BackColor = Color.White;
                btnAlta.BackColor = Color.White;

                // Labels
                lblid.BackColor = Color.Red;
                label1.BackColor = Color.Red;
                label2.BackColor = Color.Red;
                label3.BackColor = Color.Red;
                label4.BackColor = Color.Red;
                label5.BackColor = Color.Red;
                label6.BackColor = Color.Red;
                label7.BackColor = Color.Red;
                label8.BackColor = Color.Red;
                // Labels Fore color
                lblid.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                DGVPacientes.DataSource = _pacienteservice.ListarPacientes(CUAL());
            }
        }





        // Metodos para poder limpiar y cargar de vuelta los Estados del Paciente Nuevo
        public string CMBActivo()
        {
            CargarComboEstados();
            //Si hay algo seleccionado, lo devuelve como un string 
            if (CMBLista.SelectedItem != null)
            {
                return CMBLista.SelectedIndex.ToString();
            }
            else
            {
                // Si no devuelve activo por defecto
                return "Activo";
            }
        }
        public void CargarComboEstados()
        {
            //Limpiamos el combobox
            CMBLista.Items.Clear();

            //Agregamos los items al combobox
            CMBLista.Items.Add("Activo");
            CMBLista.Items.Add("Desactivado");

            // Ponemos por default que arranque con Activo
            CMBLista.SelectedIndex = 0;
        }

    }
}
