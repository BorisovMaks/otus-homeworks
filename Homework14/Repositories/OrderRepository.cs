using Homework14.Models;
using Npgsql;
using Dapper;

namespace Homework14.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {

        public async Task<List<Order>> GetAllAsync()
        {
            var query = @" select
                    id, customerid, productid, quantity
                    from orders";
            using (var connection = new NpgsqlConnection(Config.ConnectionString))
            {
                var list = await connection.QueryAsync<Order>(query);
                return list.ToList();
            }
        }

        public async Task<Order?> GetById(int id)
        {
            var query = @"select
                    id, customerid, productid, quantity
                    from orders
                    where id=@id";
            using (var connection = new NpgsqlConnection(Config.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Order>(query, new { id });
            }
        }
    }
}
