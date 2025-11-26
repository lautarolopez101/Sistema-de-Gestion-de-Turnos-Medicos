using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public static class AppSession
    {
        // Como la capa UI tiene acceso a la capa BLL, podemos guardar los datos del usuario logueado en esta clase estatica
        // Ahora vamos a definir que datos queremos guardar del usuario logueado
        // Obtenemos el paciente mediante el usuario logueado

        public static PacienteBE Paciente { get; set; }


        // Datos minimos del Usuario
        public static int ID_Usuario { get; private set; }
        public static string Username { get; private set; }


        //Vinculos 
        public static int? ID_Paciente { get; private set; }
        public static int? ID_Profesional { get; private set; }


        public static void Login(int idusuario, string username, int? idpaciente, int? idprofesional)
        {
            ID_Usuario = idusuario;
            Username = username;
            ID_Paciente = idpaciente;
            ID_Profesional = idprofesional;
        }
        public static void Logout()
        {
            ID_Usuario = 0;
            Username = string.Empty;
            ID_Paciente = null;
            ID_Profesional = null;
        }
    }
}
