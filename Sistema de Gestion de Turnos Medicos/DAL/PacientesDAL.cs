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
    public class PacientesDAL
    {
        public static int AgregarPersona(PacienteBE paciente)
        {
            int retorna = 0;

            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Pacientes (DNI,Nombre,Apellido,FechaNacimiento,Telefono,Email) values('" + paciente.DNI + "','" + paciente.Nombre + "','" + paciente.Apellido + "','" + paciente.FechaNacimiento + "','" + paciente.Telefono + "','" + paciente.Email + "')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }
    }
}
