using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelo;

namespace data.repositorio
{
    public interface iEmpleadoRepository
    {
        Task<IEnumerable<empleado>> Getempleado();
        Task<empleado> GetempleadoById(int id);
        Task<bool> Insertempleado(empleado empleado);
        Task<bool> Updateempleado(empleado empleado);
        Task<bool> Deleteempleado(int id);
    }
}
