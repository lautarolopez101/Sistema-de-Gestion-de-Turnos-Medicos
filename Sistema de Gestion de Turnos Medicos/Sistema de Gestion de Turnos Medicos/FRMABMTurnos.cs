using BE;
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
        // Necesitamos las interface de paciente y profesional para poder reutilizar el codigo de ellos para mostrar las listas enteras y llamar alguna que otra funcion que necesitemos
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
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que los campos necesarios no esten vacios
                if (!string.IsNullOrEmpty(DTPFechaHora.Text) && !string.IsNullOrEmpty(LBLID_Paciente.Text) && !string.IsNullOrEmpty(txtMotivo.Text) && !string.IsNullOrEmpty(LBLID_Profesional.Text))
                {
                    // Verificamos que se hayan limpiado correctamtente los labels para poder seguir
                    if(LBLID_Paciente.Text != "0" && LBLID_Profesional.Text != "0")
                    {
                    // Pasamos los valores a unas variables para poder tener un mejor manejo
                        int idprofesional = Convert.ToInt32(LBLID_Profesional.Text);
                        int idpaciente  = Convert.ToInt32(LBLID_Paciente.Text);
                        string motivo = txtMotivo.Text;
                        DateTime fechahora = DTPFechaHora.Value;
                        string estado = RBConfirmado.Checked ? "Confirmado" : "Pendiente";
                        string observaciones = txtObservaciones.Text;

                        // AGREGAR UN METODO PARA VERIFICAR SI YA EXISTE UNA RELACION PARECIDA O NO Y QUE LA MUESTRE
                        // Y SI EL USUARIO AUN ASI LA QUIERE AGREGAR IGUAL QUE LO HAGA, PERO NOSOTROS LE ADVERTIMOS
                        List<TurnoBE> verificados = _turnoService.VerificoDuplicado(idprofesional, idpaciente);
                        // Vemos cuantos turnos similares hay y si hay mas de 0 entonces ....
                        if(verificados.Count > 0)
                        {
                            // Creamos una variable tipo "string" y ponemos un texto referenciando a cuantos turnos habria en tal caso
                            var texto = $"⚠️ Ya existen {verificados.Count} turno(s) para este paciente/profesional.\n" +  $"¿Querés agregar otro de todos modos?";

                            // Ahora hacemos un Message Box y le agregamos el texto y tambien el posible duplicado y los botones de si y no
                            var rta = MessageBox.Show(
                                texto,
                                "Posible duplicado de turno",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);
                            // si la respuesta del Message Box es no entonces
                            if (rta == DialogResult.No)
                                return; // ⟵ no agregamos y salimos del handler

                        }
                        // Creamos una variable para ver si se pudo agregar el turno nuevamente
                        int retorna = _turnoService.AgregarTurno(idpaciente, idprofesional, estado, fechahora, motivo, observaciones);
                        // Si el entero es mayor a 0 entonces se pudo agregar con exito el turno 
                        if (retorna > 0)
                        {
                            MessageBox.Show("Turno agregado con exito");
                            // Cargamos a todos los turnos nuevamente
                            DGVTurnos.DataSource = _turnoService.ObtenerTodos();
                            // Limpiamos los campos para ver si quiere agregar de vuelta otro turno
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Agregarse el Turno.");
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
                MessageBox.Show("Error al Agregar el turno: " + ex.Message);
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
                MessageBox.Show("Error al Limpiar los Campos: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                // Pasamos los valores a unas variables para poder tener un mejor manejo
                int idturno = Convert.ToInt32(LBLID_Turno.Text);
                int idprofesional = Convert.ToInt32(LBLID_Profesional.Text);
                int idpaciente = Convert.ToInt32(LBLID_Paciente.Text);
                string motivo = txtMotivo.Text;
                DateTime fechahora = DTPFechaHora.Value;
                string estado = RBConfirmado.Checked ? "Confirmado" : "Pendiente";
                string observaciones = txtObservaciones.Text;

                var buscamos = _turnoService.Verifico(idturno);
                if(buscamos.Count == 1)
                {
                    int retorna = _turnoService.ModificarTurno(idturno,idpaciente, idprofesional, estado, fechahora, motivo, observaciones);
                    if(retorna > 0)
                    {
                        MessageBox.Show("Exito al Modificar el Turno");
                        DGVTurnos.DataSource = _turnoService.ObtenerTodos();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al intentar modificar el turno");
                    }
                }
                else
                {
                    MessageBox.Show("No existe ningun turno");
                }
            }
            catch (Exception ex)
                {
                    MessageBox.Show("Error al Modificar el turno: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que los campos necesarios no esten vacios
                if (!string.IsNullOrEmpty(DTPFechaHora.Text) && !string.IsNullOrEmpty(LBLID_Paciente.Text) && !string.IsNullOrEmpty(txtMotivo.Text) && !string.IsNullOrEmpty(LBLID_Profesional.Text))
                {
                        // Pasamos los valores a unas variables para poder tener un mejor manejo
                        int idturno = Convert.ToInt32(LBLID_Turno.Text);
                        int idprofesional = Convert.ToInt32(LBLID_Profesional.Text);
                        int idpaciente = Convert.ToInt32(LBLID_Paciente.Text);
                        string motivo = txtMotivo.Text;
                        DateTime fechahora = DTPFechaHora.Value;
                        string estado = RBConfirmado.Checked ? "Confirmado" : "Pendiente";
                        string observaciones = txtObservaciones.Text;

                        // Creamos una variable para ver si se pudo agregar el turno nuevamente
                        int retorna = _turnoService.EliminarTurno(idturno,idpaciente, idprofesional, estado, fechahora, motivo, observaciones);
                        // Si el entero es mayor a 0 entonces se pudo agregar con exito el turno 
                        if (retorna > 0)
                        {
                            MessageBox.Show("Turno Eliminado con exito");
                            // Cargamos a todos los turnos nuevamente
                            DGVTurnos.DataSource = _turnoService.ObtenerTodos();
                            // Limpiamos los campos para ver si quiere agregar de vuelta otro turno
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar el Turno.");
                        }
                }
                else
                {
                    MessageBox.Show("Por favor Seleccione un Turno para poder Eliminarlo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar el turno: " + ex.Message);
            }
        }

        // -------------------------------------------- AREA DE SELECCION DE DATAGRIDVIEW --------------------------------------------------


        // DGV Principal Turnos
        private void DGVTurnos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LBLID_Turno.Text = DGVTurnos.CurrentRow.Cells["ID_Turno"].Value.ToString();
                LBLID_Profesional.Text = DGVTurnos.CurrentRow.Cells["ID_Profesional"].Value.ToString();
                LBLID_Paciente.Text = DGVTurnos.CurrentRow.Cells["ID_Paciente"].Value.ToString();
                txtMotivo.Text = DGVTurnos.CurrentRow.Cells["Motivo"].Value.ToString();
                if (DGVTurnos.CurrentRow.Cells["Observaciones"].Value != null )
                {
                    txtObservaciones.Text = DGVTurnos.CurrentRow.Cells["Observaciones"].Value.ToString();
                }
                else
                {
                    txtObservaciones.Text = null;
                }
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

                // Cuando selecciono un turno tendria que mostrar en los DGV Paciente y Profesional, los involucrados en el turno para que pueda ver a simple vista los datos de ellos

                int idprofesional = Convert.ToInt32(LBLID_Profesional.Text);
                int idpaciente = Convert.ToInt32(LBLID_Paciente.Text);

                if(idprofesional >0)
                {
                    DGVProfesionales.DataSource = _profesionalservice.ObtenerProfesional(idprofesional);
                }
                if(idpaciente >0)
                {
                    DGVPacientes.DataSource = _pacienteservice.ObtenerPaciente(idpaciente);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar el turno: " + ex.Message);
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
                MessageBox.Show("Error al Seleccionar el Paciente: " + ex.Message);
            }
        }
        private void DGVProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               LBLID_Profesional.Text = DGVProfesionales.CurrentRow.Cells["ID_Profesional"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar el Profesional: " + ex.Message);
            }
        }



        // -------------------------------------------- AREA DE FUNCIONES QUE NECESITAMOS DENTRO DE LA MISMA CLASE --------------------------------------------------

        private void LimpiarCampos()
        {
            // Ponemos la listas primeros para que no nos afecte en los labels
            // La idea de cargar a todos es para que pueda seleccionar por si quiere agregar a alguien
            DGVPacientes.DataSource = _pacienteservice.ObtenerTodos();
            DGVProfesionales.DataSource = _profesionalservice.ObtenerProfesionales();

            //Limpiamos todos los campos para poder "AGREGAR" un nuevo turno en el ABM
            LBLID_Turno.Text = "0";
            LBLID_Profesional.Text = "0";
            LBLID_Paciente.Text = "0";
            txtMotivo.Text = null;
            txtObservaciones.Text = null;
            DTPFechaHora.Value = DateTime.Today;
            RBConfirmado.Checked = false;
            RBPendiente.Checked = false;
            txtMotivo.Focus();
        }
    }
}
