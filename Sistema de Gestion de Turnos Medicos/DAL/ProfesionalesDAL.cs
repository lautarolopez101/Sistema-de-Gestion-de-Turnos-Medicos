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
    public class ProfesionalesDAL
    {

        public static int AgregarProfesional(ProfesionalBE profesional)
        {
            int retorna = 0;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Profesionales (Matricula,Nombre,Apellido,ID_Especialidad,Telefono,Email,Activo) values ('" + profesional.Matricula + "','"+profesional.Nombre+"','"+profesional.Apellido+"','"+profesional.ID_Especialidad+"','"+profesional.Telefono+"','"+profesional.Email+"')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }

    }
}
