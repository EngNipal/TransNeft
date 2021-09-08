using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLSubsidiaryRepository : IRepository<Subsidiary>
    {
        private OrganizationContext _db;
        public SQLSubsidiaryRepository(OrganizationContext context)
        {
            _db = context;
        }
        public Task<Subsidiary> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Subsidiary>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Subsidiary item)
        {
            throw new NotImplementedException();
        }
    }
}
