using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLVoltageTransformerRepository : IRepository<VoltageTransformer>
    {
        private TNEContext _db;
        private const string _messageVoltageTransformerAbsent = "Запрошенного трансформатора напряжения не найдено!";

        public SQLVoltageTransformerRepository(TNEContext context)
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

        public async Task<IQueryable<VoltageTransformer>> GetListAsync() => (IQueryable<VoltageTransformer>)await _db.VoltageTransformers
            .Include(vt => vt.MeterPoint)
            .ToListAsync();

        public async Task UpdateAsync(VoltageTransformer item)
        {
            var voltageTransformerDb = await _db.VoltageTransformers.FindAsync(item.Id);
            if (voltageTransformerDb == null)
            {
                throw new KeyNotFoundException(_messageVoltageTransformerAbsent);
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
