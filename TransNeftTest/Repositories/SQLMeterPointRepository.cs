using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLMeterPointRepository : IRepository<MeterPoint>
    {
        private TNEContext _db;
        private const string _messageMeterPointAbsent = "Запрошенной точки измерения не найдено!";

        public SQLMeterPointRepository(TNEContext context)
        {
            _db = context;
        }

        public async Task AddAsync(MeterPoint entity)
        {
            await _db.MeterPoints.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<MeterPoint> GetAsync(int meterPointId) => await _db.MeterPoints
            .FirstOrDefaultAsync(mp => mp.Id == meterPointId);

        public async Task<IQueryable<MeterPoint>> GetListAsync() => (IQueryable<MeterPoint>)await _db.MeterPoints
            .ToListAsync();

        public async Task UpdateAsync(MeterPoint item)
        {
            var meterPointDb = await _db.MeterPoints.FindAsync(item.Id);
            if (meterPointDb == null)
            {
                throw new KeyNotFoundException(_messageMeterPointAbsent);
            }

            meterPointDb.Name = item.Name;
            meterPointDb.ElectricityMeter = item.ElectricityMeter;
            meterPointDb.CurrentTransformer = item.CurrentTransformer;
            meterPointDb.VoltageTransformer = item.VoltageTransformer;
            meterPointDb.EObject = item.EObject;
            meterPointDb.CalcMeter = item.CalcMeter;

            await _db.SaveChangesAsync();
        }
    }
}