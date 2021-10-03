using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLEObjectRepository : IRepository<EObject>
    {
        private readonly TNEContext _dbContext;

        public SQLEObjectRepository(TNEContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(EObject entity)
        {
            await _dbContext.EObjects.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EObject> GetAsync(int id) =>
            await _dbContext.EObjects
            .FirstOrDefaultAsync(eo => eo.Id == id);
    }
}
