using BE;
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
        public static int AgregarEspecialidad(EspecialidadBE especialidad)
        {
            int retorna = 0;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Especialidades (Especialidad,Descripcion) values ('"+especialidad.Especialidad+"','"+especialidad.Descripcion+"')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }

    }
}
