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
        private TNEContext _db;
        private const string _messageCurrentTransformerAbsent = "Запрошенного трансформатора тока не найдено!";

        public SQLCurrentTransformerRepository(TNEContext context)
        {
            _db = context;
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

        public async Task<IEnumerable<CurrentTransformer>> GetListAsync() =>
            await _db.CurrentTransformers
            .Include(ct => ct.MeterPoint)
            .ToListAsync();

        public async Task UpdateAsync(CurrentTransformer item)
        {
            var currentTransformerDb = await _db.CurrentTransformers.FindAsync(item.Id);
            if (currentTransformerDb == null)
            {
                throw new KeyNotFoundException(_messageCurrentTransformerAbsent);
            }

            currentTransformerDb.Number = item.Number;
            currentTransformerDb.CheckDate = item.CheckDate;
            currentTransformerDb.MeterPointId = item.MeterPointId;
            currentTransformerDb.MeterPoint = item.MeterPoint;
            currentTransformerDb.KTT = item.KTT;

            await _db.SaveChangesAsync();
        }
    }
}