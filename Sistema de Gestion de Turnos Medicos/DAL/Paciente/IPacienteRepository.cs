using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /* 
     La interfaz es un contrato que define un conjunto de métodos que una clase debe implementar.
    En este caso, la interfaz define varios metodos para que en la clase PacienteRepository
    sepa como se  hace cada uno, y asi poder implementar la logica de negocio.
     */
    public interface IPacienteRepository
    {
        int AltaPaciente(PacienteBE paciente);
        int BajaPaciente(PacienteBE paciente);  
        int ModificarPaciente(PacienteBE paciente);
        int DesactivarPaciente(PacienteBE paciente);
        int ActivarPaciente(PacienteBE paciente);
        PacienteBE ObtenerPaciente(int idpaciente);
        List<PacienteBE> ObtenerTodos();
        List<PacienteBE> ListarPacientesEstado(string cual);
    }
}
