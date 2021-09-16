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
        private readonly TNEContext _db;
        private readonly DbSet<MeterPoint> _dbSet;

        public SQLMeterPointRepository(TNEContext context)
        {
            _db = context;
            _dbSet = _db.Set<MeterPoint>();
        }

        public async Task AddAsync(MeterPoint entity)
        {
            await _db.MeterPoints.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(MeterPoint entity)
        {
            _db.MeterPoints.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<MeterPoint> GetAsync(int meterPointId) => await _db.MeterPoints
            .FirstOrDefaultAsync(mp => mp.Id == meterPointId);

        public IQueryable<MeterPoint> GetList() => _dbSet;
    }
}