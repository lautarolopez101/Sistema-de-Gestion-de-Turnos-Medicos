using BE;
using DAL.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public List<UsuarioBE> ObtenerTodos()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            lista = UsuarioDAL.ObtenerTodos();
            return lista;
        }
        public int CrearUsuario(UsuarioBE usuario)
        {
            int retorna = UsuarioDAL.CrearUsuario(usuario);
            return retorna;
        }
       
        public List<UsuarioBE> Buscar()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            lista = UsuarioDAL.Buscar();
            return lista;   
        }
        public int AgregarIDPaciente(UsuarioBE usuario)
        {
            return UsuarioDAL.AgregarIDPaciente(usuario);
        }
        public int AgregarIDProfesional(UsuarioBE usuario)
        {
            return UsuarioDAL.AgregarIDProfesional(usuario);
        }
        public UsuarioBE GetByUsername(string username)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario = UsuarioDAL.ObtenterPorUsername(username);
            return usuario;
        }
        public UsuarioBE GetByID(int idusuario)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario = UsuarioDAL.ObtenterPorID(idusuario);
            return usuario;
        }
        public List<FamiliaBE> GetFamiliasByUsuarioId(int usuarioId)
        {
            List<FamiliaBE> lista = new List<FamiliaBE>();
            lista = UsuarioDAL.ListaFamiliasDelUsuario(usuarioId);
            return lista;
        }
        public List<PatenteBE> GetPatentesDirectasByUsuarioId(int usuarioId)
        {
            List<PatenteBE> lista = new List<PatenteBE>();
            lista = UsuarioDAL.ListarPatentesDirectasDelUsuario(usuarioId);
            return lista;
        }
        public int Logout(UsuarioBE usuario)
        {
            return UsuarioDAL.Logout(usuario);
        }

    }
}
