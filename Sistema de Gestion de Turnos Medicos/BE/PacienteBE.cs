using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PacienteBE
    {
        public int ID_Paciente { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc{get; set; }

        public PacienteBE()
        {
           
        }

        public PacienteBE(string nombre, string apellido)
        {
            nombre = Nombre;
            apellido = Apellido;
        }

        public PacienteBE(int id, string dni,string nombre, string apellido, DateTime fechaNacimiento, string telefono, string email)
        {
            ID_Paciente = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
        }
    }
}
