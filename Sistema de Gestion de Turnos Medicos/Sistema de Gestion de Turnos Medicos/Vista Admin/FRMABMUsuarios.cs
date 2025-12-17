using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public partial class FRMABMUsuarios : Form
    {
        private readonly IUsuarioService _usuarioservice;
        private readonly IProfesionalService _profesionalservice;

        private static int _idusuario;
        public FRMABMUsuarios(IUsuarioService usuarioService,IProfesionalService profesionalservice)
        {
            InitializeComponent();
            _usuarioservice = usuarioService;
            _profesionalservice = profesionalservice;

            RedondearPanel(panel1, 20);
            RedondearPanel(panel2, 20);
            RedondearPanel(panel3, 20);
            RedondearPanel(panel4, 20);
            RedondearPanel(panel5, 20);
            RedondearPanel(panel6, 20);
        }
        // Funcion para redondear los paneles
        // Para poder redondear los paneles necesitamos crear una funcion
        //  le damos como parametros el panel que queremos redondear y el radio de redondeo
        private void RedondearPanel(Panel pnl, int radio)
        {
            // Creamos una variable rectangulo que sera el area del panel
            var rect = pnl.ClientRectangle;
            // Inflamos el rectangulo para que no se vean los bordes cortados
            rect.Inflate(-1, -1);
            // Creamos un path para dibujar el panel redondeado
            using (GraphicsPath path = new GraphicsPath())
            {
                // Calculamos el diametro del arco
                int d = radio * 2;
                // Esquina superior izquierda
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                // Esquina superior derecha
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                // Esquina inferior derecha
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                // Esquina inferior izquierda
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                // Cerramos el path
                path.CloseFigure();
                // Asignamos el path al region del panel
                pnl.Region = new Region(path);
            }
            /*
             *  Lo que hicimos fue 
             *  1: Calcular el rectangulo interno del panel
             *  2: Lo achica un poco para que no se pegue a los bordes 
             *  3: Dibuja una figura con 4 curvas (una en cada esquina)
             *  4: Cierra esa figura
             *  5: Usa esa figura como molde para recortar el panel
             *  6: Resultado= el panel tiene esquinas redondeadas
             */
        }

        private void FRMABMUsuarios_Load(object sender, EventArgs e)
        {
            Recargamos();
        }
        private void Recargamos()
        {
            List<UsuarioBE> listatodos = _usuarioservice.ObtenerUsuariosProfesionales();

            var lista = from usuario in listatodos
                        select new
                        {
                            Username = usuario.Username,
                            Email = usuario.Email,
                            Last_Login = usuario.LastLogin
                        };

            dataGridView1.DataSource = lista.ToList();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            // aca tendriamos que agregar un usuario nuevo para luego vincularlo con un paciente o un profesional
            // la idea es que el paciente pueda vincularse normal como un usuario pero el profesional no, el profesional deberia ser creado por un admin
            // asi que lo que vamos a hacer es crear un usuario para luego poder vincularlo con un profesional
            // tenemos que traer a todos los usuarios que esten vinculados con un profesional o no esten vinculados con ninguno
            

            string username = txtusername.Text;
            string password = txtcontraseña.Text;
            string email = txtemail.Text;
            // aca tenemos que ver como podemos buscar la manera de vincular con algun profesional
            // podriamos hacer una ventana emergente que nos busque con la lista de los profesionales disponibles, que no esten vinculados a un usuario
            try
            {
                int retorna = _usuarioservice.CrearUsuario(username,password,email);
                if (retorna > 0)
                {
                    MessageBox.Show($"Hemos Creado el Usuario: {username}.  ");
                }
                else
                {
                    MessageBox.Show("Error al Crear el Usuario.");
                }
                Recargamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Vincular_Click(object sender, EventArgs e)
        {
            try
            {
                // Tenemos que hacer que verifique que no este vinculado con ningun paciente u profesional para poder vincularlo con algun profesional
                List<UsuarioBE> lista = _usuarioservice.ObtenerTodos();
                UsuarioBE buscamos = lista.FirstOrDefault(x => x.ID == _idusuario);
                if (buscamos.ID_Profesional > 0 || buscamos.ID_Paciente > 0)
                    throw new ValidationException("El usuario que selecciono ya esta vinculado con algun paciente o profesional.");

                FRMElegirProfesional form = new FRMElegirProfesional(_profesionalservice,_usuarioservice,_idusuario);
                form.ShowDialog();
                Recargamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vincular el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string username = dataGridView1.CurrentRow.Cells["Username"].Value.ToString();

            List<UsuarioBE> lista = _usuarioservice.ObtenerTodos();
            UsuarioBE usuario = lista.FirstOrDefault(x => x.Username == username);
            _idusuario = usuario.ID;

        }
    }
}
