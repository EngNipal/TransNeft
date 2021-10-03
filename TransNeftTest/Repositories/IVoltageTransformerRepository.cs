using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface IVoltageTransformerRepository : IRepository<VoltageTransformer>
    {
        public Task<IEnumerable<VoltageTransformerDto>> GetFreeAsync();
        public Task<IEnumerable<VoltageTransformerDto>> GetExpiredByEObjectIdAsync(int eObjectId);
    }
}