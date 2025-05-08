using Homework14.Models;
using Npgsql;
using Dapper;

namespace Homework14.Repositories
{
    internal class ProductRepository : IRepository<Product>
    {
        public async Task<List<Product>> GetAllAsync()
        {
            var query = @" select
                    id, name, description, stockquantity, price
                    from products";

            using (var connection = new NpgsqlConnection(Config.ConnectionString))
            {
                var list = await connection.QueryAsync<Product>(query);
                return list.ToList();
            }
        }

        public async Task<Product?> GetById(int id)
        {
            var query = @" select
                    id, name, description, stockquantity, price
                    from products
                    where id=@id";

            using (var connection = new NpgsqlConnection(Config.ConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Product>(query, new { id });
            }
        }
    }
}
