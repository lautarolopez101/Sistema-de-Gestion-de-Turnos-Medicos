using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUsuarioRepository
    {
        int CrearUsuario(UsuarioBE usuario);
        List<UsuarioBE> Buscar();
        UsuarioBE GetByUsername(string username);
        List<FamiliaBE> GetFamiliasByUsuarioId (int usuarioId); 
        List<PatenteBE> GetPatentesDirectasByUsuarioId(int usuarioId);
        int AgregarIDPaciente(UsuarioBE usuario);
    }
}
