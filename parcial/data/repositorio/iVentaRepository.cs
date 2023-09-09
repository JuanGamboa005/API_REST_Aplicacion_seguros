using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iVentaRepository
    {
        Task<IEnumerable<venta>> Getventa();
        Task<venta> GetventaById(int id);
        Task<bool> Insertventa(venta venta);
        Task<bool> Updateventa(venta venta);
        Task<bool> Deleteventa(int id);
    }
}
