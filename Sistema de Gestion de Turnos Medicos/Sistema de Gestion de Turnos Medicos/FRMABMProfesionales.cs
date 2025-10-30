using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos.ABM_s
{
    public partial class FRMABMProfesionales : Form
    {
        private readonly IProfesionalService _profesionalService;
        public FRMABMProfesionales(IProfesionalService profesionalService)
        {
            InitializeComponent();
            _profesionalService = profesionalService;
        }

        private void DGVProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblid.Text = DGVProfesionales.CurrentRow.Cells["ID_Profesional"].Value.ToString();
                txtMatricula.Text = DGVProfesionales.CurrentRow.Cells["Matricula"].Value.ToString();
                txtNombre.Text = DGVProfesionales.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = DGVProfesionales.CurrentRow.Cells["Apellido"].Value.ToString();
                txtEmail.Text = DGVProfesionales.CurrentRow.Cells["Email"].Value.ToString();
                txtTelefono.Text = DGVProfesionales.CurrentRow.Cells["Telefono"].Value.ToString();
                bool prueba =Convert.ToBoolean(DGVProfesionales.CurrentRow.Cells["Activo"].Value.ToString());
                if (prueba == true)
                {
                    RBActivo.Checked = true;
                    RBDesactivo.Checked = false;
                }
                else
                {
                    RBActivo.Checked = false;
                    RBDesactivo.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FRMABMProfesionales_Load(object sender, EventArgs e)
        {
            DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                int retorna = _profesionalService.AgregarProfesional(matricula, nombre, apellido, telefono, email);
                if (retorna >0)
                {
                    MessageBox.Show("Se ha Agregado el Profesional Correctamente","Exito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha Agregado el Profesional Correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lblid.Text);
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                bool prueba;
                if (RBActivo.Checked == true)
                {
                    prueba = true;
                }
                else
                {
                    prueba = false;
                }
                int retorna = _profesionalService.ModificarProfesional(id, matricula, nombre, apellido, telefono,email, prueba);
                if (retorna > 0)
                {
                    MessageBox.Show("Se ha Modificado el Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha Modificado el Profesional Correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(lblid.Text);
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                bool prueba;
                if (RBActivo.Checked == true)
                {
                    prueba = true;
                }
                else
                {
                    prueba = false;
                }
                int retorna = _profesionalService.EliminarProfesional(id, prueba);
                if (retorna > 0)
                {
                    MessageBox.Show("Se ha Modificado el Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha Modificado el Profesional Correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtMatricula.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtMatricula.Focus();
        }

        private void RBActivo_CheckedChanged(object sender, EventArgs e)
        {

            var activo = RBActivo.Checked = true;
            var desactivado = RBDesactivo.Checked = false;
            if ((activo == true) && (desactivado == false))
            {
                btnAgregar.Hide();
                btnAgregar.Show();
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

                BackColor = Color.Green;

                //Botones
                btnAgregar.BackColor = Color.White;
                btnLimpiar.BackColor = Color.White;
                btnModificar.BackColor = Color.White;
                btnAgregar.BackColor = Color.White;

                // Labels Fore color
                lblid.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                // Labels Back Color
                lblid.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;
                label3.BackColor = Color.Green;
                label4.BackColor = Color.Green;
                label5.BackColor = Color.Green;
                label6.BackColor = Color.Green;
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            }
        }

        private void RBDesactivo_CheckedChanged(object sender, EventArgs e)
        {
            var activo = RBActivo.Checked = false;
            var desactivado = RBDesactivo.Checked = true;
            if ((desactivado == true) && (activo == false))
            {
                btnAgregar.Hide();
                btnAgregar.Show();
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;

                BackColor = Color.Red;

                //Botones
                btnEliminar.BackColor = Color.White;
                btnLimpiar.BackColor = Color.White;
                btnModificar.BackColor = Color.White;
                btnAgregar.BackColor = Color.White;

                // Labels
                lblid.BackColor = Color.Red;
                label1.BackColor = Color.Red;
                label2.BackColor = Color.Red;
                label3.BackColor = Color.Red;
                label4.BackColor = Color.Red;
                label5.BackColor = Color.Red;
                label6.BackColor = Color.Red;
                // Labels Fore color
                lblid.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            }
        }
        public bool CUAL()
        {
            bool activo = RBActivo.Checked;
            bool desactivado = RBDesactivo.Checked;

            if (((activo == true) && (desactivado == false)) || ((activo == false) && (desactivado == true)))
            {
                if (activo == true)
                {
                    return activo;
                }
                else if (desactivado == true)
                {
                    return desactivado;
                }
            } 
            return activo;
        }
    }
}
