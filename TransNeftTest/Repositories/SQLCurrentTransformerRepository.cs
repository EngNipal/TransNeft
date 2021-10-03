using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Exceptions;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCurrentTransformerRepository : ICurrentTransformerRepository
    {
        private readonly TNEContext _dbContext;

        public SQLCurrentTransformerRepository(TNEContext context) => _dbContext = context;

        public async Task AddAsync(CurrentTransformer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id) =>
            await _dbContext.CurrentTransformers.AnyAsync(x => x.Id == id);

        public async Task<CurrentTransformer> GetAsync(int id)
        {
            var entity = await _dbContext.CurrentTransformers
                .AsNoTracking()
                .FirstOrDefaultAsync(em => em.Id == id);

            return entity ?? throw new EntityNotFoundException($"Трансформатор тока с Id = {id} не найден.");
        }

        public async Task<IEnumerable<CurrentTransformerDto>> GetFreeAsync() =>
            await _dbContext.CurrentTransformers
            .AsNoTracking()
            .Where(ct => ct.MeterPoint == null)
            .Select(ct => new CurrentTransformerDto()
            {
                Id = ct.Id,
                Number = ct.Number
            })
            .ToListAsync();

        public async Task<IEnumerable<CurrentTransformerDto>> GetExpiredByEObjectIdAsync(int eObjectId) =>
            await _dbContext.CurrentTransformers
            .AsNoTracking()
            .Where(ct => ct.MeterPoint.EObjectId == eObjectId)
            .Where(ct => ct.CheckDate < DateTime.Now)
            .Select(ct => new CurrentTransformerDto(
                ct.Id,
                ct.Number,
                ct.CheckDate))
            .ToListAsync();
    }
}