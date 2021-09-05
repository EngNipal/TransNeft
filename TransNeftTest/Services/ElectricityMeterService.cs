using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class ElectricityMeterService : IElectricityMeterService
    {
        public Task<ElectricityMeterViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ElectricityMeterViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ElectricityMeterDTO electricityMeterDTO)
        {
            throw new NotImplementedException();
        }
    }
}
