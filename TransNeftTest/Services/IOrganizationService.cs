using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IOrganizationService : IService<OrganizationViewModel>
    {
        public Task UpdateAsync(OrganizationDTO organizationDTO);
    }
}
