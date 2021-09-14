using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLElectricityMeterRepository : RepositoryBase<ElectricityMeter>, IRepository<ElectricityMeter>
    {
        public SQLElectricityMeterRepository(TNEContext context) : base(context)
        { }

        public async Task<ElectricityMeter> GetAsync(int id) =>
            await dbContext.ElectricityMeters
            .Include(em => em.MeterPoint)
            .FirstOrDefaultAsync(em => em.Id == id);
    }
}