using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class CalcMeterService : ICalcMeterService
    {
        public Task<CalcMeterViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CalcMeterViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CalcMeterDTO calcMeterDTO)
        {
            throw new NotImplementedException();
        }
    }
}
