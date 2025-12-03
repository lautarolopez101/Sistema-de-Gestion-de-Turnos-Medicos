using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class FRMCambiarFechaTurno : Form
    {
        public FRMCambiarFechaTurno(DateTime fechaActual)
        {
            InitializeComponent();
            uiDatetimePicker1.Value = fechaActual;

        }
        public DateTime NuevaFecha { get; private set; }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Podés meter validaciones si querés
            if (uiDatetimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("La nueva fecha no puede ser en el pasado.");
                return;
            }

            NuevaFecha = uiDatetimePicker1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
