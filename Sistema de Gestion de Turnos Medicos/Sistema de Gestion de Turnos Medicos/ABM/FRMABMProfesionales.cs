using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Gestion_de_Turnos_Medicos.ABM_s
{
    public partial class FRMABMProfesionales : Form
    {
        private readonly IProfesionalService _profesionalService;
        private readonly IEspecialidadService _especialidadService;
        private readonly IProfesional_EspecialidadService _profesionalespecialidadService;
        public FRMABMProfesionales(IProfesionalService profesionalService,IEspecialidadService especialidadService, IProfesional_EspecialidadService profesionalespecialidadService)
        {
            InitializeComponent();
            _profesionalService = profesionalService;
            _especialidadService = especialidadService;
            _profesionalespecialidadService = profesionalespecialidadService;
        }

        private void DGVProfesionales_SelectionChanged(object sender, EventArgs e)
        {

            var grid = DGVProfesionales;

            // 2) Guardas: puede no haber fila/selección durante el rebind o si el filtro devuelve 0 filas
            if (grid.Rows.Count == 0 || grid.CurrentRow == null || grid.CurrentCell == null || grid.CurrentRow.IsNewRow)
            {
                LimpiarCampos();
                return;
            }
            try
            {
                
                lblIDProfesionales.Text = DGVProfesionales.CurrentRow.Cells["ID_Profesional"].Value.ToString();
                txtMatricula.Text = DGVProfesionales.CurrentRow.Cells["Matricula"].Value.ToString();
                txtNombre.Text = DGVProfesionales.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = DGVProfesionales.CurrentRow.Cells["Apellido"].Value.ToString();
                txtEmail.Text = DGVProfesionales.CurrentRow.Cells["Email"].Value.ToString();
                txtTelefono.Text = DGVProfesionales.CurrentRow.Cells["Telefono"].Value.ToString();
                bool estado  = Convert.ToBoolean(DGVProfesionales.CurrentRow.Cells["Activo"].Value.ToString());
                if(estado == true)
                {
                    RBEstadoActivo.Checked = true;
                    RBEstadoDesactivo.Checked = false;   
                }
                else
                {
                    RBEstadoActivo.Checked = false;
                    RBEstadoDesactivo.Checked = true;
                }

                // Pasamos el valor del label a un entero 
                int id = Convert.ToInt32(lblIDProfesionales.Text);

                //Si el label id profesionales tiene algo entonces carga las especialidades del profesional seleccionado
                if (id > 0)
                {
                    // Llamamos la funcion necesaria y le damos como parametro el entero creado
                    DGVEspecialidades.DataSource = _profesionalService.ListarEspecialidadesdelProfesional(id);
                }
                //sino muestra todos las especialidades para poder crear o asignarse a un profesional
                else
                {
                    // Llamamos la funcion necesaria para mostrar todas las especialidades
                    DGVEspecialidades.DataSource = _especialidadService.ListarEspecialidades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Seleccionar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DGVProfesionales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DGVProfesionales.Rows.Count > 0)
            {
                // 5) Aseguro que haya una fila seleccionada (evita CurrentRow null)
                DGVProfesionales.ClearSelection();
                DGVProfesionales.Rows[0].Selected = true;
                DGVProfesionales.CurrentCell = DGVProfesionales.Rows[0].Cells[0];
            }
            else
            {
                // 6) Si no hay filas, limpio los campos y radios
                LimpiarCampos();
            }
        }

        private void DGVEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblIDEspecialidades.Text = DGVEspecialidades.CurrentRow.Cells["ID_Especialidad"].Value.ToString();
                lblespecialidad.Text = DGVEspecialidades.CurrentRow.Cells["Especialidad"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Cuando se hace una accion en el form carga esto 
        private void FRMABMProfesionales_Load(object sender, EventArgs e)
        {
            // Cargamos devuelta los datos de los profesionales
             DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());

            
            // Pasamos el valor del label a un entero 
                int id = Convert.ToInt32(lblIDProfesionales.Text);

            //Si el label id profesionales tiene algo entonces carga las especialidades del profesional seleccionado
            if (id > 0)
            {
                // Llamamos la funcion necesaria y le damos como parametro el entero creado
                DGVEspecialidades.DataSource = _profesionalService.ListarEspecialidadesdelProfesional(id);
            }
            //sino muestra todos las especialidades para poder crear o asignarse a un profesional
            else
            {
                // Llamamos la funcion necesaria para mostrar todas las especialidades
                DGVEspecialidades.DataSource = _especialidadService.ListarEspecialidades();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Agregamos el Profesional sin la especialidad
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                int retorna = _profesionalService.AgregarProfesional(matricula, nombre, apellido, telefono, email);
                if (retorna > 0)
                {
                    MessageBox.Show("Se ha Agregado el Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha Agregado el Profesional Correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());


                // Ahora la parte de la especialidad
                
                // PREGUNTAR AL PROFESOR SI TIENE SENTIDO AGREGAR UNA ESPECIALIDAD YA CON EL PROFESIONAL O HACERLO EN EL MODIFICAR
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // La parte de modificar un Profesional
                int idprofesional = Convert.ToInt32(lblIDProfesionales.Text);
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                bool prueba;
                if ((RBEstadoActivo.Checked == true) && (RBEstadoDesactivo.Checked == false))
                {
                    prueba = true;
                }
                else 
                {
                    prueba = false;
                }
                int retorna = _profesionalService.ModificarProfesional(idprofesional, matricula, nombre, apellido, telefono, email, prueba);
                if (retorna > 0)
                {
                    
                    MessageBox.Show("Se ha Modificado el Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se ha Modificado el Profesional Correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());

                // Pasamos el contenido del label a un entero para mejor manejo
                int idespecialidad = Convert.ToInt32(lblIDEspecialidades.Text);
                
                // Llamamos el metodo para ver si ya existe o no (Esta explicado paso a paso y el porque)
                bool existe= Verificar(idespecialidad, idprofesional);

                if(existe)
                {
                    if(idespecialidad> 0)
                    {
                        int reto = _profesionalespecialidadService.AgregarProfesional_Especialidad(idespecialidad, idprofesional);
                        if (reto > 0)
                        {
                            MessageBox.Show("Se ha Modificado una Especialidad al Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("NO se ha podido modificar o ya existe el vinculo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // La Parte de los Profesionales

                // Pasamos los datos del los campos a variables para tener un mejor manejo y poder ser mas flexible
                int idprofesional = Convert.ToInt32(lblIDProfesionales.Text);
                string matricula = txtMatricula.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                bool prueba;
                // Si el boton de estado activo esta check entonces
                if (RBEstadoActivo.Checked == true && RBEstadoDesactivo.Checked == false)
                {
                    // el boleano esta en true
                    prueba = true;
                }
                else
                {
                    prueba = false;
                }
                // Creamos la variabla entera para poder ver si se pudo eliminar el profesional
                int retorna = _profesionalService.EliminarProfesional(idprofesional, prueba);
                // si el retorno es mayor a 0 entonces
                if (retorna > 0)
                {
                    // se pudo hacer correctamente
                    MessageBox.Show("Se ha Modificado el Profesional Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //sino
                else
                {
                    // no se pudo hacer nada
                    MessageBox.Show("NO se ha Modificado el Profesional Correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Ahora cargamos los datos de los profesionales, ya con el profesional eliminado 
                DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());

                // Ahora la parte de eliminar todos los vinculos del profesional con las especialidades

                    // Pasamos el retorno a un entero y le damos como parametro el id del profesional que vamos a eliminar para poder eliminar todos los vinculos
                    int retornamos = _profesionalespecialidadService.EliminarProfesional(idprofesional);
                    if(retornamos > 0)
                    {
                        MessageBox.Show("Se ha podido eliminar correctamente todas las especialidades del profesional elimiado","EXITO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar todas las especialidades del profesional elimiado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                int idprofesional = Convert.ToInt32(lblIDProfesionales.Text);
                if(idprofesional > 0)
                {
                    FRMAgregarEspecialidad form = new FRMAgregarEspecialidad(_especialidadService,_profesionalespecialidadService,idprofesional);
                    form.Show();

                    // Llamamos la funcion necesaria y le damos como parametro el entero creado
                    DGVEspecialidades.DataSource = _profesionalService.ListarEspecialidadesdelProfesional(idprofesional);
                }
                else
                {
                    MessageBox.Show("Por favor Selecciona un Profesional para poder Agregarle una Especialidad", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Agregar la Especialidad a el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                int idespecialidad = Convert.ToInt32(lblIDEspecialidades.Text);
                int idprofesional = Convert.ToInt32(lblIDProfesionales.Text);
                if(idespecialidad > 0 && idprofesional > 0)
                {
                    int retornamos = _profesionalespecialidadService.EliminarProfesional_Especialidad(idespecialidad, idprofesional);
                    if(retornamos > 0)
                    {
                        MessageBox.Show("Se ha podido Eliminar Correctamente la Especialidad al Profesional", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido Eliminar la Especialidad del Profesional", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Si el label id profesionales tiene algo entonces carga las especialidades del profesional seleccionado
                if (idprofesional > 0)
                {
                    // Llamamos la funcion necesaria y le damos como parametro el entero creado
                    DGVEspecialidades.DataSource = _profesionalService.ListarEspecialidadesdelProfesional(idprofesional);
                }
                //sino muestra todos las especialidades para poder crear o asignarse a un profesional
                else
                {
                    // Llamamos la funcion necesaria para mostrar todas las especialidades
                    DGVEspecialidades.DataSource = _especialidadService.ListarEspecialidades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar la Especialidad a el Profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiamos todos los textbox
                txtApellido.Clear();
                txtNombre.Clear();
                txtMatricula.Clear();
                txtTelefono.Clear();
                txtEmail.Clear();
                txtMatricula.Focus();
                // Limpiamos este label solo 
                lblIDProfesionales.Text = "0";

                // Ponemos en falso los dos Estados 
                RBEstadoDesactivo.Checked = false;
                RBEstadoActivo.Checked = false;


                // Limpiamos el DGV Especialidades para poder mostar todos
                DGVEspecialidades.DataSource = _especialidadService.ListarEspecialidades();

                // Estos los ponemos despues porque nos sigue seleccionando y mostrando la entidad en los labels
                lblIDEspecialidades.Text = "0";
                lblespecialidad.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar el Profesional y la Especialidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RBDesactivo_CheckedChanged(object sender, EventArgs e)
        {
            //  DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(false);
            DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
           // RBDesactivo.Checked = true;

            BackColor = Color.Red;

            //Botones
            btnAgregar.BackColor = Color.White;
            btnLimpiar.BackColor = Color.White;
            btnModificar.BackColor = Color.White;
            btnAgregar.BackColor = Color.White;

            // Labels Fore color
            lblIDProfesionales.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            // Labels Back Color
            lblIDProfesionales.BackColor = Color.Red;
            label1.BackColor = Color.Red;
            label2.BackColor = Color.Red;
            label3.BackColor = Color.Red;
            label4.BackColor = Color.Red;
            label5.BackColor = Color.Red;
            label6.BackColor = Color.Red;

        }
        private void RBActivo_CheckedChanged(object sender, EventArgs e)
        {
            //     DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(true);
            DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());
            BackColor = Color.Green;

                //Botones
                btnAgregar.BackColor = Color.White;
                btnLimpiar.BackColor = Color.White;
                btnModificar.BackColor = Color.White;
                btnAgregar.BackColor = Color.White;

                // Labels Fore color
                lblIDProfesionales.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                // Labels Back Color
                lblIDProfesionales.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label2.BackColor = Color.Green;
                label3.BackColor = Color.Green;
                label4.BackColor = Color.Green;
                label5.BackColor = Color.Green;
                label6.BackColor = Color.Green;
             //   DGVProfesionales.DataSource = _profesionalService.ListarProfesionales(CUAL());

            
        } 
      

        // Funciones que necesitamos dentro de la clase
        public bool CUAL()
        {
            bool activo = RBActivo.Checked;
            bool desactivo = RBDesactivo.Checked;
            if (activo == true && desactivo == false)
            {
                activo = true;
            }
            else if (desactivo == true && activo == false)
            {
                activo = false;
            }
            return activo;
        }
        private void LimpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtMatricula.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            lblIDProfesionales.Text = "0";
            txtMatricula.Focus();
            lblIDEspecialidades.Text = "0";
            lblespecialidad.Text = "";

            RBEstadoDesactivo.Checked = false;
            RBEstadoActivo.Checked = false;
            RBActivo.Checked = false;
            RBDesactivo.Checked = false;
        }

        private bool Verificar(int idespecialidad,int idprofesional)
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
            List<Profesionales_EspecialidadesBE> listaprincipal = _profesionalespecialidadService.ListarProfesionales_Especialidades();

            //Ahora tenemos que buscar con un LINQ
            bool existe = listaprincipal.Any(pe => pe.ID_Profesional == idprofesional && pe.ID_Especialidad == idespecialidad);
            return existe;

        }
    }
}
