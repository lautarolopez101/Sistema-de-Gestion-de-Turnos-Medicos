using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProfesionales_EspecialidadesRepository
    {
        List<Profesionales_EspecialidadesBE> ObtenerTodos();
        int AgregarProfesionalesEspecialidades(Profesionales_EspecialidadesBE nodo);
        int ModificarProfesionalesEspecialidades(Profesionales_EspecialidadesBE nodo);
        int EliminarProfesionalesEspecialidades(Profesionales_EspecialidadesBE nodo);
    }
}
