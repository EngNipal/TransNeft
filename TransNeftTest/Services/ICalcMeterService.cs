using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface ICalcMeterService : IService<CalcMeterViewModel>
    {
        public Task UpdateAsync(CalcMeterDTO calcMeterDTO);
    }
}