using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.Models;
using System.Linq;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Repositories
{
    public class SQLCalcMeterRepository : ICalcMeterRepository
    {
        private readonly TNEContext _dbContext;

        public SQLCalcMeterRepository(TNEContext context) => _dbContext = context;

        public async Task AddAsync(CalcMeter entity)
        {
            await _dbContext.CalcMeters.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id) =>
            await _dbContext.CalcMeters.AnyAsync(x => x.Id == id);

        public async Task<CalcMeter> GetAsync(int id) =>
            await _dbContext.CalcMeters
            .AsNoTracking()
            .FirstOrDefaultAsync(cm => cm.Id == id);

        public async Task<IEnumerable<CalcMeterDto>> GetAllByYearAsync(int year) => 
            await _dbContext.CalcMeters
            .AsNoTracking()
            .Where(cm => cm.StartDate.Year == year)
            .Select(cm => new CalcMeterDto(
                cm.Id,
                cm.Number,
                cm.StartDate,
                cm.EndDate))
            .ToListAsync();
    }
}