using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.Repositories;

namespace TransNeftTest.Services
{
    public class ApiService : IApiService
    {
        private IMapper _mapper;
        
        public Task AddMeterPoint(MeterPointDTO meterPointDto)
        {
            
        }

        public Task<List<CalcMeter>> GetCalcMetersByYear(int year)
        {
            
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
