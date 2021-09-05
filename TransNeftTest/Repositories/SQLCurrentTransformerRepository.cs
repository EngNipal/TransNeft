using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCurrentTransformerRepository : IRepository<CurrentTransformer>
    {
        public Task<CurrentTransformer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CurrentTransformer>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CurrentTransformer item)
        {
            throw new NotImplementedException();
        }
    }
}
