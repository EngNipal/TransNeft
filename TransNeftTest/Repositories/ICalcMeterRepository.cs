using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface ICalcMeterRepository : IRepository<CalcMeter>
    {
        /// <summary> Метод получения расчётных приборов учёта по году. </summary>
        /// <param name="year"> Год. </param>
        /// <returns> Список расчётных приборов учёта. </returns>
        public Task<IEnumerable<CalcMeterDto>> GetAllByYearAsync(int year);
    }
}