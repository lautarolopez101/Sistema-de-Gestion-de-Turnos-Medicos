using BE;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BackupDAL
    {

        public static void CrearBackup(string databasename, string fullpathbak)
        {
            // Ojo: BACKUP no admite parámetros para nombre de DB/path como un SELECT normal,
            // por eso armamos el texto controlando que no tenga comillas raras.
            string safedb = databasename.Replace("]", "]]");
            string safepath = fullpathbak.Replace("'", "''");

            string query = $"BACKUP DATABASE [{safedb}] TO DISK = '{safepath}' WITH INIT, STATS = 10;";

            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                SqlCommand comand = new SqlCommand(query, conexion);
                comand.CommandTimeout = 0; //backups pueden tardar
                comand.ExecuteNonQuery();

                
            }

        }
    }
}
