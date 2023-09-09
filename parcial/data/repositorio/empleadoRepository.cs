using Dapper;
using modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace data.repositorio 
{
    public class empleadoRepository : iEmpleadoRepository
    {
        public readonly mysqlConfig _connection;
        public empleadoRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> deleteEmpleado(int id)
        {
            var db = dbConnection();
            var sql = @"delete from empleado where idempleado=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<empleado> getempleadoById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from empleado where idempleado=@Id";
            return db.QueryFirstOrDefaultAsync<empleado>(consulta, new { Id = id });
        }

        public Task<IEnumerable<empleado>> getempleado()
        {
            var db = dbConnection();
            var consulta = @"select * from empleado";
            return db.QueryAsync<empleado>(consulta);
        }

        public async Task<bool> insertempleado(empleado empleado)
        {
            var db = dbConnection();
            var sql = @"insert into empleado
            (cc, nombre, edad, foto, telefono)
            values(@cc,@nombre, @edad, @foto, @telefono)";
            var result = await db.ExecuteAsync(sql, new
            {
                empleado.cc,
                empleado.nombre,
                empleado.edad,
                empleado.foto,
                empleado.telefono
            });

            return result > 0;
        }

        public async Task<bool> updateCliente(empleado empleado)
        {
            var db = dbConnection();
            var sql = @"update empleado set
                    cc=@cc,
                    nombre=@nombre,
                    edad=@edad,
                    foto=@foto,
                    Telefono=@Telefono
                    where (idempleado=@Id)";
            var result = await db.ExecuteAsync(sql, new
            {
                empleado.cc,
                empleado.nombre,
                empleado.edad,
                empleado.foto,
                empleado.telefono
            });
            return result > 0;
        }
    }
}