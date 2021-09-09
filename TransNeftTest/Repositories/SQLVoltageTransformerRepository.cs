using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLVoltageTransformerRepository : IRepository<VoltageTransformer>
    {
        private OrganizationContext _db;
        public SQLVoltageTransformerRepository(OrganizationContext context)
        {
            _db = context;
        }

        public async Task AddAsync(VoltageTransformer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<VoltageTransformer> GetAsync(int id) => await _db.VoltageTransformers
            .Include(vt => vt.MeterPoint)
            .FirstOrDefaultAsync(vt => vt.Id == id);

        public async Task<IList<VoltageTransformer>> GetListAsync() => await _db.VoltageTransformers
            .Include(vt => vt.MeterPoint)
            .ToListAsync();

        public Task SaveAsync() => _db.SaveChangesAsync();

        public async Task UpdateAsync(VoltageTransformer item)
        {
            var voltageTransformerDb = await _db.VoltageTransformers.FindAsync(item.Id);
            if (voltageTransformerDb == null)
            {
                throw new NotImplementedException();
}

            voltageTransformerDb.Number = item.Number;
            voltageTransformerDb.CheckDate = item.CheckDate;
            voltageTransformerDb.MeterPointId = item.MeterPointId;
            voltageTransformerDb.MeterPoint = item.MeterPoint;
            voltageTransformerDb.KTH = item.KTH;

            await _db.SaveChangesAsync();
        }
    }
}
