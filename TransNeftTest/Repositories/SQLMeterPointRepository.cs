using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLMeterPointRepository : RepositoryBase<MeterPoint>, IRepository<MeterPoint>
    {
        public SQLMeterPointRepository(TNEContext context) : base(context)
        { }

        public async Task<MeterPoint> GetAsync(int meterPointId) =>
            await dbContext.MeterPoints
            .FirstOrDefaultAsync(mp => mp.Id == meterPointId);
    }
}