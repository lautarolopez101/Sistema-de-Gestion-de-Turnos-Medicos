using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioBE GetByUsername(string username);
        List<FamiliaBE> GetFamiliasByUsuarioId (int usuarioId); 
        List<PatenteBE> GetPatentesDirectasByUsuarioId(int usuarioId);
    }
}
