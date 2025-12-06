using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TurnoBE
    {
        public int ID_Turno { get; set; }
        public int ID_Paciente { get; set; }
        public int ID_Profesional { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdateAtUtc { get; set; }

        public string NombreProfesional { get; set; }
        public string ApellidoProfesional { get; set; }

        public PacienteBE Paciente { get; set; }

        public TurnoBE()
        {
            
        }
        public TurnoBE(int profe,int pacien,string estado, DateTime fecha, string motivo, string observaciones)
        {
            ID_Paciente = pacien;
            ID_Profesional = profe;
            Estado = estado;
            FechaHora = fecha;
            Motivo = motivo;
            Observaciones = observaciones;
        }
    }
}
