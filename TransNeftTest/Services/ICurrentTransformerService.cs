using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface ICurrentTransformerService : IService<CurrentTransformerViewModel>
    {
        public Task UpdateAsync(CurrentTransformerDTO currentTransformerDTO);
    }
}