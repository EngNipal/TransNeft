using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IApiService
    {
        public Task CreateMeterPoint(MeterPointDTO meterPointDto);
        public Task<List<CalcMeterViewModel>> GetCalcMetersByYear(int year);
        public Task<List<ElectricityMeterViewModel>> GetElectricityMeterExpired();
        public Task<List<VoltageTransformerViewModel>> GetVoltageTransformersByConsumer(string consumerName);
        public Task<List<CurrentTransformerViewModel>> GetCurrentTransformersByConsumer(string consumerName);
    }
}