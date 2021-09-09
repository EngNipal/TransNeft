using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLIdentifiedObjectRepository : IRepository<IdentifiedObject>
    {
        private OrganizationContext _db;
        public SQLIdentifiedObjectRepository(OrganizationContext context)
        {
            _db = context;
        }
        public Task AddAsync(IdentifiedObject entity)
        {
            throw new NotImplementedException();
        }

        public Task<IdentifiedObject> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IdentifiedObject>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentifiedObject entity)
        {
            throw new NotImplementedException();
        }
    }
}
