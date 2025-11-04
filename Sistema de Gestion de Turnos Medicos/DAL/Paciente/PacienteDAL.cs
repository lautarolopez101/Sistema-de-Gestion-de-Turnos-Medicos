using BE;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PacienteDAL
    {
        // Cuando necesitamos dar de ALTA a un paciente entonces usamos esta funcion
        public static int AltaPaciente(PacienteBE paciente)
        {
            // Creamos un entero con el valor 0 por default
            int retorna = 0;
            // Usando la conexion dicha "TAL"
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                //Creamos el query necesario para luego ejecutarlo
                string query = "insert into Pacientes (DNI,Nombre,Apellido,FechaNacimiento,Telefono,Email,Estado)" +
                    "values('" + paciente.DNI + "','" + paciente.Nombre + "','" + paciente.Apellido + "','" + paciente.FechaNacimiento + "','" + paciente.Telefono + "','" + paciente.Email + "','" + paciente.Estado +  "')";
                // Creamos un comando con el query necesario en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // Si se efectuo el comando nos va a devolver un entero X>0 o sino se pudo un X=0
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conxexion "TAL"
                conexion.Close();
            }
            // Devolvemos el entero que nos estaba pidiendo
            return retorna;
        }

      
        // Cuando queremos hacer la baja de un paciente entonces necesitamos este metodo para poder efectuarlo
        public static int BajaPaciente(PacienteBE paciente)
        {
            // Creamos un entero que el valor por default es 0 
            int retorna = 0;
            // Pisamos el estado del paciente a desactivado entonces 
           // paciente.Estado = "Desactivado";
            // Usando la conexion "TAL"
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                //Creamos el query para poder ejecutar
                string query = "UPDATE Pacientes set " +
                    "DNI = '" + paciente.DNI + "'," +
                    "Nombre = '" + paciente.Nombre + "'," +
                    "Apellido = '" + paciente.Apellido + "'," +
                    "FechaNacimiento = '" + paciente.FechaNacimiento.ToString("yyyy-MM-dd") + "'," +
                    "Email = '" + paciente.Email + "'," +
                    "Estado = '" + paciente.Estado + "'" +
                    " WHERE ID_Paciente = '" + paciente.ID_Paciente + "'";
                // Creamos un comando y como parametros le damos el query necesario en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // Si el comando se ejecuto bien entonces el valor del entero de retorna seria x>0
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conexion porque no es necesario dejarlo abierta si solamente ejecutamos un SOLO query
                conexion.Close();
            }
            // Devolvemos el entero para que nos diga si se hizo el cambio o no 
            return retorna;
        }

        //Cuando modificamos un paciente necesitamos esta funcion que devuelve un entero para ver si se pudo concretar o no
        public static int ModificarPaciente(PacienteBE paciente)
        {
            // Creamos un entero que va a tener un 0 por default
            int retorna = 0;
            // Usando la funcion de obtener conexion hacemos lo que necesitamos
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Primero creamos el query necesario para lo que nos piden 
                string query =
             "UPDATE dbo.Pacientes SET " +
             "DNI = '" + paciente.DNI + "', " +
             "Nombre = '" + paciente.Nombre + "', " +
             "Apellido = '" + paciente.Apellido + "', " +
             "FechaNacimiento = '" + paciente.FechaNacimiento.ToString("yyyy-MM-dd") + "', " +
             "Telefono = '" + paciente.Telefono + "', " +
             "Email = '" + paciente.Email + "'," +
             "Estado = '" + paciente.Estado + "'," +
             "UpdateAtUtc = '" + paciente.UpdatedAtUtc.ToString("yyyy-MM-dd") + "'"+
             "WHERE ID_Paciente = '" + paciente.ID_Paciente + "'";
                // si el estado del paciente es "ACTIVO" entonces 
                // ahora ejecutamos en el comando el query1 en la conexion "TAL"
                SqlCommand comando = new SqlCommand(query, conexion);
                // Si se ejecuto bien nos devuelve el entero x>0 entonces se pudo ejecutar, sino no se ejecuto y hubo un error
                retorna = comando.ExecuteNonQuery();
                // Cerramos la conexion para que consuma menos recursos, total si lo necesitamos de vuelta lo abrimos 
                conexion.Close();
            }
            // devuelve el entero RETORNA 
            return retorna;
        }
        // Usamos el metodo para poder agregar los pacientes en el DGV
        public static List<PacienteBE> ListarPacientesEstado(string cual)
        {
            // Creamos una lista de pacientes que va a estar vacia
            List<PacienteBE> lista = new List<PacienteBE>();
            // Usando la conexion "TAL"
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Hacemos un query para seleccionar la tabla de pacientes donde vemos el estado que nos pide para hacer un filtro
                string query = "SELECT * FROM Pacientes WHERE Estado = '" + cual + "'";
                // Creamos un comando que le vamos a dar el query necesario en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // Vamos a leer el comando cuando nos ejecuta 
                SqlDataReader reader = comand.ExecuteReader();
                // Mientras lee el comando 
                while (reader.Read())
                {
                    // Creamos un nuevo paciente y le damos los datos dependiendo la columna
                    PacienteBE paciente = new PacienteBE();
                    paciente.ID_Paciente = reader.GetInt32(0);
                    paciente.DNI = reader.GetString(1);
                    paciente.Nombre = reader.GetString(2);
                    paciente.Apellido = reader.GetString(3);
                    // Si la columna 4 no esta vacia entonces 
                    if (!reader.IsDBNull(4))
                        // Agregamos la fecha de nacimiento al paciente "X"
                        paciente.FechaNacimiento = reader.GetDateTime(4);
                    else
                        //Sino ponemos un valor por defecto y listo 
                        paciente.FechaNacimiento = default; // un valor por defecto
                    paciente.Telefono = reader.GetString(5);
                    paciente.Email = reader.GetString(6);
                    paciente.Estado = reader.GetString(7);
                    paciente.CreatedAtUtc = reader.GetDateTime(8);
                    paciente.UpdatedAtUtc = reader.IsDBNull(9)
                        ? default(DateTime)
                        : reader.GetDateTime(9);
                    // agregamos el paciente a la dicha lista
                        lista.Add(paciente);
                }
                //Cerramos la conexion porque ya no va a ser necesaria
                conexion.Close();
            }
            // Devolvemos la lista pedida
            return lista;
        }

        public static PacienteBE ObtenerPaciente(int idpaciente)
        {
            PacienteBE paciente = new PacienteBE();
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Select * from Pacientes where ID_Paciente = " + idpaciente;
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                if (reader.Read())
                {
                    paciente.ID_Paciente = Convert.ToInt32(reader["ID_Paciente"].ToString());
                    paciente.DNI = reader.GetString(1);
                    paciente.Nombre = reader.GetString(2);
                    paciente.Apellido = reader.GetString(3);
                    paciente.FechaNacimiento = reader.GetDateTime(4);
                    paciente.Telefono = reader.GetString(5);
                    paciente.Email = reader.GetString(6);
                    paciente.Estado = reader.GetString(7);
                    paciente.CreatedAtUtc = reader.GetDateTime(8);
                    if (!reader.IsDBNull(9))
                    {
                        paciente.UpdatedAtUtc = reader.GetDateTime(9);
                    }
                }
                conexion.Close();
            }
            return paciente;
        }

        public static List<PacienteBE> ObtenerTodos()
        {
            // Creamos una lista de pacientes que va a estar vacia
            List<PacienteBE> lista = new List<PacienteBE>();
            // Usando la conexion "TAL"
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Hacemos un query para seleccionar la tabla de pacientes donde vemos el estado que nos pide para hacer un filtro
                string query = "SELECT * FROM Pacientes";
                // Creamos un comando que le vamos a dar el query necesario en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // Vamos a leer el comando cuando nos ejecuta 
                SqlDataReader reader = comand.ExecuteReader();
                // Mientras lee el comando 
                while (reader.Read())
                {
                    // Creamos un nuevo paciente y le damos los datos dependiendo la columna
                    PacienteBE paciente = new PacienteBE();
                    paciente.ID_Paciente = reader.GetInt32(0);
                    paciente.DNI = reader.GetString(1);
                    paciente.Nombre = reader.GetString(2);
                    paciente.Apellido = reader.GetString(3);
                    // Si la columna 4 no esta vacia entonces 
                    if (!reader.IsDBNull(4))
                        // Agregamos la fecha de nacimiento al paciente "X"
                        paciente.FechaNacimiento = reader.GetDateTime(4);
                    else
                        //Sino ponemos un valor por defecto y listo 
                        paciente.FechaNacimiento = default; // un valor por defecto
                    paciente.Telefono = reader.GetString(5);
                    paciente.Email = reader.GetString(6);
                    paciente.Estado = reader.GetString(7);
                    paciente.CreatedAtUtc = reader.GetDateTime(8);
                    paciente.UpdatedAtUtc = reader.IsDBNull(9)
                        ? default(DateTime)
                        : reader.GetDateTime(9);
                    // agregamos el paciente a la dicha lista
                    lista.Add(paciente);
                }
                //Cerramos la conexion porque ya no va a ser necesaria
                conexion.Close();
            }
            // Devolvemos la lista pedida
            return lista;
        }

        // Funcionalidades del Paciente pero que no son ABM

        // Funcion para ver si el paciente tien el estado en "DESACTIVADO"
        public static int DesactivarPaciente(PacienteBE paciente)
        {
            // Creamos un entero para ver si se efectuo el comando o no
            int retorna = 0;
            // Usando la conexion en dicha "TAL"
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos el query para luego poder insertarlo
                string query = "insert into HistorialCambiosEstadoPacientes (ID_Paciente,Estado) " +
                    "VALUES ('" + paciente.ID_Paciente + "','" + paciente.Estado + "')";
                // Creamos un comando con el query necesario en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // Y con el entero verificamos si se ejecuto el comando o no
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conexion porque ya no va a ser necesaria 
                conexion.Close();
            }
            // Devolvemos el entero
            return retorna;
        }

        // Para volver a activar un paciente necesitamos algunos datos del paciente
        public static int ActivoPaciente(PacienteBE paciente)
        {
            // Creamos un entero para poder devolverlo de vuelta mas adelante
            int retorna =0;
            // Usando la conexion de dicha "TAL"
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos un string que seria el query para el sql, con update
                string query = "UPDATE dbo.Pacientes SET " +
                 "Estado = '" + paciente.Estado + "' " +
                 "WHERE ID_Paciente = '" + paciente.ID_Paciente + "'" +
                  "insert into HistorialCambiosEstadoPacientes(ID_Paciente,Estado) " +
                  "Values ( ' " + paciente.ID_Paciente + "','" + paciente.Estado + "')";
                // creamos un comando nuevo para meterle el query creado a la conexion "TAL"
                SqlCommand comand = new SqlCommand( query, conexion);
                // si el comando se ejecuto correctamente me devuelve un entero de X>0 si salio mal me devuelve un X=0
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conexin para que consuma menos recursos
                conexion.Close();
            }
            // Devolvemos el entero 
            return retorna;
        }
    }
}
