using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class SubsidiaryService : ISubsidiaryService
    {
        public Task<SubsidiaryViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SubsidiaryViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SubsidiaryDTO subsidiaryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
