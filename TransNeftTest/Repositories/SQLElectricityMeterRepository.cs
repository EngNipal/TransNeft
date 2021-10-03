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
    public class SQLElectricityMeterRepository : IElectricityMeterRepository
    {
        private readonly TNEContext _dbContext;

        public SQLElectricityMeterRepository(TNEContext context) => _dbContext = context;

        public async Task AddAsync(ElectricityMeter entity)
        {
            await _dbContext.ElectricityMeters.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id) =>
            await _dbContext.ElectricityMeters.AnyAsync(x => x.Id == id);

        public async Task<ElectricityMeter> GetAsync(int id)
        {
            var entity = await _dbContext.ElectricityMeters
                .AsNoTracking()
                .Where(em => em.Id == id)
                .FirstOrDefaultAsync();

            return entity ?? throw new EntityNotFoundException($"Счётчик электроэнергии с Id = {id} не найден.");
        }

        public async Task<IEnumerable<ElectricityMeterDto>> GetFreeAsync() =>
            await _dbContext.ElectricityMeters
            .AsNoTracking()
            .Where(em => em.MeterPoint == null)
            .Select(em => new ElectricityMeterDto()
            {
                Id = em.Id,
                Number = em.Number
            })
            .ToListAsync();

        public async Task<IEnumerable<ElectricityMeterDto>> GetExpiredByEObjectIdAsync(int eObjectId) =>
            await _dbContext.ElectricityMeters
            .AsNoTracking()
            .Where(em => em.MeterPoint.EObjectId == eObjectId)
            .Where(em => em.CheckDate < DateTime.Now)
            .Select(em => new ElectricityMeterDto(
                em.Id,
                em.Number,
                em.CheckDate))
            .ToListAsync();
    }
}