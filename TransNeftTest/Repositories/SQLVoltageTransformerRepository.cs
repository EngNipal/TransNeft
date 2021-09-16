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
        private readonly TNEContext _db;
        private readonly DbSet<VoltageTransformer> _dbSet;

        public SQLVoltageTransformerRepository(TNEContext context)
        {
            _db = context;
            _dbSet = _db.Set<VoltageTransformer>();
        }

        public async Task AddAsync(VoltageTransformer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(VoltageTransformer entity)
        {
            _db.VoltageTransformers.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<VoltageTransformer> GetAsync(int id) => await _db.VoltageTransformers
            .Include(vt => vt.MeterPoint)
            .FirstOrDefaultAsync(vt => vt.Id == id);

        public IQueryable<VoltageTransformer> GetList() => 
            _dbSet
            .Include(vt => vt.MeterPoint);
    }
}
