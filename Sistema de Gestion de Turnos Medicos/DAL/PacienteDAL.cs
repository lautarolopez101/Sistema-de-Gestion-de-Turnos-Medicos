using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PacienteDAL
    {
        public static int AgregarPersona(PacienteBE paciente)
        {
            int retorna = 0;

            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Pacientes (ID_Paciente,DNI,Nombre,Apellido,FechaNacimiento,Telefono,Email) values('"+paciente.ID_Paciente+"','" + paciente.DNI + "','" + paciente.Nombre + "','" + paciente.Apellido + "','" + paciente.FechaNacimiento + "','" + paciente.Telefono + "','" + paciente.Email + "')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
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
                    paciente.ID_Paciente = Convert.ToInt32(reader["ID_Paciente"]);
                    paciente.DNI = reader["DNI"].ToString();
                    paciente.Nombre = reader["Nombre"].ToString();
                    paciente.Apellido = reader["Apellido"].ToString();
                    paciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    paciente.Telefono = reader["Telefono"].ToString();
                    paciente.Email = reader["Email"].ToString();
                    lista.Add(paciente);
                }
                conexion.Close();
            }
            
            return lista;
        }
    }
}
