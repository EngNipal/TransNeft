using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Services
{
    public class WebService : IWebService
    {
        public Task AddMeterPoint()
        {
            throw new NotImplementedException();
        }

        public Task<List<CalcMeter>> GetCalcMetersByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Task<List<CurrentTransformer>> GetCurrentTransformersByConsumer(string consumerName)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectricityMeter>> GetElectricityMeterExpired()
        {
            throw new NotImplementedException();
        }

        public Task<List<VoltageTransformer>> GetVoltageTransformersByConsumer(string consumerName)
        {
            throw new NotImplementedException();
        }
    }
}
