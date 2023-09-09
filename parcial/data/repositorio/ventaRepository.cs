using modelo;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace data.repositorio
{
    public class ventaRepository : iVentaRepository
    {
        public readonly mysqlConfig _connection;
        public ventaRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> Deleteventa(int id)
        {
            var db = dbConnection();
            var sql = @"delete from venta where idventa=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<venta> GetventaById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from venta where idventa=@Id";
            return db.QueryFirstOrDefaultAsync<venta>(consulta, new { Id = id });
        }

        public Task<IEnumerable<venta>> Getventa()
        {
            var db = dbConnection();
            var consulta = @"select * from venta";
            return db.QueryAsync<venta>(consulta);
        }

        public async Task<bool> Insertventa(venta venta)
        {
            var db = dbConnection();
            var sql = @"insert into venta
            (cliente_idcliente,empleado_idempleado,productos_idproductos,fechaInicio,fechaFin)
            values(@cliente_idcliente, @empleado_idempleado, @productos_idproductos, @fechaInicio, @fechaFin)";
            var result = await db.ExecuteAsync(sql, new
            {
                venta.cliente_idcliente,
                venta.empleado_idempleado,
                venta.productos_idproductos,
                venta.fechaInicio,
                venta.fechaFin
            });

            return result > 0;
        }

        public async Task<bool> Updateventa(venta venta)
        {
            var db = dbConnection();
            var sql = @"update venta set
                    cliente_idcliente=@cliente_idcliente,
                    empleado_idempleado=@empleado_idempleado,
                    venta_idventa=@venta_idventa,
                    productos_idproductos=@productos_idproductos,
                    fechaInicio=@fechaInicio,
                    fechaFin=@fechaFin
                    where (idempleado=@Id)";
            var result = await db.ExecuteAsync(sql, new
            {
                venta.cliente_idcliente,
                venta.empleado_idempleado,
                venta.productos_idproductos,
                venta.fechaInicio,
                venta.fechaFin
            });
            return result > 0;
        }
    }
}
