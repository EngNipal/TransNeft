using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class OrganizationService : IOrganizationService
    {
        public Task<OrganizationViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<OrganizationViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrganizationDTO organizationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
