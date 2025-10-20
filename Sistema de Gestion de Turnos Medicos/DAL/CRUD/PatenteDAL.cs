using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CRUD
{
    public class PatenteDAL
    {
        public static List<PatenteBE> ListarPatentes()
        {
            List<PatenteBE> lista = new List<PatenteBE>();
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                conexion.Open();

                string query = "SELECT * FROM Patentes";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    PatenteBE patente = new PatenteBE();
                    patente.ID_Patente = reader.GetInt32(0);
                    patente.Nombre = reader.GetString(1);
                    patente.Descripcion = reader.GetString(2);
                    patente.Activo = reader.GetBoolean(3);
                }
                conexion.Close();
            }
            return lista;
        }
    }
}
