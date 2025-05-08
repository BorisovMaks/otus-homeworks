using Homework14.Models;
using Npgsql;
using Dapper;

namespace Homework14.Repositories
{
    internal class CustomerRepository : IRepository<Customer>
    {
        public async Task<List<Customer>> GetAllAsync()
        {
            var query = @"select 
                    id, firstname, lastname, age
                    from customers";
            using (var connection = new NpgsqlConnection(Config.ConnectionString))
            {
                var list = await connection.QueryAsync<Customer>(query);
                return list.ToList();
            }
        }

        public async Task<Customer?> GetById(int id)
        {
            var query = @" select
                    id, firstname, lastname, age
                    from customers
                    where id=@id";
            using (var connection = new NpgsqlConnection(Config.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Customer>(query, new { id });
            }
        }
    }
}
