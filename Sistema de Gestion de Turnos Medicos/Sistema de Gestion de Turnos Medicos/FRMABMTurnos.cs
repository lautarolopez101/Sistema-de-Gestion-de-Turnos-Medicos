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
        public FRMABMTurnos(ITurnoService turnoService, IPacienteService pacienteservice, IProfesionalService profesionalservice)
        {
            InitializeComponent();
            _turnoService = turnoService;
            _pacienteservice = pacienteservice;
            _profesionalservice = profesionalservice;
        }

        private void FRMABMTurnos_Load(object sender, EventArgs e)
        {
            DGVTurnos.DataSource = _turnoService.ObtenerTodos();
           
        }
    }
}
