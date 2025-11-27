using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    /* 
   La interfaz es un contrato que define un conjunto de métodos que una clase debe implementar.
  En este caso, la interfaz define varios metodos para que en la clase PacienteRepository
  sepa como se  hace cada uno, y asi poder implementar la logica de negocio.
   */
    public interface IEspecialidadRepository
    {
        int AgregarEspecialidad(EspecialidadBE especialidad);
        int ModificarEspecialidad(EspecialidadBE especialidad);
        int EliminarEspecialidad(EspecialidadBE especialidad);
        List<EspecialidadBE> ObtenerTodas();
        EspecialidadBE BuscarPorNombre(string nombre);
    }
}
