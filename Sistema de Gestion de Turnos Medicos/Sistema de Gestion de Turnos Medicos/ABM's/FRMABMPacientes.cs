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
using BLL;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class FRMABMPacientes : Form
    {
        private readonly IPacienteService _pacienteservice;
        public FRMABMPacientes(IPacienteService pacienteservice)
        {
            InitializeComponent();
            _pacienteservice = pacienteservice;
        }

        private void FRMABMPacientes_Load(object sender, EventArgs e)
        {
            DGVPacientes.DataSource = _pacienteservice.ListarPacientes();
        }
    }
}
