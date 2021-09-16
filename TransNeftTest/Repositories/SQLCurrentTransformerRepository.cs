using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCurrentTransformerRepository : IRepository<CurrentTransformer>
    {
        private readonly TNEContext _db;
        private readonly DbSet<CurrentTransformer> _dbSet;

        public SQLCurrentTransformerRepository(TNEContext context)
        {
            _db = context;
            _dbSet = _db.Set<CurrentTransformer>();
        }

        public async Task AddAsync(CurrentTransformer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<CurrentTransformer> GetAsync(int id) =>
            await _db.CurrentTransformers
            .Include(ct => ct.MeterPoint)
            .FirstOrDefaultAsync(ct => ct.Id == id);

        public IQueryable<CurrentTransformer> GetList() =>
            _dbSet
            .Include(ct => ct.MeterPoint);

        public async Task UpdateAsync(CurrentTransformer entity)
        {
            _db.Update(entity);

            await _db.SaveChangesAsync();
        }
    }
}