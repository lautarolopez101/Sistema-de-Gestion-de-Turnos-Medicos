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
       
    }
}
