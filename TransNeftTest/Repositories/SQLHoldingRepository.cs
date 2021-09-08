using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLHoldingRepository : IRepository<Holding>
    {
        private OrganizationContext _db;
        public SQLHoldingRepository(OrganizationContext context)
        {
            _db = context;
        }
        public Task<Holding> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Holding>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Holding item)
        {
            throw new NotImplementedException();
        }
    }
}
