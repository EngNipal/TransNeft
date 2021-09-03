using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IList<T>> GetListAsync();
        Task SaveAsync();
    }
}