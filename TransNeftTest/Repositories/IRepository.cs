using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransNeftTest.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IList<T>> GetListAsync();
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
