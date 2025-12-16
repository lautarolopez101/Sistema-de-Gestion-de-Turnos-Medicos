using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // Lo agregue para poder que elija la opcion de si usa la primera opcion o la segunda
//lo tuve que agregar como referencia 

namespace DAL
{
    public class SqlConnectionFactory
    {
        /* Que hace esta clase?
         *  -Lee una cadena de conexion (con el servidor, base, usuario, clave)
         *  -Crear y abrir una conexion a SQL Server para poder conectarla al proyecto
         *  -Si algo falla, lanza una excepcion clara
         *
         */

        //Creo un notepad y lo guardo en el escritorio con el nombre .udl
        // alli dentro lo abro y pego la base de datos que quiero usar
        // luego copio la cadena de conexion que me da y la pego en el string de abajo

        /* 
         public static SqlConnection ObtenerConexion()
{
    // creo una instancia de sqlconnection y alli dentro agrego el string de conexion
    SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Sistema de Gestion de Turnos Medicos;Data Source=LAPTOP-0NQ7LDJD");
    // abro la conexion
    conexion.Open();
    // retorno la conexion abierta
    return conexion;
}
         */
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Sistema de Gestion de Turnos Medicos;Data Source=KernelOS-PC");
            conexion.Open();
            return conexion;
        }

       

    }
}
