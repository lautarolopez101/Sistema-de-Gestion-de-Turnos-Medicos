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
    public partial class EspecialidadProfesional : Form
    {
        private readonly IEspecialidadService _especialidadservice;
        private readonly IProfesionalService _profesionalservice;
        private readonly int _idprofesional;
        public EspecialidadProfesional(IEspecialidadService especialidadservice, IProfesionalService profesionalservice)
        {
            InitializeComponent();

            _idprofesional = AppSession.Profesional.ID_Profesional;

            _especialidadservice = especialidadservice;
            _profesionalservice = profesionalservice;   

            RedondearPanel(panelagregar, 20);
            RedondearPanel(panelquitar, 20);
            RedondearPanel(panel1, 20);
            RedondearPanel(panelespecialidades, 20);
            RedondearPanel(panel2, 20);
            RedondearPanel(panel3, 20);
        }
        // La idea de este form es que me muestre las especialidades que tengo y tambien que me pueda agregar pero desde un boton pero a una ventana emergente


        private void Recargamos()
        {

            dgvespecialidades.ClearSelection();
            dgvespecialidadesprofesional.ClearSelection();
            // La idea es que muestre todas las especialidades que hay disponibles y las que tiene el profesional
            // Y tambien tenemos que Pintar las que ya tiene el profesional

            List<EspecialidadBE> especialidades = _especialidadservice.ListarEspecialidades();
            
            var listaespecialidaddes = from esp in especialidades
                                      select new
                                      {
                                          Especialidad = esp.Especialidad,
                                          Descripcion = esp.Descripcion
                                      };

            dgvespecialidades.DataSource = listaespecialidaddes.ToList();

            // Ahora toca mostrar las especialidades del profesional
            List<EspecialidadBE> delprofesional = _profesionalservice.ListarEspecialidadesdelProfesional(_idprofesional);

            var listaespecialidaddelprofesional = from esp in delprofesional
                                                select new
                                                {
                                                    Especialidad = esp.Especialidad,
                                                    Descripcion = esp.Descripcion
                                                };

            dgvespecialidadesprofesional.DataSource = listaespecialidaddelprofesional.ToList();



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
        private void EspecialidadProfesional_Load(object sender, EventArgs e)
        {
            Recargamos();
        }
       

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            // aca hay que seleccionar la especialidad del dgvespecialidad
            // primero hay que bajar lo que seleccionamos y buscar el id para luego agregarselo al profesional

            string especialidad = dgvespecialidades.CurrentRow.Cells[0].Value.ToString();   

            int retorna = _profesionalservice.AgregarEspecialidadAlProfesionalPorNombre(especialidad,_idprofesional);

            if(retorna > 0)
                MessageBox.Show("Se agrego la especialidad al profesional correctamente.");
            else
                throw new ValidationException("La especialidad ya se encuentra asignada al profesional.");
            Recargamos();
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            string especialidad = dgvespecialidadesprofesional.CurrentRow.Cells[0].Value.ToString();
            int retorna = _profesionalservice.QuitarEspecialidadAlProfesionalPorNombre(especialidad, _idprofesional);
            if (retorna > 0)
                MessageBox.Show("Se quito la especialidad al profesional correctamente.");
            else
                throw new ValidationException("La especialidad no se pudo quitar del profesional.");
            Recargamos();

        }
    }
}
