using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthService : IAuthService
    {
        /* 
            PARA QUE ES Y PARA QUE NOS SIRVE
        
            -Vamos a recibir el username + password en texto plano de la UI y tenemos que traer al usuario que nos pide desde la DAL
            -Generamos el hash de la contrasenia ingresada y la comparamos con el passwordhash guardado
            -Validamos el estado del usuario 
            -Lo vinculamos con el paciente o profesional, tambien podremos crearlo y poner alguna que otra informacion
         */

        /* 
          public AuthResultBE Login(string username, string passwordplano)
         {

         }

         public void Logout(int idusuario)
         {

         }

         public bool CambiarPassword(int idusuario, string actual, string nueva)
         {

         }
         */
    }
}
