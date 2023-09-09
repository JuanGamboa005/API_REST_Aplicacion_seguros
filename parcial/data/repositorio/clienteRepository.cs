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
    public class clienteRepository : iClienteRepository
    {
        public readonly mysqlConfig _connection;
        public clienteRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> Deletecliente(int id)
        {
            var db = dbConnection();
            var sql = @"delete from cliente where idcliente=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<cliente> GetclienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from cliente where idcliente=@Id";
            return db.QueryFirstOrDefaultAsync<cliente>(consulta, new { Id = id });
        }

        public Task<IEnumerable<cliente>> Getcliente()
        {
            var db = dbConnection();
            var consulta = @"select * from cliente";
            return db.QueryAsync<cliente>(consulta);
        }

        public async Task<bool> Insertcliente(cliente cliente)
        {
            var db = dbConnection();
            var sql = @"insert into cliente
            (cc, nombre, edad, foto, telefono)
            values(@cc,@nombre, @edad, @foto, @telefono)";
            var result = await db.ExecuteAsync(sql, new
            {
                cliente.cc,
                cliente.nombre,
                cliente.edad,
                cliente.foto,
                cliente.telefono
            });

            return result > 0;
        }

        public async Task<bool> Updatecliente(cliente cliente)
        {
            var db = dbConnection();
            var sql = @"update cliente set
                    cc=@cc,
                    nombre=@nombre,
                    edad=@edad,
                    foto=@foto,
                    Telefono=@Telefono
                    where (idcliente=@Id)";
            var result = await db.ExecuteAsync(sql, new
            {
                cliente.cc,
                cliente.nombre,
                cliente.edad,
                cliente.foto,
                cliente.telefono
            });
            return result > 0;
        }
    }
}
