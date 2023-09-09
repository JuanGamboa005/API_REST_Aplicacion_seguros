using modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iClienteRepository
    {
        Task<IEnumerable<cliente>> Getcliente();
        Task<cliente> GetclienteById(int id);
        Task<bool> Insertcliente(cliente cliente);
        Task<bool> Updatecliente(cliente cliente);
        Task<bool> Deletecliente(int id);
    }
}
