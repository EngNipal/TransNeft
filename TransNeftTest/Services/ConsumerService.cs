using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class ConsumerService : IConsumerService
    {
        public Task<ConsumerViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ConsumerViewModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ConsumerDTO consumerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
