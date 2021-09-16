using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TransNeftTest.Models;
using System.Linq;

namespace TransNeftTest.Repositories
{
    public class SQLCalcMeterRepository : IRepository<CalcMeter>
    {
        private readonly TNEContext _db;
        private readonly DbSet<CalcMeter> _dbSet;

        public SQLCalcMeterRepository(TNEContext context)
        {
            _db = context;
            _dbSet = _db.Set<CalcMeter>();
        }

        public async Task AddAsync(CalcMeter entity)
        {
            await _db.CalcMeters.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(CalcMeter entity)
        {
            _db.CalcMeters.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<CalcMeter> GetAsync(int id) =>
            await _db.CalcMeters
            .FirstOrDefaultAsync(cm => cm.Id == id);

        public IQueryable<CalcMeter> GetList() => _dbSet;
    }
}