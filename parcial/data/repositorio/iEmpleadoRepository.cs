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
        Task<IEnumerable<empleado>> GetEmpleado();
        Task<empleado> GetEmpleadoById(int id);
        Task<bool> InsertEmpleado(empleado empleado);
        Task<bool> UpdateEmpleado(empleado empleado);
        Task<bool> DeleteEmpleado(int id);
    }
}
