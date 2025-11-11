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
            //  Esto NO usa ConfigurationManager todavía, así evitamos que
            // el depurador culpe a GetHostName si el config está roto.

            /* Lo que hace este DNS.GetHostName es obtener el nombre de la computadora, cuando estoy desde la laptop usa el 
            Laptop-0NQ7LDJD y si estoy desde la pc usa 
             
             */
            // Obtiene el dns de la maquina que tiene el programa
            string equipo = Dns.GetHostName();
            // y hace una verificacion si es igual a la dns de la laptop y sino 
            string nombreCadena = equipo.Equals("LAPTOP-0NQ7LDJD", StringComparison.OrdinalIgnoreCase)
                                  ? "ConexionLaptop" : "ConexionPC";

            string cadena;

            try
            {
                // Fuerzo la carga del config para obtener error detallado si está mal
                var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //Verifica si la cadena de conexion existe y no esta vacia
                var cs = ConfigurationManager.ConnectionStrings[nombreCadena];
                // Lanza una excepcion clara si no la encuentra
                if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                    throw new InvalidOperationException($"No encontré la cadena '{nombreCadena}' en App.config de la UI.");

                // La tengo, la uso
                cadena = cs.ConnectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                //  Diagnóstico claro (archivo y línea si aplica)
                string archivo = ex.Filename ?? "(desconocido)";
                throw new Exception($"App.config inválido: {ex.Message} Archivo: {archivo} Revisá que haya UNA sola sección <connectionStrings>.", ex);
            }

            var cn = new SqlConnection(cadena);

            // Lo comentamos a la conexion abierta porque ultimamente me estaba tirando error de que la "ABRIA" dos veces, asi que prefiero abrirla en la dal para abrir y cerrar cuando haga una ejecucion

           // cn.Open();
            return cn;
        }

    }
}
