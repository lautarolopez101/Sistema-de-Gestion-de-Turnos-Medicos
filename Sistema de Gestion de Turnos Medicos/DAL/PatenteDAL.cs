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
        // Las patentes solamente necesitamos traerlas para saber y diferenciarlas nomas
        public static List<PatenteBE> ListarPatentes()
        {
            // creamos una lista de patentes
            List<PatenteBE> lista = new List<PatenteBE>();
            // usando la conexion "TAL" 
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // abrimos la conexion
                conexion.Open();
                // creamos el query necesario para traer la tabla entera de patentes
                string query = "SELECT * FROM Patentes";
                // creamos el comando necesario para que ejecute el query en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // leemos toda la tabla
                SqlDataReader reader = comand.ExecuteReader();

                // mientras tenga para leer entonces...
                while (reader.Read())
                {
                    // creamos la entidad de patente para poder asignarle los datos de la base de datos
                    PatenteBE patente = new PatenteBE();
                    patente.ID_Patente = reader.GetInt32(0);
                    patente.Nombre = reader.GetString(1);
                    patente.Descripcion = reader.GetString(2);
                    patente.Activo = reader.GetBoolean(3);
                }
                // cerramos la conexion 
                conexion.Close();
            }
            // devolvemos la lista entera de patentes
            return lista;
        }
    }
}
