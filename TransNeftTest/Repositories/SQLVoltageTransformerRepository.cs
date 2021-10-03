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
    public class SQLVoltageTransformerRepository : IVoltageTransformerRepository
    {
        private readonly TNEContext _dbContext;

        public SQLVoltageTransformerRepository(TNEContext context) => _dbContext = context;

        public async Task AddAsync(VoltageTransformer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id) =>
            await _dbContext.VoltageTransformers.AnyAsync(x => x.Id == id);

        public async Task<VoltageTransformer> GetAsync(int id)
        {
            var entity = await _dbContext.VoltageTransformers
                .AsNoTracking()
                .FirstOrDefaultAsync(vt => vt.Id == id);

            return entity ?? throw new EntityNotFoundException($"Трансформатор напряжения с Id = {id} не найден");
        }

        public async Task<IEnumerable<VoltageTransformerDto>> GetFreeAsync() =>
            await _dbContext.VoltageTransformers
            .AsNoTracking()
            .Where(vt => vt.MeterPoint == null)
            .Select(vt => new VoltageTransformerDto()
            {
                Id = vt.Id,
                Number = vt.Number
            })
            .ToListAsync();

        public async Task<IEnumerable<VoltageTransformerDto>> GetExpiredByEObjectIdAsync(int eObjectId) =>
            await _dbContext.VoltageTransformers
            .AsNoTracking()
            .Where(vt => vt.MeterPoint.EObjectId == eObjectId)
            .Where(vt => vt.CheckDate < DateTime.Now)
            .Select(vt => new VoltageTransformerDto(
                vt.Id,
                vt.Number,
                vt.CheckDate))
            .ToListAsync();
    }
}