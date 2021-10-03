using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransNeftTest.Exceptions;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLMeterPointRepository : IRepository<MeterPoint>
    {
        private readonly TNEContext _dbContext;

        public SQLMeterPointRepository(TNEContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(MeterPoint entity)
        {
            await _dbContext.MeterPoints.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MeterPoint> GetAsync(int id)
        {
            var entity = await _dbContext.MeterPoints
                .FirstOrDefaultAsync(mp => mp.Id == id);

            return entity ?? throw new EntityNotFoundException($"Точка измерения электроэнергии с Id = {id} не найдена.");
        }
    }
}