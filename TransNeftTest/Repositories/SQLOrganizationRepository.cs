using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLOrganizationRepository : IRepository<Organization>
    {
        private OrganizationContext _db;
        public SQLOrganizationRepository(OrganizationContext context)
        {
            _db = context;
        }

        public Task AddAsync(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Organization>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Organization item)
        {
            throw new NotImplementedException();
        }
    }
}
