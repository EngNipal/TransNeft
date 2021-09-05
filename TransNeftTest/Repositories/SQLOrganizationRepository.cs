using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLOrganizationRepository : IRepository<Organization>
    {
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
