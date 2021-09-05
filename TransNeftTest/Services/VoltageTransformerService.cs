using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class VoltageTransformerService : IVoltageTransformerService
    {
        public Task<VoltageTransformerViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<VoltageTransformerViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(VoltageTransformerDTO voltageTransformerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
