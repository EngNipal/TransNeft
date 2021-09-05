using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLVoltageTransformerRepository : IRepository<VoltageTransformer>
    {
        public Task<VoltageTransformer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<VoltageTransformer>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(VoltageTransformer item)
        {
            throw new NotImplementedException();
        }
    }
}
