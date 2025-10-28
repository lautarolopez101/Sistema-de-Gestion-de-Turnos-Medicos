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

namespace Sistema_de_Gestion_de_Turnos_Medicos.ABM_s
{
    public partial class FRMABMEspecialidades : Form
    {
        private readonly IEspecialidadService _especialidadservice;
        public FRMABMEspecialidades(IEspecialidadService especialidadService)
        {
            InitializeComponent();
            _especialidadservice = especialidadService;

            // Que no se vean los labels de id
            lblid.Visible = true;
            label4.Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id  = int.Parse(lblid.Text); // Lo paso para ver si limpio los campos antes
                string descripcion = txtDescripcion.Text;// Es necesario?
                string especialidad = txtEspecialidad.Text;// SI ES NECESARIO
                if (!string.IsNullOrEmpty(especialidad))
                {
                    int retorna = _especialidadservice.AgregarEspecialidad(id,especialidad, descripcion);
                    if (retorna > 0)
                    {
                        MessageBox.Show("Especialidad agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El campo especialidad no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al agregar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Campos_Click(object sender, EventArgs e)
        {
            try
            {
                lblid.Text = null;
                txtDescripcion.Clear();
                txtEspecialidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblid.Text = DGVEspecialidades.CurrentRow.Cells["ID_Especialidad"].Value.ToString();
                txtEspecialidad.Text = DGVEspecialidades.CurrentRow.Cells["Especialidad"].Value.ToString();
                txtDescripcion.Text = DGVEspecialidades.CurrentRow.Cells["Descripcion"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRMABMEspecialidades_Load(object sender, EventArgs e)
        {
            DGVEspecialidades.DataSource = _especialidadservice.ListarEspecialidades();
        }
    }
}
