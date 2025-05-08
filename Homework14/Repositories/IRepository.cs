using Homework14.Models;

namespace Homework14.Repositories
{
    internal interface IRepository<T> where T : ModelBase 
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetById(int id);
    }
}
