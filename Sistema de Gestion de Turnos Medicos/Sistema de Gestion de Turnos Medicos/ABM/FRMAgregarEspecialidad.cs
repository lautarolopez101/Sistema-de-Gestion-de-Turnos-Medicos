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
    public partial class FRMAgregarEspecialidad : Form
    {
        private readonly IEspecialidadService _especialidadservice;
        private readonly IProfesional_EspecialidadService _profesional_especialidadservice;

        private static int ID_Profesional;
        public FRMAgregarEspecialidad(IEspecialidadService especialidadservice,IProfesional_EspecialidadService profesional_EspecialidadService,int idprofesional)
        {
            InitializeComponent();
            ID_Profesional = idprofesional;
            _especialidadservice = especialidadservice;
            _profesional_especialidadservice = profesional_EspecialidadService;
        }
        private bool Verificar(int idespecialidad, int idprofesional)
        {
            // Vamos a hacer una funcion para ver si ya esta creado en la tabla debil de Profesionales y Especialidades un profesional con x especialidad

            /*
             Ejemplo: Un profesional ya tiene la Especialidad de "Cardiologia", entonces cuando quiero modificar algo propio del profesional sin tener que limpiar los campos de Especialidades
            tendremos que ver si el profesional ya tiene creado un vinculo con el ID_Especialidad de "Cardiologia"

            Ejemplo visual?:

            Profesional: ID_Profesional(10), Nombre(Lautaro),Apellido(Lopez)
            Profesional_Especialidad: ID_Especialidad(2), ID_Profesional(10)
            Especialidad: ID_Especialidad(2), Nombre(Cardiologia)

            Entonces si ya esta creado el vinculo  no deberiamos volver a crearlo
             */


            //Entonces lo que tendriamos que hacer primero es traer toda la lista de Profesionales_Especialidades
            List<Profesionales_EspecialidadesBE> listaprincipal = _profesional_especialidadservice.ListarProfesionales_Especialidades();

            //Ahora tenemos que buscar con un LINQ
            bool existe = listaprincipal.Any(pe => pe.ID_Profesional == idprofesional && pe.ID_Especialidad == idespecialidad);
            return existe;

        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int idprofesional = ID_Profesional;
                int idespecialidad = Convert.ToInt32(lblid.Text);
                bool existe = Verificar(idespecialidad,idprofesional);
                if (existe == false)
                {
                    int retornamos = _profesional_especialidadservice.AgregarProfesional_Especialidad(idespecialidad, idprofesional);
                    if (retornamos > 0)
                    {
                        MessageBox.Show("Se ha podido Agregar la Especialidad al Profesional " + idespecialidad, "EXITO",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido Agregar la Especialidad al Profesional " + idespecialidad, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Profesional: "+ idprofesional + ", Ya tiene el vinculo con el ID Especialidad: " +idespecialidad,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Agregar la Especialidad a el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblid.Text = DGVEspecialidades.CurrentRow.Cells["ID_Especialidad"].Value.ToString();
                lblnombre.Text = DGVEspecialidades.CurrentRow.Cells["Especialidad"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar la Especialidad para el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRMAgregarEspecialidad_Load(object sender, EventArgs e)
        {
            DGVEspecialidades.DataSource = _especialidadservice.ListarEspecialidades();
        }
    }
}
