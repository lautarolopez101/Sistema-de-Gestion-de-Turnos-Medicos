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

        public static int CrearUsuario(UsuarioBE usuario)
        {
            int retorna;
            using(SqlConnection conexion= SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Insert into Usuarios (Username,PasswordHash,Email)"
                    + "values ('" + usuario.Username + "','" + usuario.PasswordHash + "','" + usuario.Email + "')";
                SqlCommand comand = new SqlCommand(query, conexion);   
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }

        public static int AgregarIDPaciente(UsuarioBE usuario)
        {
            int retorna;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Update dbo.Usuarios set ID_Paciente = '" + usuario.ID_Paciente + "' Where ID_Usuario ="+ usuario.ID;
                SqlCommand comand = new SqlCommand( query, conexion);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }
        
        public static List<UsuarioBE> Buscar()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Select *From Usuarios";
                SqlCommand comand = new SqlCommand(query,conexion);
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    UsuarioBE usuario = new UsuarioBE();
                    usuario.ID = reader.GetInt32(0);
                    usuario.Username = reader.GetString(1);
                    usuario.PasswordHash = reader.GetString(2);
                    usuario.Estado = reader.GetBoolean(3);
                    usuario.LastLogin = reader.GetDateTime(4);
                    usuario.Email = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                    {
                        usuario.ID_Paciente = reader.GetInt32(6);
                    }
                    if(!reader.IsDBNull(7))
                    {
                        usuario.ID_Profesional = reader.GetInt32(7);
                    }
                    usuario.CreatedAtUtc = reader.GetDateTime(8);
                    if (!reader.IsDBNull(9))
                    {
                        usuario.UpdatedAtUtc = reader.GetDateTime(9);
                    }
                    lista.Add(usuario);
                }
                conexion.Close();
            }
            return lista;
        }

        public static UsuarioBE ObtenterPorUsername(string username)
        {
            UsuarioBE usuario = null;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "SELECT *FROM Usuarios WHERE Username = '" + username + "'";
                SqlCommand comand =new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new UsuarioBE();
                    usuario.ID = reader.GetInt32(0);
                    usuario.Username = reader.GetString(1);
                    usuario.PasswordHash = reader.GetString(2);
                    usuario.Estado = reader.GetBoolean(3);
                    usuario.LastLogin = reader.GetDateTime(4);
                    usuario.Email = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                    { 
                        usuario.ID_Paciente = reader.GetInt32(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        usuario.ID_Profesional = reader.GetInt32(7);
                    }

                    usuario.CreatedAtUtc = reader.GetDateTime(8);
                    if(!reader.IsDBNull(9))
                    {
                        usuario.UpdatedAtUtc = reader.GetDateTime(9);
                    }
                }
                conexion.Close();
            }
            return usuario;
        }
        

        public static UsuarioBE ObtenterPorID(int idusuario)
        {
            UsuarioBE usuario = null;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "SELECT *FROM Usuarios WHERE ID_Usuario = '" + idusuario + "'";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new UsuarioBE();
                    usuario.ID = reader.GetInt32(0);
                    usuario.Username = reader.GetString(1);
                    usuario.PasswordHash = reader.GetString(2);
                    usuario.Estado = reader.GetBoolean(3);
                    usuario.LastLogin = reader.GetDateTime(4);
                    usuario.Email = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                    {
                        usuario.ID_Paciente = reader.GetInt32(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        usuario.ID_Profesional = reader.GetInt32(7);
                    }

                    usuario.CreatedAtUtc = reader.GetDateTime(8);
                    if (!reader.IsDBNull(9))
                    {
                        usuario.UpdatedAtUtc = reader.GetDateTime(9);
                    }
                }
                conexion.Close();
            }
            return usuario;
        }

        public static List<FamiliaBE> ListaFamiliasDelUsuario(int idusuario)
        {
            List<FamiliaBE> listafamilia = new List<FamiliaBE>();
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {

                string query = "SELECT f.ID_Familia, f.Nombre, f.Descripcion, f.Activo " +
                "FROM Usuario_Familia uf " +
                "INNER JOIN Familias f ON uf.ID_Familia = f.ID_Familia " +
                "WHERE uf.ID_Usuario = @id";

                SqlCommand comand = new SqlCommand(query, conexion);

                comand.Parameters.AddWithValue("@id", idusuario);

                SqlDataReader reader = comand.ExecuteReader();

                while(reader.Read())
                {
                    FamiliaBE familia = new FamiliaBE();
                    familia.ID_Familia = reader.GetInt32(0);
                    familia.Nombre = reader.GetString(1);
                    familia.Descripcion = reader.GetString(2);
                    familia.Activo = reader.GetBoolean(3);
                    listafamilia.Add(familia);
                }
                conexion.Close();
            }
            return listafamilia;
        }

        public static List<PatenteBE> ListarPatentesDirectasDelUsuario(int idusuario)
        {
            List <PatenteBE> lista = new List<PatenteBE>();
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                
                string query = "SELECT p.ID_Patente, p.Nombre, p.Descripcion, p.Activo " +
                "FROM Usuario_Patente up " +
                "INNER JOIN Patentes p ON up.ID_Patente = p.ID_Patente " +
                "WHERE up.ID_Usuario = @id";

                SqlCommand comand = new SqlCommand(query, conexion);
                comand.Parameters.AddWithValue("@id", idusuario);
                SqlDataReader reader = comand.ExecuteReader();

                while(reader.Read())
                {
                    PatenteBE patente = new PatenteBE();
                    patente.ID_Patente = reader.GetInt32(0);
                    patente.Nombre = reader.GetString(1);
                    patente.Descripcion = reader.GetString(2);
                    patente.Activo = reader.GetBoolean(3);
                    lista.Add(patente);
                }
                conexion.Close();
            }
            return lista;
        }

        public static int Logout(UsuarioBE usuario)
        {
            int retorna;
            using(SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "Update Usuarios set LastLogin = @lastlogin Where ID_Usuario = @idusuario";
                SqlCommand comand = new SqlCommand(query, conexion);
                comand.Parameters.AddWithValue("@lastlogin", usuario.LastLogin);
                comand.Parameters.AddWithValue("@idusuario", usuario.ID);
                retorna = comand.ExecuteNonQuery();
                conexion.Close();
            }
            return retorna;
        }

    }
}
