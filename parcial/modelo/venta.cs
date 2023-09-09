using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class venta
    {
        public int cliente_idcliente { get; set; }
        public int empleado_idempleado { get; set; }
        public int productos_idproductos { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }

    }
}
