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
        Task<List<CalcMeter>> GetCalcMetersByYear();
        Task<List<ElictricityMeter>> GetElicticityMeterExpired();
        Task<List<VoltageTransformer>> GetVoltageTransformersByConsumer();
        Task<List<CurrentTransformer>> GetCurrentTransformersByConsumer();
    }
}