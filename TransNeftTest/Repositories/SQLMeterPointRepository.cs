using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLMeterPointRepository : IRepository<MeterPoint>
    {
        private OrganizationContext _db;
        private const string _messageMeterPointAbsent = "Запрошенной точки измерения не найдено!";

        public SQLMeterPointRepository(OrganizationContext context)
        {
            _db = context;
        }

        public async Task<MeterPoint> GetAsync(int meterPointId) => await _db.MeterPoints
            .Include(mp => mp.ElicticityMeter)
            .Include(mp => mp.CurrentTransformer)
            .Include(mp => mp.VoltageTransformer)
            .Include(mp => mp.Consumer)
            .Include(mp => mp.CalcMeter)
            .FirstOrDefaultAsync(mp => mp.Id == meterPointId);

        public async Task<IList<MeterPoint>> GetListAsync() => await _db.MeterPoints
            .Include(mp => mp.ElicticityMeter)
            .Include(mp => mp.CurrentTransformer)
            .Include(mp => mp.VoltageTransformer)
            .Include(mp => mp.Consumer)
            .Include(mp => mp.CalcMeter)
            .ToListAsync();

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        public async Task UpdateAsync(MeterPoint item)
        {
            var meterPointDb = await _db.MeterPoints.FindAsync(item.Id);
            if (meterPointDb == null)
            {
                throw new Exception(_messageMeterPointAbsent);
            }

            meterPointDb.Name = item.Name;
            meterPointDb.ElicticityMeter = item.ElicticityMeter;
            meterPointDb.CurrentTransformer = item.CurrentTransformer;
            meterPointDb.VoltageTransformer = item.VoltageTransformer;
            meterPointDb.Consumer = item.Consumer;
            meterPointDb.CalcMeter = item.CalcMeter;

            await _db.SaveChangesAsync();
        }
    }
}
