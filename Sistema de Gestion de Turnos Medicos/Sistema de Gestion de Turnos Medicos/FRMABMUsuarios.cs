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

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class FRMABMUsuarios : Form
    {
        private readonly IUsuarioService _usuarioservice;
        public FRMABMUsuarios(IUsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioservice = usuarioService;
        }
        private void FRMABMUsuarios_Load(object sender, EventArgs e)
        {
            Recargamos();
        }
        private void Recargamos()
        {
            List<UsuarioBE> listatodos = _usuarioservice.ObtenerUsuariosProfesionales();

            dataGridView1.DataSource = listatodos;


        }

        private void panel2_Click(object sender, EventArgs e)
        {
            // aca tendriamos que agregar un usuario nuevo para luego vincularlo con un paciente o un profesional
            // la idea es que el paciente pueda vincularse normal como un usuario pero el profesional no, el profesional deberia ser creado por un admin
            // asi que lo que vamos a hacer es crear un usuario para luego poder vincularlo con un profesional
            // tenemos que traer a todos los usuarios que esten vinculados con un profesional o no esten vinculados con ninguno


            string username = txtusername.Text;
            string contraseña = txtcontraseña.Text;
            string email = txtemail.Text;
            // aca tenemos que ver como podemos buscar la manera de vincular con algun profesional
            // podriamos hacer una ventana emergente que nos busque con la lista de los profesionales disponibles, que no esten vinculados a un usuario



            try
            {
               // int retorna = _usuarioservice.CrearUsuarioProfesional(username, contraseña, email);
                if (retorna > 0)
                {
                    MessageBox.Show("Usuario agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Recargamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

       
    }
}
