using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TransNeftTest.Models;
using System.Linq;

namespace TransNeftTest.Repositories
{
    public class SQLCalcMeterRepository : RepositoryBase<CalcMeter>
    {
        public SQLCalcMeterRepository(TNEContext context) : base(context)
        { }

        public async Task<CalcMeter> GetAsync(int id) =>
            await dbContext.CalcMeters
            .FirstOrDefaultAsync(cm => cm.Id == id);
    }
}