using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Profesionales_EspecialidadesDAL
    {

        public static int AgregarProfesional_Especialidad(Profesionales_EspecialidadesBE nodo)
        {
            int retorna = 0;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Insert into Profesionales_Especialidades " +
                    " (ID_Especialidad,ID_Profesional) values ('" + nodo.ID_Especialidad + "',' " + nodo.ID_Profesional + "')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }

        public static int ModificarProfesional_Especialidad(Profesionales_EspecialidadesBE nodo)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Update Profesionales_Especialidades set ID_Especialidad = ' " + nodo.ID_Especialidad + "'," + "ID_Profesional = '" + nodo.ID_Profesional + "'";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }

        public static int EliminarProfesional_Especialidad(Profesionales_EspecialidadesBE nodo)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "delete from dbo.Profesionales_Especialidades  where ID_Especialidad = " + nodo.ID_Especialidad + " AND  ID_Profesional = " + nodo.ID_Profesional;
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }

        public static List<Profesionales_EspecialidadesBE> ListarProfesionalesEspecialidades()
        {
            List<Profesionales_EspecialidadesBE> lista = new List<Profesionales_EspecialidadesBE>();
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "select * from Profesionales_Especialidades";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Profesionales_EspecialidadesBE nodo = new Profesionales_EspecialidadesBE();
                    nodo.ID_Especialidad = reader.GetInt32(0);
                    nodo.ID_Profesional = reader.GetInt32(1);
                    nodo.CreatedAtUtc = reader.GetDateTime(2);
                    lista.Add(nodo);
                }
                conexion.Close();
            }
            return lista;
        }
    }
}
