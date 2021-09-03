using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Services
{
    public interface IMeterPointService : IService<MeterPoint>
    {
        public Task UpdateAsync(MeterPointDTO meterPointDTO);
    }
}
