using BE;
using System;
using System.Collections.Generic;
using System.Data;
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
                string query = "insert into Turnos (ID_Paciente,ID_Profesional,Estado,FechaHora,Motivo,Observaciones) values ('" +turno.ID_Paciente  + "','" + turno.ID_Profesional + "','" + turno.Estado + "','" + turno.FechaHora + "','" + turno.Motivo + "','" + turno.Observaciones + "')";
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
                    "Observaciones = '" + turno.Observaciones + "',"+ 
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
            // Creo una lista de turnos para poder traerlos todo
           List<TurnoBE> listaturnos = new List<TurnoBE>();
            // Abirmos la conexion 
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                // Creamos un query para poder pasarselo mas facil
                string query = "select * from Turnos";
                // Creamos el comando con el query en la conexion "TAL"
                SqlCommand comand = new SqlCommand(query, conexion);
                // Mandamos a leer todo el comando 
                SqlDataReader reader = comand.ExecuteReader();
                // Mientras tenga para leer entonces =>
                while (reader.Read())
                {
                    // Creamos un turno y le damos la informacion a las variables del objeto
                    TurnoBE turno = new TurnoBE();
                    turno.ID_Turno = reader.GetInt32(0);
                    turno.ID_Paciente = reader.GetInt32(1);
                    turno.ID_Profesional = reader.GetInt32(2);
                    turno.Estado = reader.GetString(3);
                    turno.FechaHora = reader.GetDateTime(4);
                    turno.Motivo = reader.GetString(5);
                    
                    // Tenemos que hacer una verificacion para ver si hay una observacion o no de parte 
                    // Si en la posicion 6 del reader no esta vacio entonces .........
                    if(!reader.IsDBNull(6))
                    {
                        turno.Observaciones = reader.GetString(6);
                    }
                    else
                    {
                        turno.Observaciones =null;
                    }
                        turno.CreatedAtUtc = reader.GetDateTime(7);
                    if (!reader.IsDBNull(8))
                    {
                        turno.UpdateAtUtc = reader.GetDateTime(8);
                    }
                    else
                    {
                        turno.UpdateAtUtc = DateTime.Today;
                    }
                    // Agregamos el turno a la lista
                        listaturnos.Add(turno);
                }
                // Cerramos la conexion
                conexion.Close();
            }
            return listaturnos;
        }

        public static List<TurnoBE> FiltrarPacienteHistorial( int idPaciente, string estado1, string estado2)
        {
            List<TurnoBE> lista = new List<TurnoBE>();

            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query =
                    "SELECT " +
                    "t.ID_Turno, " +
                    "t.ID_Paciente, " +
                    "t.ID_Profesional, " +
                    "t.Estado, " +
                    "t.FechaHora, " +
                    "t.Motivo, " +
                    "t.Observaciones, " +
                    "p.Nombre AS NombreProfesional, " +
                    "p.Apellido AS ApellidoProfesional " +
                    "FROM dbo.Turnos AS t " +
                    "INNER JOIN dbo.Profesionales AS p " +
                    "ON p.ID_Profesional = t.ID_Profesional " +
                    "WHERE t.ID_Paciente = '" + idPaciente + "' " +
                    "AND t.Estado IN ('" + estado1 + "', '" + estado2 + "') " +
                    "ORDER BY t.FechaHora DESC";

                SqlCommand comand = new SqlCommand(query, conexion);
                SqlDataReader dr = comand.ExecuteReader();

                while (dr.Read())
                {
                    TurnoBE turno = new TurnoBE();

                    turno.ID_Turno = Convert.ToInt32(dr["ID_Turno"]);
                    turno.ID_Paciente = Convert.ToInt32(dr["ID_Paciente"]);
                    turno.ID_Profesional = Convert.ToInt32(dr["ID_Profesional"]);
                    turno.Estado = dr["Estado"].ToString();
                    turno.FechaHora = Convert.ToDateTime(dr["FechaHora"]);
                    turno.Motivo = dr["Motivo"].ToString();
                    turno.Observaciones = dr["Observaciones"].ToString();

                    turno.NombreProfesional = dr["NombreProfesional"].ToString();
                    turno.ApellidoProfesional = dr["ApellidoProfesional"].ToString();

                    lista.Add(turno);
                }
            }
            return lista;
        }
        public static List<TurnoBE> TurnosPorProfesional(int idprofesional)
        {
            List<TurnoBE> listaturno = new List<TurnoBE>();
            using (SqlConnection conexion = SqlConnectionFactory.ObtenerConexion())
            {
                string query = "SELECT " +
                "t.ID_Turno, " +
                "t.ID_Profesional, " +
                "t.ID_Paciente, " +
                "p.DNI AS DNIPaciente, " +
                "p.Nombre AS NombrePaciente, " +
                "p.Apellido AS ApellidoPaciente, " +
                "p.Email AS EmailPaciente, " +
                "p.Telefono AS TelefonoPaciente, " +
                "p.FechaNacimiento AS FechaNacimientoPaciente, " +
                "t.Motivo, " +
                "t.FechaHora, " +
                "t.Observaciones, " +
                "t.Estado " +          // ← AGREGÁ ESTE ESPACIO
                "FROM Turnos t " +
                "JOIN Pacientes p ON t.ID_Paciente = p.ID_Paciente " +
                "WHERE t.ID_Profesional = " + idprofesional + " " +
                "ORDER BY t.FechaHora;";

                SqlCommand comand = new SqlCommand(query, conexion);

                using (SqlDataReader sr = comand.ExecuteReader())
                {
                    while (sr.Read())
                    {
                        // Creamos el turno
                        var turno = new TurnoBE();
                        turno.ID_Turno = Convert.ToInt32(sr["ID_Turno"]);
                        turno.ID_Profesional = Convert.ToInt32(sr["ID_Profesional"]);
                        turno.ID_Paciente = Convert.ToInt32(sr["ID_Paciente"]);
                        turno.Motivo = sr["Motivo"].ToString();
                        turno.FechaHora = Convert.ToDateTime(sr["FechaHora"]);
                        turno.Estado = sr["Estado"].ToString();
                        ;
                        turno.Observaciones = sr.IsDBNull(sr.GetOrdinal("Observaciones"))
                                                 ? null
                                                 : sr["Observaciones"].ToString();

                        // Creamos el paciente embebido dentro del turno
                        turno.Paciente = new PacienteBE
                        {
                            ID_Paciente = Convert.ToInt32(sr["ID_Paciente"]),
                            DNI = sr["DNIPaciente"].ToString(),
                            Nombre = sr["NombrePaciente"].ToString(),
                            Apellido = sr["ApellidoPaciente"].ToString(),
                            Email = sr["EmailPaciente"].ToString(),
                            Telefono = sr["TelefonoPaciente"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(sr["FechaNacimientoPaciente"])
                        };

                        listaturno.Add(turno);
                    }
                }
            }
                    return listaturno;
        }
    }
}
