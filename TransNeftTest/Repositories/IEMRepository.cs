using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Repositories
{
    public interface IEMRepository : IRepository<ElectricityMeterDTO>
    {
        Task<IEnumerable<ElectricityMeterDTO>> GetFreeAsync();
        Task<IEnumerable<ElectricityMeterDTO>> GetExpiredByEObjectAsync(EObjectDTO eObjectDTO);
    }
}