using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProfesionalDAL
    {
        /* 
         Si no hay comentarios explicando el codigo entrar a PacienteDAL.cs
         */
        public static int AgregarProfesional(ProfesionalBE profesional)
        {
            int retorna = 0;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Profesionales (Matricula,Nombre,Apellido,Telefono,Email) values ('" + profesional.Matricula + "','"+profesional.Nombre+"','"+profesional.Apellido+"','"+profesional.Telefono+"','"+profesional.Email+"')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }
        public static int ModificarProfesional(ProfesionalBE profesional)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Update dbo.Profesionales set " +
                    "Matricula = '" + profesional.Matricula + "'," +
                    "Nombre = '" + profesional.Nombre + "', " +
                    "Apellido = '" + profesional.Apellido + "', " +
                    "Telefono = '" + profesional.Telefono + "'," +
                    "Email = '" + profesional.Email + "'," +
                    "Activo = '" + profesional.Activo + "'" +
                    "Where ID_Profesional = " + profesional.ID_Profesional;
                SqlCommand comand = new SqlCommand(query, conexion);   
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }
        public static int EliminarProfesional(ProfesionalBE profesional)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "delete from dbo.Profesionales where ID_Profesional = " + profesional.ID_Profesional;
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }
        public static List<ProfesionalBE> ListarProfesionales(bool cual)
        {
            List<ProfesionalBE> profesionales = new List<ProfesionalBE>();
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "select * from Profesionales where Activo = '" +cual + "'";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    ProfesionalBE profesional = new ProfesionalBE();
                    profesional.ID_Profesional = Convert.ToInt32(reader["ID_Profesional"].ToString());
                    profesional.Matricula = reader["Matricula"].ToString();
                    profesional.Nombre = reader["Nombre"].ToString();
                    profesional.Apellido = reader["Apellido"].ToString();
                    profesional.Telefono = reader["Telefono"].ToString();
                    profesional.Email = reader["Email"].ToString();
                    profesional.Activo = Convert.ToBoolean(reader["Activo"].ToString());
                    profesionales.Add(profesional);
                }
                conexion.Close();
            }
            return profesionales;
        }
        public static List<ProfesionalBE> ObtenerProfesionales()
        {
            List<ProfesionalBE> profesionales = new List<ProfesionalBE>();
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "select * from Profesionales";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    ProfesionalBE profesional = new ProfesionalBE();
                    profesional.ID_Profesional = Convert.ToInt32(reader["ID_Profesional"].ToString());
                    profesional.Matricula = reader["Matricula"].ToString();
                    profesional.Nombre = reader["Nombre"].ToString();
                    profesional.Apellido = reader["Apellido"].ToString();
                    profesional.Telefono = reader["Telefono"].ToString();
                    profesional.Email = reader["Email"].ToString();
                    profesional.Activo = Convert.ToBoolean(reader["Activo"].ToString());
                    profesionales.Add(profesional);
                }
                conexion.Close();
            }
            return profesionales;
        }
    }
}
