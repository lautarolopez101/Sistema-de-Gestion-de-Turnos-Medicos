using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HistorialDAL
    {

        public static int AgregarHistorial(HistorialBE historial)
        {
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Historial (ID_Historial,Diagnostico,Indicaciones,Notas) values ('"+historial.ID_Historial+"','" + historial.Diagnostico + "','" + historial.Indicaciones + "','" + historial.Notas + "')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }

    }
}
