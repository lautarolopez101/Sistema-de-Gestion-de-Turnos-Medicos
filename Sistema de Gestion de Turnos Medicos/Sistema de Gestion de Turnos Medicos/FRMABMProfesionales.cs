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
        private readonly IEspecialidadService _especialidadService;
        public FRMABMProfesionales(IProfesionalService profesionalService,IEspecialidadService especialidadService)
        {
            InitializeComponent();
            _profesionalService = profesionalService;
            _especialidadService = especialidadService;
        }

        private void DGVProfesionales_SelectionChanged(object sender, EventArgs e)
        {

            var grid = DGVProfesionales;

            // 2) Guardas: puede no haber fila/selección durante el rebind o si el filtro devuelve 0 filas
            if (grid.Rows.Count == 0 || grid.CurrentRow == null || grid.CurrentCell == null || grid.CurrentRow.IsNewRow)
            {
                LimpiarCampos();
                return;
            }
            try
            {
                
                lblIDProfesionales.Text = DGVProfesionales.CurrentRow.Cells["ID_Profesional"].Value.ToString();
                txtMatricula.Text = DGVProfesionales.CurrentRow.Cells["Matricula"].Value.ToString();
                txtNombre.Text = DGVProfesionales.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = DGVProfesionales.CurrentRow.Cells["Apellido"].Value.ToString();
                txtEmail.Text = DGVProfesionales.CurrentRow.Cells["Email"].Value.ToString();
                txtTelefono.Text = DGVProfesionales.CurrentRow.Cells["Telefono"].Value.ToString();
                bool estado  = Convert.ToBoolean(DGVProfesionales.CurrentRow.Cells["Activo"].Value.ToString());
                if(estado == true)
                {
                    RBEstadoActivo.Checked = true;
                    RBEstadoDesactivo.Checked = false;   
                }
                else
                {
                    RBEstadoActivo.Checked = false;
                    RBEstadoDesactivo.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        // Cuando se hace una accion en el form carga esto 
        private void FRMABMProfesionales_Load(object sender, EventArgs e)
        {
            // Cargamos devuelta los datos de los profesionales
             DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());

            LimpiarCampos();
            
            // Pasamos el valor del label a un entero 
                int id = Convert.ToInt32(lblIDProfesionales.Text);

            //Si el label id profesionales tiene algo entonces carga las especialidades del profesional seleccionado
            if (id > 0)
            {
                // Llamamos la funcion necesaria y le damos como parametro el entero creado
                DGVEspecialidades.DataSource = _profesionalService.ListarEspecialidadesdelProfesional(id);
            }
            //sino muestra todos las especialidades para poder crear o asignarse a un profesional
            else
            {
                // Llamamos la funcion necesaria para mostrar todas las especialidades
                DGVEspecialidades.DataSource = _especialidadService.ListarEspecialidades();
            }

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
                if (retorna > 0)
                {
                    MessageBox.Show("Se ha Agregado el Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int id = Convert.ToInt32(lblIDProfesionales.Text);
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                bool prueba;
                if ((RBEstadoActivo.Checked == true) && (RBEstadoDesactivo.Checked == false))
                {
                    prueba = true;
                }
                else 
                {
                    prueba = false;
                }
                int retorna = _profesionalService.ModificarProfesional(id, matricula, nombre, apellido, telefono, email, prueba);
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
                int id = Convert.ToInt32(lblIDProfesionales.Text);
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
            try
            {
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RBDesactivo_CheckedChanged(object sender, EventArgs e)
        {
            //  DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(false);
            DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
           // RBDesactivo.Checked = true;

            BackColor = Color.Red;

            //Botones
            btnAgregar.BackColor = Color.White;
            btnLimpiar.BackColor = Color.White;
            btnModificar.BackColor = Color.White;
            btnAgregar.BackColor = Color.White;

            // Labels Fore color
            lblIDProfesionales.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            // Labels Back Color
            lblIDProfesionales.BackColor = Color.Red;
            label1.BackColor = Color.Red;
            label2.BackColor = Color.Red;
            label3.BackColor = Color.Red;
            label4.BackColor = Color.Red;
            label5.BackColor = Color.Red;
            label6.BackColor = Color.Red;

        }
        private void RBActivo_CheckedChanged(object sender, EventArgs e)
        {
            //     DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(true);
            DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            BackColor = Color.Green;

                //Botones
                btnAgregar.BackColor = Color.White;
                btnLimpiar.BackColor = Color.White;
                btnModificar.BackColor = Color.White;
                btnAgregar.BackColor = Color.White;

                // Labels Fore color
                lblIDProfesionales.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                // Labels Back Color
                lblIDProfesionales.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;
                label3.BackColor = Color.Green;
                label4.BackColor = Color.Green;
                label5.BackColor = Color.Green;
                label6.BackColor = Color.Green;
             //   DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());

            
        } 
      

        private void DGVProfesionales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DGVProfesionales.Rows.Count > 0)
            {
                // 5) Aseguro que haya una fila seleccionada (evita CurrentRow null)
                DGVProfesionales.ClearSelection();
                DGVProfesionales.Rows[0].Selected = true;
                DGVProfesionales.CurrentCell = DGVProfesionales.Rows[0].Cells[0];
            }
            else
            {
                // 6) Si no hay filas, limpio los campos y radios
                LimpiarCampos();
            }
        }
       
        private void DGVEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               // lblIDEspecialidades.Text = DGVEspecialidades.CurrentRow.Cells["ID_Especialidad"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Funciones que necesitamos dentro de la clase
        public bool CUAL()
        {
            bool activo = RBActivo.Checked;
            bool desactivo = RBDesactivo.Checked;
            if (activo == true && desactivo == false)
            {
                activo = true;
            }
            else if (desactivo == true && activo == false)
            {
                activo = false;
            }
            return activo;
        }
        private void LimpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtMatricula.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            lblIDProfesionales.Text = "0";
            txtMatricula.Focus();
            lblIDEspecialidades.Text = "0";

            RBEstadoDesactivo.Checked = false;
            RBEstadoActivo.Checked = false;
            RBActivo.Checked = false;
            RBDesactivo.Checked = false;
        }

    }
}
