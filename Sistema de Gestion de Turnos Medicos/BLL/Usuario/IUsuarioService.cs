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
        List<UsuarioBE> ObtenerTodos();
        List<UsuarioBE> ObtenerUsuariosProfesionales();
        int CrearUsuarioProfesional(string username, string plainpassword, string email, int idprofesional);
        int CrearUsuario(string username, string password, string email);
        UsuarioBE ObtenerUsuario(string user,string password);
        PacienteBE GetByIDPaciente(int idusuario);
        ProfesionalBE GetByIDProfesional(int idusuario);

        bool BuscarUsuario(string user);
        bool BuscarEmail(string email);
        PacienteBE ObtenerPacienteEmail(string email);
        int AgregarIDPaciente(UsuarioBE usuario);
        int Logout(UsuarioBE usuario);
    }
}
