using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BLL;
using BE;
using Sunny.UI.Win32; // Agregamos para poder modificar las propiedades de los bordes
                      // de los paneles que estan detras de los DGV's

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class Turnos : Form
    {
        private readonly IProfesionalService _profesionalservice;
        private readonly IEspecialidadService _especialidadservice;
        private readonly ITurnoService _turnoservice;

        // Creamos esto para poder poner todos los profesionales "ACTIVOS"
        private bool cual = true;

        // Creamos algunas variables que necesitamos para cuando seleccionamos los DGV's
        private static int idespecialidad;
        private static int idprofesional;

        // 🚩 La bandera de control
        private bool _isUpdating = false;

        public Turnos(IProfesionalService profesionalservice,IEspecialidadService especialidadservice, ITurnoService turnoservice)
        {
            InitializeComponent();
            _profesionalservice = profesionalservice;
            _especialidadservice = especialidadservice;
            lbldni.Text = AppSession.Paciente.DNI;
            lblemail.Text = AppSession.Paciente.Email;
            lblnombre.Text = AppSession.Paciente.Nombre;
            _turnoservice = turnoservice;
        }
        private void Turnos_Load(object sender, EventArgs e)
        {
            try
            {
                // Redondear los paneles detras de los DGV's
                RedondearPanel(panelespecialidades, 15);   // 15 = radio de la esquina
                RedondearPanel(panelprofesionales, 10);   // 10 = radio de la esquina
                RedondearPanel(panelcancelar, 20);   // 10 = radio de la esquina
                RedondearPanel(panelnuevoturno, 20);   // 10 = radio de la esquina


                // Aca hacemos una pequeña logica para mostrar algunos de los datos en los dgvs
                List<EspecialidadBE> listaespecialidades = _especialidadservice.ListarEspecialidades();
                List<ProfesionalBE> listaprofesionales = _profesionalservice.ListarProfesionales(cual);

                // ahora necesitermos unos linq para poder hacer una nueva lista con los datos que queremos mostrar
                var especialidadesmostrar = from esp in listaespecialidades
                                            select new
                                            {
                                                Especialidad = esp.Especialidad
                                            };
                var profesionalesmostrar = from prof in listaprofesionales
                                             select new
                                             {
                                                  Nombre = prof.Nombre,
                                                  Apellido = prof.Apellido,
                                                  Matricula = prof.Matricula
                                             };

                dgvespecialidades.DataSource = especialidadesmostrar.ToList();
                dgvprofesionales.DataSource = profesionalesmostrar.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RedondearPanel(Panel pnl, int radio)
        {
            var rect = pnl.ClientRectangle;
            rect.Inflate(-1, -1);

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radio * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                pnl.Region = new Region(path);
            }
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificamos que haya seleccionado una especialidad para poder elegir al profesional indicado
                if (idespecialidad > 0 && idprofesional > 0)
                {
                    // si no ingreso un motivo no podra solicitar el turno
                    if (!string.IsNullOrWhiteSpace(txtmotivo.Text))
                    {
                        // Ahora si podemos solicitar el turno
                        // Necesitamos algunos datos para crear el turno, los cuales son:
                        // idprofesional (lo tenemos en la variable global)
                        PacienteBE paciente = AppSession.Paciente;
                        // idpaciente (lo tenemos en la AppSession)
                        int idpaciente = paciente.ID_Paciente;
                        // estado (siempre sera "Pendiente" al crear un turno), luego tendremos que confirmarlo
                        string estado = "Pendiente";
                        // fechaTurno (lo tomamos del datetimepicker)
                        DateTime fechaTurno = uiDatetimePicker1.Value;
                        // motivo (lo tomamos del textbox)
                        string motivo = txtmotivo.Text;

                        // Ahora lo agregamos y nos tiene que dar un X entero mayor a 0 si se agrego correctamente
                        int retorna = _turnoservice.AgregarTurnoIncompleto(idpaciente, idprofesional, estado, fechaTurno, motivo);

                        if (retorna > 0)
                        {
                            MessageBox.Show("Turno Pendiente correctamente. \n Luego tendremos que confirmar el turno en la pantalla principal aparecera los turnos reservados y confirmados", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Limpiamos los campos
                            uiDatetimePicker1.Value = DateTime.Now;
                            txtmotivo.Clear();
                            idespecialidad = 0;
                            idprofesional = 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo solicitar el turno. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un motivo para solicitar el turno.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una especialidad y un profesional para poder solicitar un turno.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                uiDatetimePicker1.Value = DateTime.Now;
                txtmotivo.Clear();
                idespecialidad = 0;
                idprofesional = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear un nuevo turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            // 🚩 Poner la bandera ANTES de la acción crítica
            _isUpdating = true;

            dgvespecialidades.SuspendLayout(); // Opcional, pero recomendado

            try
            {
                // 🔄 Asignación de DataSource (la acción que dispara el evento)
                dgvespecialidades.DataSource = _especialidadservice.ListarEspecialidades();
            }
            finally
            {
                // 🗑️ Quitar la bandera DESPUÉS de la acción crítica
                _isUpdating = false;
                dgvespecialidades.ResumeLayout(true); // Opcional, pero recomendado
            }
        }
        private void dgvespecialidades_SelectionChanged(object sender, EventArgs e)
        {
            // 🛑 1. Verificación de la Bandera
            if (_isUpdating)
            {
                return;
            }

            var grid = dgvespecialidades;

            // 🛑 2. Verificación de validez de la celda de ID
            if (grid.Rows.Count == 0 ||
                grid.CurrentRow == null ||
                grid.CurrentRow.IsNewRow)            
            {
                Limpiar();
                return;
            }

            // 🚩 3. Poner la Bandera
            _isUpdating = true;

            // 🚧 BLOQUEO CRÍTICO 🚧
            // Detenemos el re-dibujado de ambas grillas para que la asignación del DataSource
            // no fuerce eventos o actualizaciones en la otra grilla.
            dgvespecialidades.SuspendLayout();
            dgvprofesionales.SuspendLayout();

            try
            {
                // Buscamos la especialidad por el nombre 
                string especialidad = dgvespecialidades.CurrentRow.Cells["Especialidad"].Value.ToString();
                EspecialidadBE especialidadbe = _especialidadservice.BuscarPorNombre(especialidad);
                // 4. Lectura del ID y Lógica de Negocio
                idespecialidad = especialidadbe.ID_Especialidad;

                if (idespecialidad > 0)
                {
                    List<ProfesionalBE> listaprofesionales = _profesionalservice.ListarProfesionalesDesdeEspecialidades(idespecialidad);
                    var profesionalesmostrar = from prof in listaprofesionales
                                             select new
                                             {
                                                 Nombre = prof.Nombre,
                                                 Apellido = prof.Apellido,
                                                 Matricula = prof.Matricula
                                             };
                    // Se actualiza el DataSource mientras el redibujado está suspendido.
                    dgvprofesionales.DataSource = profesionalesmostrar.ToList();
                }
                else
                {
                    dgvprofesionales.DataSource = _profesionalservice.ListarProfesionales(cual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesionales: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 🗑️ 5. Quitar la Bandera
                _isUpdating = false;

                // 🔓 DESBLOQUEO CRÍTICO 🔓
                // Reanudamos el re-dibujado. El 'true' opcional fuerza un re-diseño inmediato.
                dgvprofesionales.ResumeLayout(true);
                dgvespecialidades.ResumeLayout(true);
            }
        }

        private void dgvprofesionales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // 🚩 Usar la bandera también aquí para seguridad, aunque el bucle es poco probable
            if (_isUpdating)
            {
                return;
            }

            // 🛑 Ocultar y configurar columnas SÓLO cuando los datos están completamente cargados

            // Es importante usar try-catch aquí también, por si alguna columna no existe.
            try
            {
                if (dgvprofesionales.Columns.Contains("ID_Profesional"))
                    dgvprofesionales.Columns["ID_Profesional"].Visible = false;

                if (dgvprofesionales.Columns.Contains("Activo"))
                    dgvprofesionales.Columns["Activo"].Visible = false;

                // Coloca el resto de tus líneas de Visible = false y de cambio de encabezado aquí
                // EJEMPLO:
                if (dgvprofesionales.Columns.Contains("Matricula"))
                    dgvprofesionales.Columns["Matricula"].HeaderText = "N° de Matrícula";

                // ... (resto de las configuraciones de columnas) ...

                // 🛡️ Finalmente, asegura la selección de la primera celda visible
                if (dgvprofesionales.Rows.Count > 0 && dgvprofesionales.Columns.Count > 0)
                {
                    // Puedes buscar la primera columna *visible* si tienes muchas ocultas, 
                    // pero si la primera columna visible tiene índice > 0, usar 0,0 puede fallar.
                    // Para simplificar, asumiremos que la primera columna *visible* es segura:
                    dgvprofesionales.ClearSelection();
                    dgvprofesionales.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas de profesionales: " + ex.Message, "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvprofesionales_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // No encontramos el id porque como creamos una "lista" nueva que muestre algunas cosas necesitaremos buscar el id por medio de la matricula
                ProfesionalBE profesional = new ProfesionalBE();
                string matricula = dgvprofesionales.CurrentRow.Cells["Matricula"].Value.ToString();
                profesional = _profesionalservice.ObtenerProfesionalPorMatricula(matricula);
                idprofesional = profesional.ID_Profesional;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas de profesionales: " + ex.Message, "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnNuevoTurno_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
