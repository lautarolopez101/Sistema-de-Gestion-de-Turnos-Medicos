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
        private readonly IProfesionalRepository _profesionalrepository;
        public UsuarioService(IUsuarioRepository repo, IPasswordService paswword, IPacienteRepository pacienteRepository, IProfesionalRepository profesionalRepository)
        {
            _passwordService = paswword;
            _usuariorepository = repo;            
            _pacienterepository = pacienteRepository;
            _profesionalrepository = profesionalRepository;
        }

        public List<UsuarioBE> ObtenerTodos()
        {
            return _usuariorepository.ObtenerTodos();
        }

        public List<UsuarioBE> ObtenerUsuariosProfesionales()
        {
            List<UsuarioBE> todos = new List<UsuarioBE>();
            todos = _usuariorepository.ObtenerTodos();
            List<UsuarioBE> usuariosprofesionales = todos.Where(x => x.ID_Profesional > 0 || (x.ID_Profesional == 0 && x.ID_Paciente ==0)).ToList();
            return usuariosprofesionales;

        }

        public int CrearUsuarioProfesional(string username, string plainpassword, string email, int idprofesional)
        {
            // Vamos a lanzar algunas excepciones por si el usuario ya existe

            List<UsuarioBE> todos = _usuariorepository.ObtenerTodos();

            bool existeusuario = todos.Exists(x => x.Username == username);
            if (existeusuario)
                throw new ValidationException("El nombre de usuario ya existe");

            bool existeemail = todos.Exists(x => x.Email == email);
            if(existeemail)
                throw new ValidationException("El email ya existe");

            bool esprofesionalvinculado = todos.Exists(x => x.ID_Profesional == idprofesional);
            if(esprofesionalvinculado)
                throw new ValidationException("El profesional ya tiene un usuario vinculado");

            // Aca tendriamos que hacer lo del hash para poder crear y guardar el usuario
            string passwordhash = _passwordService.HashPassword(plainpassword);

            // Creamos una instancia de usuario para poder ponerle los atributos necesarios
            UsuarioBE usuario = new UsuarioBE();
            usuario.Username = username;
            usuario.Email = email;
            usuario.PasswordHash = passwordhash;
            usuario.ID_Profesional = idprofesional;
            int retorna = _usuariorepository.CrearUsuario(usuario);
            return retorna;
        }

        public int CrearUsuario(string username, string plainpassword, string email)
        {
            // Vamos a lanzar algunas excepciones por si el usuario ya existe
            
            // Aca tendriamos que hacer lo del hash para poder crear y guardar el usuario
            string passwordhash = _passwordService.HashPassword(plainpassword);

            // Creamos una instancia de usuario para poder ponerle los atributos necesarios
            UsuarioBE usuario = new UsuarioBE();
            usuario.Username = username;
            usuario.Email = email;
            usuario.PasswordHash = passwordhash;
            usuario.ID_Profesional = 0;
            int retorna = _usuariorepository.CrearUsuario(usuario);
            return retorna;
        }


        public UsuarioBE ObtenerUsuario(string user, string password)
        {
            UsuarioBE usuario = new UsuarioBE();   
            usuario = _usuariorepository.GetByUsername(user);
            
            if (usuario == null)
                throw new BusinessException("Usuario no encontrado");

            string passwordhash = usuario.PasswordHash;
            
            bool verificamos = _passwordService.VerifyPassword(password,passwordhash);

            if (!verificamos)
                return null; // o throw BusinessException("Contraseña incorrecta");

            return usuario;
        }

        // Aca seria que por ID usuario podamos buscar al respecitvo paciente
        public PacienteBE GetByIDPaciente(int idusuario)
        {
            // Creamos al usuario y lo buscamos por el ID
            UsuarioBE usuario = _usuariorepository.GetByID(idusuario);
            // ahora le damos al entero del id paciente el valor del ID paciente del usuario
            int idpaciente = usuario.ID_Paciente;
            // y ahora devolvemos al paciente entero buscandolo por su ID_Paciente
            return _pacienterepository.ObtenerPaciente(idpaciente);
        }
        public ProfesionalBE GetByIDProfesional(int idusuario)
        {
            // Creamos al usuario y lo buscamos por el ID
            UsuarioBE usuario = _usuariorepository.GetByID(idusuario);
            // ahora le damos al entero del id paciente el valor del ID paciente del usuario
            int idprofesional = usuario.ID_Profesional;
            // y ahora devolvemos al paciente entero buscandolo por su ID_Paciente
            return _profesionalrepository.ObtenerProfesional(idprofesional);
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
        public int Logout(UsuarioBE usuario)
        {
            return _usuariorepository.Logout(usuario);
        }
        public PacienteBE ObtenerPacienteEmail(string email)
        {
            return _pacienterepository.ObtenerPacienteEmail(email);
        }
    }
}
