using BE;
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
        public static int AgregarPaciente(PacienteBE paciente)
        {
            int retorna = 0;

            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Pacientes (DNI,Nombre,Apellido,FechaNacimiento,Telefono,Email) values('" + paciente.DNI + "','" + paciente.Nombre + "','" + paciente.Apellido + "','" + paciente.FechaNacimiento + "','" + paciente.Telefono + "','" + paciente.Email + "')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            
            return retorna;
        }


        public static int EliminarPaciente(int id)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "DELETE FROM dbo.Pacientes WHERE ID_Paciente = " + id;
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            
            return retorna;
        }

        public static int ModificarPaciente(PacienteBE paciente)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query =
             "UPDATE dbo.Pacientes SET " +
             "DNI = '" + paciente.DNI + "', " +
             "Nombre = '" + paciente.Nombre + "', " +
             "Apellido = '" + paciente.Apellido + "', " +
             "FechaNacimiento = '" + paciente.FechaNacimiento.ToString("yyyy-MM-dd") + "', " +
             "Telefono = '" + paciente.Telefono + "', " +
             "Email = '" + paciente.Email + "' " +
             "WHERE ID_Paciente = " + paciente.ID_Paciente;
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            
            return retorna;
        }
        public static List<PacienteBE> ListarPacientes()
        {
            List<PacienteBE> lista = new List<PacienteBE>();
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "select * from Pacientes";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    PacienteBE paciente = new PacienteBE();
                    paciente.ID_Paciente = reader.GetInt32(0);
                    paciente.DNI = reader.GetString(1);
                    paciente.Nombre = reader.GetString(2);
                    paciente.Apellido = reader.GetString(3);

                    if (!reader.IsDBNull(4))
                        paciente.FechaNacimiento = reader.GetDateTime(4);
                    else
                        paciente.FechaNacimiento = default; // or a default value
                    paciente.Telefono = reader.GetString(5);
                    paciente.Email = reader.GetString(6);
                    paciente.CreatedAtUtc = reader.GetDateTime(7);
                    if (!reader.IsDBNull(8))
                    {
                        paciente.UpdatedAtUtc = reader.GetDateTime(8);
                    }
                    else
                    {
                        paciente.UpdatedAtUtc = default; // or a default value
                    }
                        lista.Add(paciente);
                }
                conexion.Close();
            }
            
            return lista;
        }
    }
}
