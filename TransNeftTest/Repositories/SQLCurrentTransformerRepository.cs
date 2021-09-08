using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCurrentTransformerRepository : IRepository<CurrentTransformer>
    {
        private OrganizationContext _db;
        public SQLCurrentTransformerRepository(OrganizationContext context)
        {
            _db = context;
        }

        public async Task AddAsync(CurrentTransformer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<CurrentTransformer> GetAsync(int id) => await _db.CurrentTransformers
            .Include(ct => ct.MeterPoint)
            .FirstOrDefaultAsync(ct => ct.Id == id);

        public async Task<IList<CurrentTransformer>> GetListAsync() => await _db.CurrentTransformers
            .Include(ct => ct.MeterPoint)
            .ToListAsync();

        public Task SaveAsync() => _db.SaveChangesAsync();

        public async Task UpdateAsync(CurrentTransformer item)
        {
            var currentTransformerDb = await _db.CurrentTransformers.FindAsync(item.Id);
            if (currentTransformerDb == null)
            {
                throw new NotImplementedException();
}

            currentTransformerDb.Number = item.Number;
            currentTransformerDb.CheckDate = item.CheckDate;
            currentTransformerDb.MeterPointId = item.MeterPointId;
            currentTransformerDb.MeterPoint = item.MeterPoint;
            currentTransformerDb.KTT = item.KTT;

            await _db.SaveChangesAsync();
        }
    }
}
