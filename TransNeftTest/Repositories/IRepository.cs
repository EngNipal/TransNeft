using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetListAsync();
        Task UpdateAsync(T entity);
    }
}
