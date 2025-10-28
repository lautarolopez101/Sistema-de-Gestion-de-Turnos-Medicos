using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FamiliaDAL
    {
        public static List<PatenteBE> ListarPatentesPorFamilia (int idfamilia)
        {
            List<PatenteBE> lista = new List<PatenteBE> ();

            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                conexion.Open ();
                string query = "SELECT p.ID_Patente, p.Nombre, p.Descripcion , p.Activo " +
                    "FROM Familia_Patente fp " +
                    "INNER JOIN Patentes p ON fp.ID_Patente = p.ID_Patente " +
                    "WHERE fp.ID_Familia = " + idfamilia;
                SqlCommand comand = new SqlCommand (query, conexion);
                SqlDataReader reader = comand.ExecuteReader ();
                while (reader.Read ())
                {
                    PatenteBE patente = new PatenteBE ();
                    patente.ID_Patente = reader.GetInt32(0);
                    patente.Nombre  = reader.GetString(1);
                    patente.Descripcion = reader.GetString(2);
                    patente.Activo = reader.GetBoolean(3);

                    lista.Add (patente);
                }
                conexion.Close();
            }
            return lista;
        }
    }
}
