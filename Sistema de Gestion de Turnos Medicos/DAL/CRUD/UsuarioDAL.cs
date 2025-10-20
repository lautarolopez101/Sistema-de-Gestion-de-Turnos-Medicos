using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CRUD
{
    public class UsuarioDAL
    {
        public UsuarioBE ObtenterPorUsername(string username)
        {
            UsuarioBE usuario = null;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT *FROM Usuarios WHERE Username = '" + username + "'";
                SqlCommand comand =new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new UsuarioBE();
                    usuario.ID = reader.GetInt32(0);
                    usuario.Username = reader.GetString(1);
                    usuario.PasswordHash = reader.GetString(2);
                    usuario.Estado = reader.GetString(3);
                    usuario.LastLogin = reader.GetDateTime(4);
                    usuario.Email = reader.GetString(5);

                    usuario.ID_Paciente = reader.GetInt32(6);
                    usuario.ID_Profesional = reader.GetInt32(7);

                    usuario.CreatedAtUtc = reader.GetDateTime(8);
                    usuario.UpdatedAtUtc = reader.GetDateTime(9);
                }
                conexion.Close();
            }
            return usuario;
        }
    }
}
