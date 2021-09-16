using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLEObjectRepository : IRepository<EObject>
    {
        private readonly TNEContext _db;
        private readonly DbSet<EObject> _dbSet;

        public SQLEObjectRepository(TNEContext context)
        {
            _db = context;
            _dbSet = _db.Set<EObject>();
        }

        public async Task AddAsync(EObject entity)
        {
            await _db.EObjects.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(EObject entity)
        {
            _db.EObjects.Update(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<EObject> GetAsync(int id) =>
            await _db.EObjects
            .FirstOrDefaultAsync(eo => eo.Id == id);

        public IQueryable<EObject> GetList() => _dbSet;
    }
}
