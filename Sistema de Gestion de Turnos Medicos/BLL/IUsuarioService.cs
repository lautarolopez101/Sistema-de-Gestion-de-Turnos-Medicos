using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUsuarioService
    {
        int CrearUsuario(string username, string password, string email);
        UsuarioBE ObtenerUsuario(string user,string password);
        bool BuscarUsuario(string user);
        bool BuscarEmail(string email);
        PacienteBE ObtenerPacienteEmail(string email);
        int AgregarIDPaciente(UsuarioBE usuario);
    }
}
