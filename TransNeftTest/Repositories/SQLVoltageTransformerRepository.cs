using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLVoltageTransformerRepository : RepositoryBase<VoltageTransformer>, IRepository<VoltageTransformer>
    {
        public SQLVoltageTransformerRepository(TNEContext context) : base(context)
        { }

        public async Task<VoltageTransformer> GetAsync(int id) =>
            await dbContext.VoltageTransformers
            .Include(vt => vt.MeterPoint)
            .FirstOrDefaultAsync(vt => vt.Id == id);
    }
}