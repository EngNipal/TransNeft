using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        public Task<ElectricityMeter> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ElectricityMeter>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ElectricityMeter item)
        {
            throw new NotImplementedException();
        }
    }
}
