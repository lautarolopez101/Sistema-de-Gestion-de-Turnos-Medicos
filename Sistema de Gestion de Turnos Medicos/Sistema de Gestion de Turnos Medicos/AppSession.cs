using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    public static class AppSession
    {
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
