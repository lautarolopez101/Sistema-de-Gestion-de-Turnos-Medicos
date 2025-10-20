using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public DateTime LastLogin { get; set; }
        public int ID_Paciente { get; set; }
        public int ID_Profesional { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }

        public List<PatenteBE> PatentesDirectas { get; set; } = new List<PatenteBE>();
        public List<FamiliaBE> Familias { get; set; } = new List<FamiliaBE>();


        public UsuarioBE()
        {
            
        
        }

        public UsuarioBE(string username,string passwordhash,string email)
        {
            Username = username;
            PasswordHash = passwordhash;
            Email = email;
            Estado = "Activo";
            LastLogin = DateTime.Now;
            CreatedAtUtc = DateTime.Now;
        }
    }
}
