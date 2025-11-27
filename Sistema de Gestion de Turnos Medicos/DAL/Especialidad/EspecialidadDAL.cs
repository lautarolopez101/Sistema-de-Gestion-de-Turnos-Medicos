using BE;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EspecialidadDAL
    {
        // Para poder agregar una especialidad a la base de datos obtenemos lo que nos previamente nos da el objeto de EspecialidadBE y lo insertamos en la base de datos
        public static int AgregarEspecialidad(EspecialidadBE especialidad)
        {
            // Creamos un entero con el valor 0 por default, para luego verificar si se hizo el insert
            int retorna = 0;
            // Usando la conexion "TAL" obtenida del SqlConnectionFactory
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                //Creamos el query necesario para luego ejecutarlo
                string query = "insert into Especialidades (Especialidad,Descripcion) values ('" + especialidad.Especialidad + "','" + especialidad.Descripcion + "')";
                // Creamos el comando con el query y la conexion
                SqlCommand comand = new SqlCommand(query, conexion);
                // Si se efectuo el comando nos va a devolver un entero X>0 o sino se pudo un X=0
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conexion "TAL"
                conexion.Close();
            }
            // Devolvemos el entero que nos estaba pidiendo
            // Si el entero es X=0 no se pudo insertar, si es X>0 se pudo insertar
            return retorna;
        }

        // Para modificar una especialidad existente en la base de datos
        public static int ModificarEspecialidad(EspecialidadBE especialidad)
        {
            //  Creamos un entero con el valor 0 por default
            int retorna = 0;
            // Usando la conexion "TAL" obtenida del SqlConnectionFactory
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos el query necesario para luego ejecutarlo
                string query = "update dbo.Especialidades set " +
                    "Especialidad = '" + especialidad.Especialidad + "', " +
                    "Descripcion = '" + especialidad.Descripcion + "' " +
                    "where ID_Especialidad = " + especialidad.ID_Especialidad;
                // Creamos el comando con el query y la conexion
                SqlCommand comand = new SqlCommand(query, conexion);
                // Si se efectuo el comando nos va a devolver un entero X>0 o sino se pudo un X=0
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conexion "TAL"
                conexion.Close();
            }
            // Devolvemos el entero que nos estaba pidiendo
            return retorna;
        }

        public static int EliminarEspecialidad(EspecialidadBE especialidad)
        {
            //  Creamos un entero con el valor 0 por default
            int retorna = 0;
            // Usando la conexion "TAL" obtenida del SqlConnectionFactory
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos el query necesario para luego ejecutarlo
                // Le damos el valor del entero ID_Especialidad que nos llega por parametro
                // para poder eliminar la especialidad correspondiente
                string query = "delete from dbo.Especialidades where ID_Especialidad = " + especialidad.ID_Especialidad ;
                // Creamos el comando con el query y la conexion
                SqlCommand comand = new SqlCommand(query, conexion);
                // Si se efectuo el comando nos va a devolver un entero X>0 o sino se pudo un X=0
                retorna = comand.ExecuteNonQuery();
                // Cerramos la conexion "TAL"
                conexion.Close();
            }
            // Devolvemos el entero que nos estaba pidiendo
            return retorna;
        }

        // Para poder mostrar las especialidades que tenemos en la base de datos usamos esta funcion
        public static List<EspecialidadBE> ObtenerEspecialidades()
        {
            // Creamos una lista de especialidades vacia
            List<EspecialidadBE> especialidades = new List<EspecialidadBE>();
            // Usando la conexion "TAL" obtenida del SqlConnectionFactory
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos el query necesario para luego ejecutarlo
                string query = "select * from Especialidades";
                // Creamos el comando con el query y la conexion para poder usarlos
                SqlCommand comand = new SqlCommand(query, conexion);
                // Leemos el comando ejecutado
                SqlDataReader reader = comand.ExecuteReader();
                // Mientras haya algo que leer seguimos leyendo
                while (reader.Read())
                {
                    // Creamos un nuevo objeto de EspecialidadBE y le asignamos los valores que leemos de la base de datos
                    EspecialidadBE especialidad = new EspecialidadBE();
                    especialidad.ID_Especialidad = Convert.ToInt32(reader["ID_Especialidad"]);
                    especialidad.Especialidad = reader["Especialidad"].ToString();
                    especialidad.Descripcion = reader["Descripcion"].ToString();
                    especialidades.Add(especialidad);
                }
                // Cerramos la conexion "TAL"
                conexion.Close();
            }
            // Devolvemos la lista de especialidades
            return especialidades;
        }
        public static EspecialidadBE BuscarPorNombre(string nombre)
        {
            EspecialidadBE especialidad = new EspecialidadBE();
            // Usando la conexion "TAL" obtenida del SqlConnectionFactory
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos el query necesario para luego ejecutarlo
                string query = "select * from Especialidades where Especialidad = '" + nombre + "'";
                // Creamos el comando con el query y la conexion para poder usarlos
                SqlCommand comand = new SqlCommand(query, conexion);
                // Leemos el comando ejecutado
                SqlDataReader reader = comand.ExecuteReader();
                // Mientras haya algo que leer seguimos leyendo
                while (reader.Read())
                {
                    // Creamos un nuevo objeto de EspecialidadBE y le asignamos los valores que leemos de la base de datos
                    
                    especialidad.ID_Especialidad = Convert.ToInt32(reader["ID_Especialidad"]);
                    especialidad.Especialidad = reader["Especialidad"].ToString();
                    especialidad.Descripcion = reader["Descripcion"].ToString();
                }
                // Cerramos la conexion "TAL"
                conexion.Close();
            }
            // Devolvemos la lista de especialidades
            return especialidad;
        }
    }
}
