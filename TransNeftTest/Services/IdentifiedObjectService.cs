using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class IdentifiedObjectService : IIdentifiedObjectService
    {
        public Task<IdentifiedObjectViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IdentifiedObjectViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentifiedObjectDTO identifiedObjectDto)
        {
            throw new NotImplementedException();
        }
    }
}
