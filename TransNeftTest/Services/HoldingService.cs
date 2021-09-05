using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class HoldingService : IHoldingService
    {
        public Task<HoldingViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<HoldingViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HoldingDTO holdingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
