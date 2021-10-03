using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface IElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        Task<IEnumerable<ElectricityMeterDto>> GetFreeAsync();
        Task<IEnumerable<ElectricityMeterDto>> GetExpiredByEObjectIdAsync(int eObjectDtoId);
    }
}