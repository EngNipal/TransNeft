using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLDeviceRepository : IRepository<Device>
    {
        private OrganizationContext _db;
        public SQLDeviceRepository(OrganizationContext context)
        {
            _db = context;
        }
        public Task<Device> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Device>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Device item)
        {
            throw new NotImplementedException();
        }
    }
}
