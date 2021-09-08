using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLDeliveryPointRepository : IRepository<DeliveryPoint>
    {
        private OrganizationContext _db;
        public SQLDeliveryPointRepository(OrganizationContext context)
        {
            _db = context;
        }

        public Task AddAsync(DeliveryPoint entity)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryPoint> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<DeliveryPoint>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DeliveryPoint item)
        {
            throw new NotImplementedException();
        }
    }
}
