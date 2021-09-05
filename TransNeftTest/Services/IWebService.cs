using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Services
{
    public interface IWebService
    {
        Task AddMeterPoint();
        Task<List<CalcMeter>> GetCalcMetersByYear(int year);
        Task<List<ElectricityMeter>> GetElectricityMeterExpired();
        Task<List<VoltageTransformer>> GetVoltageTransformersByConsumer(string consumerName);
        Task<List<CurrentTransformer>> GetCurrentTransformersByConsumer(string consumerName);
    }
}