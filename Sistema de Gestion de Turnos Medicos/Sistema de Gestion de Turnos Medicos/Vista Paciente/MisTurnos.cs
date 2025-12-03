using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Agregamos la libreria para redondear los paneles
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class MisTurnos : Form
    {
        // Interfaces
        private readonly ITurnoService _turnoservice;


        // Variables estaticas para tener un mejor manejo
        private string motivoturno;
        private DateTime fechaturno;
        public MisTurnos(ITurnoService turnoService)
        {
            InitializeComponent();
            // Redondeamos los paneles
            RedondearPanel(panelturnos, 20);
            RedondearPanel(panelconfirmar,20);
            RedondearPanel(panelcancelar,20);
            RedondearPanel(panelmodificar,20);

            _turnoservice = turnoService;

        }
        private void MisTurnos_Load(object sender, EventArgs e)
        {
            Recargamos();
        }
        private void Recargamos()
        {
            int idpaciente = AppSession.Paciente.ID_Paciente;
            string estado1 = "Confirmado";
            string estado2 = "Pendiente";

            List<TurnoBE> turnos = _turnoservice.FiltrarPacienteHistorial(idpaciente, estado1, estado2);


            var turnosmostrar = from turn in turnos
                                select new
                                {
                                    NombreProfesional = turn.NombreProfesional,
                                    ApellidoProfesional = turn.ApellidoProfesional,
                                    Estado = turn.Estado,
                                    Motivo = turn.Motivo,
                                    Fecha = turn.FechaHora
                                };


            dgvturnos.DataSource = turnosmostrar.ToList();
        }

        // Funcion para redondear los paneles
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // Aca lo unico que tendremos que hacer seria cambiar el estado del turno a Cancelado
                // Para ello vamos a traer la lista de turnos que tiene el paciente y ahi le cambiaremos el estado

                // la logica tendria que ser que la lista que esta mostrando tenemos que igualarla con la lista del paciente que tiene
                int idpaciente = AppSession.Paciente.ID_Paciente;
                string estado1 = "Confirmado";
                string estado2 = "Pendiente";
                List<TurnoBE> listaturnos = _turnoservice.FiltrarPacienteHistorial(idpaciente, estado1, estado2);

                // listo ahora con la lista aca tenemos que de alguna forma buscar algunas similitudes con la lista que selecciona
                // la forma mas facil seria igualarla con la fecha que es bastante complicado que sea a la misma hora el mismo dia
                // y a su vez para darle un refuerzo a la igualdad con el motivo y listo

                TurnoBE turno = listaturnos.FirstOrDefault(x => (x.Motivo == motivoturno) && (x.FechaHora == fechaturno));
                // una vez ya con el turno seleccionado tendremos que ir a buscar el idturno para cambiarle el estado a cancelado

                turno.Estado = "Cancelado";
                int retorna = _turnoservice.ModificarTurno(turno.ID_Turno,turno.ID_Paciente,turno.ID_Profesional,turno.Estado,turno.FechaHora,turno.Motivo,turno.Observaciones);

                if(retorna > 0)
                {
                    MessageBox.Show("Turno Cancelado con exito.");
                    Recargamos();
                }
                else
                {
                    MessageBox.Show("No se pudo cancelar el turno.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("¡ERROR! No se pudo cargar: \n\n" + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                // Aca tendremos que poner algo para que verifique por si fue un error


                int idpaciente = AppSession.Paciente.ID_Paciente;
                string estado1 = "Confirmado";
                string estado2 = "Pendiente";
                List<TurnoBE> listaturnos = _turnoservice.FiltrarPacienteHistorial(idpaciente, estado1, estado2);

                // listo ahora con la lista aca tenemos que de alguna forma buscar algunas similitudes con la lista que selecciona
                // la forma mas facil seria igualarla con la fecha que es bastante complicado que sea a la misma hora el mismo dia
                // y a su vez para darle un refuerzo a la igualdad con el motivo y listo

                TurnoBE turno = listaturnos.FirstOrDefault(x => (x.Motivo == motivoturno) && (x.FechaHora == fechaturno));
                // una vez ya con el turno seleccionado tendremos que ir a buscar el idturno para cambiarle el estado a cancelado

                turno.Estado = "Confirmado";
                int retorna = _turnoservice.ModificarTurno(turno.ID_Turno, turno.ID_Paciente, turno.ID_Profesional, turno.Estado, turno.FechaHora, turno.Motivo, turno.Observaciones);

                if (retorna > 0)
                {
                    MessageBox.Show("Turno Confirmado con exito.");
                    Recargamos();
                }
                else
                {
                    MessageBox.Show("No se pudo Confirmar el turno.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("¡ERROR! No se pudo cargar: \n\n" + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Aca tendremos que poder modificar solamente la fecha 
                if (dgvturnos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un turno primero que este  en estado PENDIENTE.");
                    return;
                }

                // Traemos la lista completa para poder manipular mejor los datos
                int idpaciente = AppSession.Paciente.ID_Paciente;
                string estado1 = "Confirmado";
                string estado2 = "Pendiente";



                // 1) Tomamos ID y fecha actual del turno seleccionado
                DateTime fechaActual = Convert.ToDateTime(dgvturnos.CurrentRow.Cells["Fecha"].Value);

                // 2
                // }) Abrimos el mini-form para elegir nueva fecha
                using (var frm = new FRMCambiarFechaTurno(fechaActual))
                {
                    var result = frm.ShowDialog(this);

                    if (result != DialogResult.OK)
                        return; // el usuario canceló


                    // 3) Llamamos a la BLL para actualizar SOLO la fecha
                    // Hay que traer el turno completo para poder poner los datos
                    // O hacer un metodo aparte en la BLL que solo modifique la fecha
                    //      1: Traeremos todos los turnos del paciente con los estados que tienen que aparecer en ester FORM
                    List<TurnoBE> lista = _turnoservice.FiltrarPacienteHistorial(idpaciente, estado1, estado2);
                    //      2: Ahora tenemos que buscar los datos que tienen para buscar primero que tenga el estado de pendiente
                    //      porque hay que acordarnos que en el estado pendiente nos permite modificar
                    List<TurnoBE> pendientes = lista
                        .Where(x => x.Estado == estado2).ToList();
                    //      3: Ahora buscamos el turno que coincida con la fecha y el motivo    
                    TurnoBE turno = pendientes
                        .FirstOrDefault(x => (x.Motivo == motivoturno) && (x.FechaHora == fechaturno));
                    int idturno = turno.ID_Turno;
                    DateTime nuevaFecha = frm.NuevaFecha;
                    int filas = _turnoservice.FechaTurno(idturno, nuevaFecha);

                    if (filas > 0)
                    {
                        MessageBox.Show("Fecha del turno modificada con éxito.");
                        Recargamos(); // refrescás la grilla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar la fecha del turno.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡ERROR! No se pudo cargar: \n\n" + ex.Message);
            }
        }

        private void dgvturnos_SelectionChanged(object sender, EventArgs e)
        {
            // Seleccionamos y se la damos a las variables 
            string estado = dgvturnos.CurrentRow.Cells["Estado"].Value.ToString();
            string confirmado = "Confirmado";


            if (estado == confirmado)
            {
                panelmodificar.Visible = false;
                panelconfirmar.Visible = false;
            }
            else
            {
                panelmodificar.Visible = true;
                panelconfirmar.Visible = true;
            }
                motivoturno = dgvturnos.CurrentRow.Cells["Motivo"].Value.ToString();
                fechaturno = Convert.ToDateTime(dgvturnos.CurrentRow.Cells["Fecha"].Value.ToString());
        }
    }
}
