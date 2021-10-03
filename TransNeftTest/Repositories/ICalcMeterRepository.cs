using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface ICalcMeterRepository : IRepository<CalcMeter>
    {
        public Task<IEnumerable<CalcMeterDto>> GetAllByYearAsync(int year);
    }
}