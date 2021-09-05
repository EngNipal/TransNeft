using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class DeviceServise : IDeviceServise
    {
        public Task<DeviceViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<DeviceViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DeviceDTO deviceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
