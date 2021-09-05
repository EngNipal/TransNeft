using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLConsumerRepository : IRepository<Consumer>
    {
        public Task<Consumer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Consumer>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Consumer item)
        {
            throw new NotImplementedException();
        }
    }
}
