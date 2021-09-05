using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLDeliveryPointRepository : IRepository<DeliveryPoint>
    {
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
