using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface ICurrentTransformerRepository : IRepository<CurrentTransformer>
    {
        public Task<IEnumerable<CurrentTransformerDto>> GetFreeAsync();
        public Task<IEnumerable<CurrentTransformerDto>> GetExpiredByEObjectIdAsync(int eObjectDtoId);
    }
}