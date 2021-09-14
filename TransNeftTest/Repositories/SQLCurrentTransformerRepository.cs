using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCurrentTransformerRepository : RepositoryBase<CurrentTransformer>
    {
        public SQLCurrentTransformerRepository(TNEContext context) : base(context)
        { }

        public async Task<CurrentTransformer> GetAsync(int id) =>
            await dbContext.CurrentTransformers
            .Include(ct => ct.MeterPoint)
            .FirstOrDefaultAsync(ct => ct.Id == id);
    }
}