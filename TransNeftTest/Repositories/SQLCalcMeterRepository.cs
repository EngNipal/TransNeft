using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCalcMeterRepository : IRepository<CalcMeter>
    {
        private OrganizationContext _db;
        public SQLCalcMeterRepository(OrganizationContext context)
        {
            _db = context;
        }
        public Task<CalcMeter> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CalcMeter>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CalcMeter item)
        {
            throw new NotImplementedException();
        }
    }
}
