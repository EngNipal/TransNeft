using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class CurrentTransformerService : ICurrentTransformerService
    {
        public Task<CurrentTransformerViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CurrentTransformerViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CurrentTransformerDTO currentTransformerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
