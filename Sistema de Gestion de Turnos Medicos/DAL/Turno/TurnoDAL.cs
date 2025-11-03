using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TurnoDAL
    {
        public static int AgregarTurnos(TurnoBE turno)
        {
            // La idea de esta funcion es que se pueda hacer desde un Usuario Paciente o un Usuario Recepcion, el Alta para un Admin no le veo mucho sentido
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "insert into Turnos (ID_Paciente,ID_Profesional,Estado,FechaHora,Motivo,Observaciones) values ('" + turno.ID_Profesional + "','" + turno.ID_Paciente + "','" + turno.Estado + "','" + turno.FechaHora + "','" + turno.Motivo + "','" + turno.Observaciones + "')";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }
        public static int ModificarTurnos(TurnoBE turno)
        {
            // La idea de esta funcion es que se pueda hacer desde un Usuario Paciente o un Usuario Recepcion, el Alta para un Admin no le veo mucho sentido
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "UPDATE dbo.Turnos set "+
                    "ID_Profesional = '" + turno.ID_Profesional +"',"+
                    "ID_Paciente = '" + turno.ID_Paciente + "'," +
                    "Motivo = '" + turno.Motivo + "'," +
                    "FechaHora = '" + turno.FechaHora + "'," +
                    "Observaciones = '" + turno.Motivo + "',"+ 
                    "Estado = '"+ turno.Estado + "'" +
                    "Where ID_Turno = '" + turno.ID_Turno + "'";
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }
        public static int EliminarTurnos(TurnoBE turno)
        {
            // La idea de esta funcion es que se pueda hacer desde un Usuario Paciente o un Usuario Recepcion, el Alta para un Admin no le veo mucho sentido
            int retorna = 0;
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "delete from dbo.Turnos where ID_Turno= " + turno.ID_Turno ;
                SqlCommand comand = new SqlCommand(query, conexion);
                retorna = comand.ExecuteNonQuery();
            }
            return retorna;
        }
        public static List<TurnoBE> ObtenerTodos()
        {
           List<TurnoBE> listaturnos = new List<TurnoBE>();
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "select * from Turnos";
                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    TurnoBE turno = new TurnoBE();
                    turno.ID_Turno = reader.GetInt32(0);
                    turno.ID_Paciente = reader.GetInt32(1);
                    turno.ID_Profesional = reader.GetInt32(2);
                    turno.Estado = reader.GetString(3);
                    turno.FechaHora = reader.GetDateTime(4);
                    turno.Motivo = reader.GetString(5);
                 //   turno.Observaciones = reader.GetString(6);
                    turno.CreatedAtUtc = reader.GetDateTime(7);
                   // turno.UpdateAtUtc = reader.GetDateTime(8);
                   listaturnos.Add(turno);
                }
                conexion.Close();
            }
            return listaturnos;
        }
    }
}
