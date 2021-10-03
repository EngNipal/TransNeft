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
            // TODO: Write creation code.

            await _dbContext.ElectricityMeters.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ElectricityMeter> GetAsync(int id)
        {
            var entity = await _dbContext.ElectricityMeters
            .Where(em => em.Id == id)
            .FirstOrDefaultAsync();

            return entity ?? throw new EntityNotFoundException($"Счётчик электроэнергии с Id = {id} не найден.");
        }

        public async Task<IEnumerable<ElectricityMeterDto>> GetFreeAsync() =>
            await _dbContext.ElectricityMeters.AsNoTracking()
            .Where(em => em.MeterPoint == null)
            .Select(em => new ElectricityMeterDto
            {
                Id = em.Id,
                Number = em.Number
            })
            .ToListAsync();

        public async Task<IEnumerable<ElectricityMeterDto>> GetExpiredByEObjectIdAsync(int eObjectDtoId) =>
            await _dbContext.ElectricityMeters.AsNoTracking()
            .Where(em => em.MeterPoint.EObjectId == eObjectDtoId &&
                        em.CheckDate < DateTime.Now)
            .Select(em => new ElectricityMeterDto
            {
                Id = em.Id,
                Number = em.Number
            })
            .ToListAsync();
    }
}