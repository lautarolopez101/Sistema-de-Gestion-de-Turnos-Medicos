using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuariorepository;
        private readonly IPasswordService _passwordService;
        private readonly IPacienteRepository _pacienterepository;
        public UsuarioService(IUsuarioRepository repo, IPasswordService paswword, IPacienteRepository pacienteRepository)
        {
            _passwordService = paswword;
            _usuariorepository = repo;            
            _pacienterepository = pacienteRepository;
        }

       

        public int CrearUsuario(string username, string plainpassword, string email)
        {
            // Aca tendriamos que hacer lo del hash para poder crear y guardar el usuario
            string passwordhash = _passwordService.HashPassword(plainpassword);

            // Creamos una instancia de usuario para poder ponerle los atributos necesarios
            UsuarioBE usuario = new UsuarioBE();
            usuario.Username = username;
            usuario.Email = email;
            usuario.PasswordHash = passwordhash;
            int retorna = _usuariorepository.CrearUsuario(usuario);
            return retorna;
        }

        public UsuarioBE ObtenerUsuario(string user, string password)
        {
            UsuarioBE usuario = new UsuarioBE();   
            usuario = _usuariorepository.GetByUsername(user);

            string passwordhash = usuario.PasswordHash;
            // Aca tendria que estar el metodo para verificar si la contrasenia es la misma 
            bool verifica = _passwordService.VerifyPassword(password,passwordhash);

            if (verifica)
            {
                // Un mensaje?
            }
            else
            {
                // no coincide
            }
                return usuario;
        }

        public bool BuscarUsuario(string user)
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            lista = _usuariorepository.Buscar();
            // ahora tendremos que buscar un usuario igual al que ingreso
            bool buscamosuser = lista.Exists(x => x.Username == user);
            return buscamosuser;
        }
        public int AgregarIDPaciente(UsuarioBE usuario)
        {
            return _usuariorepository.AgregarIDPaciente(usuario);
        }
        public bool BuscarEmail(string email)
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            lista = _usuariorepository.Buscar();
            // ahora tenemos que buscar un email parecido al que ingreso 
            bool buscamosemail = lista.Exists(x => x.Email == email);
            return buscamosemail;
        }

        public PacienteBE ObtenerPacienteEmail(string email)
        {
            return _pacienterepository.ObtenerPacienteEmail(email);
        }
    }
}
