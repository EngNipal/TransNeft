using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class DeliveryPointService : IDeliveryPointService
    {
        public Task<DeliveryPointViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<DeliveryPointViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DeliveryPointDTO deliveryPointDTO)
        {
            throw new NotImplementedException();
        }
    }
}
