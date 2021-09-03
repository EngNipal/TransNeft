using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IList<T>> GetListAsync();
        Task UpdateAsync(T item);
        Task SaveAsync();
    }
}
