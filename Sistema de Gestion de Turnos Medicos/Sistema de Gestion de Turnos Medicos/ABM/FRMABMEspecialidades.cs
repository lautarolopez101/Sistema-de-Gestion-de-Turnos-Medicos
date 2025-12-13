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

        private int id;
        public FRMABMEspecialidades(IEspecialidadService especialidadService)
        {
            InitializeComponent();
            _especialidadservice = especialidadService;

            // Que no se vean los labels de id
        }

        private void DGVEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt16(DGVEspecialidades.CurrentRow.Cells["ID_Especialidad"].Value.ToString());
                txtEspecialidad.Text = DGVEspecialidades.CurrentRow.Cells["Especialidad"].Value.ToString();
                txtDescripcion.Text = DGVEspecialidades.CurrentRow.Cells["Descripcion"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRMABMEspecialidades_Load(object sender, EventArgs e)
        {
            DGVEspecialidades.DataSource = _especialidadservice.ListarEspecialidades();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtDescripcion.Text;// Es necesario?
                string especialidad = txtEspecialidad.Text;// SI ES NECESARIO
                if (!string.IsNullOrEmpty(especialidad))
                {
                    int retorna = _especialidadservice.AgregarEspecialidad(especialidad, descripcion);
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
                DGVEspecialidades.DataSource = _especialidadservice.ListarEspecialidades();
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
                string descripcion = txtDescripcion.Text;// Es necesario?
                string especialidad = txtEspecialidad.Text;// SI ES NECESARIO
                int retorna = _especialidadservice.ModificarEspecialidad(id,especialidad,descripcion);
                if (retorna > 0)
                {
                    MessageBox.Show("Especialidad Modificada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar la especialidad","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DGVEspecialidades.DataSource = _especialidadservice.ListarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtDescripcion.Text;// Es necesario?
                string especialidad = txtEspecialidad.Text;// SI ES NECESARIO

                int retorna = _especialidadservice.EliminarEspecialidad(id,especialidad, descripcion);
                if (retorna > 0)
                {
                    MessageBox.Show("Especialidad Eliminada Correctamente","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Eliminar la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DGVEspecialidades.DataSource = _especialidadservice.ListarEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar la especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Campos_Click(object sender, EventArgs e)
        {
            try
            {
                id = 0;
                txtDescripcion.Clear();
                txtEspecialidad.Clear();
                txtEspecialidad.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
