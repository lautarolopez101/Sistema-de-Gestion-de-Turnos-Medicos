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
    public partial class FRMABMTurnos : Form
    {
        private readonly ITurnoService _turnoService;
        private readonly IPacienteService _pacienteservice;
        private readonly IProfesionalService _profesionalservice;

       
        
        // Constructor para cuando inicializa el formulario
        public FRMABMTurnos(ITurnoService turnoService, IPacienteService pacienteservice, IProfesionalService profesionalservice)
        {
            InitializeComponent();
            _turnoService = turnoService;
            _pacienteservice = pacienteservice;
            _profesionalservice = profesionalservice;
        }

        // Evento Load del formulario
        private void FRMABMTurnos_Load(object sender, EventArgs e)
        {
            DGVTurnos.DataSource = _turnoService.ObtenerTodos();

            int idturno = Convert.ToInt32(LBLID_Turno.Text);
            int idpaciente = Convert.ToInt32(LBLID_Paciente.Text);
            int idprofesional = Convert.ToInt32(LBLID_Profesional.Text);

            if(idturno>0)
            {
                // Cargo los datos del paciente y profesional seleccionado
            }


            DGVPacientes.DataSource = _pacienteservice.ObtenerTodos();
            DGVProfesionales.DataSource = _profesionalservice.ObtenerProfesionales();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que los campos necesarios no esten vacios
                if (!string.IsNullOrEmpty(DTPFechaHora.Text) && !string.IsNullOrEmpty(LBLID_Paciente.Text) && !string.IsNullOrEmpty(txtMotivo.Text) && !string.IsNullOrEmpty(LBLID_Profesional.Text))
                {
                    // Pasamos los valores a unas variables para poder tener un mejor manejo
                    if(LBLID_Paciente.Text != "0" && LBLID_Profesional.Text != "0")
                    {
                        int idprofesional = Convert.ToInt32(LBLID_Profesional.Text);
                        int idpaciente  = Convert.ToInt32(LBLID_Paciente.Text);
                        string motivo = txtMotivo.Text;
                        DateTime fechahora = DTPFechaHora.Value;
                        string estado = RBConfirmado.Checked ? "Confirmado" : "Pendiente";
                        string observaciones = txtObservaciones.Text;

                        int retorna = _turnoService.AgregarTurno(idpaciente, idprofesional, estado, fechahora, motivo, observaciones);
                        if (retorna > 0)
                        {
                            MessageBox.Show("Turno agregado con exito");
                            DGVTurnos.DataSource = _turnoService.ObtenerTodos();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar el turno");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un paciente y un profesional para poder agregar el turno.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }

        //Area de Seleccion de Datagrids


        // DGV Principal Turnos
        private void DGVTurnos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LBLID_Turno.Text = DGVTurnos.CurrentRow.Cells["ID_Turno"].Value.ToString();
                LBLID_Profesional.Text = DGVTurnos.CurrentRow.Cells["ID_Profesional"].Value.ToString();
                LBLID_Paciente.Text = DGVTurnos.CurrentRow.Cells["ID_Paciente"].Value.ToString();
                txtMotivo.Text = DGVTurnos.CurrentRow.Cells["Motivo"].Value.ToString();

                DTPFechaHora.Text = DGVTurnos.CurrentRow.Cells["FechaHora"].Value.ToString();
                string estado = DGVTurnos.CurrentRow.Cells["Estado"].Value.ToString();
                if (estado == "Confirmado")
                {
                    RBConfirmado.Checked = true;
                    RBPendiente.Checked = false;
                }
                else
                {
                    RBConfirmado.Checked = false;
                    RBPendiente.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }

        // Evento para cuando toco algo del DGV
        private void DGVPacientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LBLID_Paciente.Text = DGVPacientes.CurrentRow.Cells["ID_Paciente"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }
        // Evento para cuando se cambia la fuente de datos del DGV
        private void DGVPacientes_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void DGVProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               LBLID_Profesional.Text = DGVProfesionales.CurrentRow.Cells["ID_Profesional"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message);
            }
        }




        // Funciones Externas para poder usarlas dentro del formulario
        private void LimpiarCampos()
        {
            //Limpiamos todos los campos para poder "AGREGAR" un nuevo turno en el ABM
            LBLID_Turno.Text = "0";
            LBLID_Profesional.Text = "0";
            LBLID_Paciente.Text = "0";
            txtMotivo.Text = "0";
            DTPFechaHora.Value = DateTime.Now;
            RBConfirmado.Checked = false;
            RBPendiente.Checked = false;
        }
    }
}
