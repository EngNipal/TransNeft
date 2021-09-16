using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        private readonly TNEContext _db;
        private readonly DbSet<ElectricityMeter> _dbSet;

        public SQLElectricityMeterRepository(TNEContext context)
        {
            _db = context;
            _dbSet = _db.Set<ElectricityMeter>();
        }

        public async Task AddAsync(ElectricityMeter entity)
        {
            await _db.ElectricityMeters.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(ElectricityMeter entity)
        {
            _db.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<ElectricityMeter> GetAsync(int id) =>
            await _db.ElectricityMeters
            .Include(em => em.MeterPoint)
            .FirstOrDefaultAsync(em => em.Id == id);

        public IQueryable<ElectricityMeter> GetList() =>
            _dbSet
            .Include(em => em.MeterPoint);
    }
}
