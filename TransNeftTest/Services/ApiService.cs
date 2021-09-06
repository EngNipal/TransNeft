using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.Repositories;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class ApiService : IApiService
    {
        private IMapper _mapper = default(Mapper);
        private IRepository<CalcMeter> _calcMeterRepo = default(IRepository<CalcMeter>);
        private IRepository<CurrentTransformer> _currentTransformerRepo = default(IRepository<CurrentTransformer>);
        private IRepository<ElectricityMeter> _electricityMeterRepo = default(IRepository<ElectricityMeter>);
        private IRepository<VoltageTransformer> _voltageTransformerRepo = default(IRepository<VoltageTransformer>);

        public Task CreateMeterPoint(MeterPointDTO meterPointDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CalcMeterViewModel>> GetCalcMetersByYear(int year)
        {
            var cmList = await _calcMeterRepo.GetListAsync();
            var calcMeters = cmList.Where(cm => cm.StartDate.Year == year).ToList();

            return _mapper.Map<List<CalcMeter>, List<CalcMeterViewModel>>(calcMeters);
        }

        public async Task<List<CurrentTransformerViewModel>> GetCurrentTransformersByConsumer(string consumerName)
        {
            var ctList = await _currentTransformerRepo.GetListAsync();
            var currentTransformers = ctList.Where(ct => ct.MeterPoint.Consumer.Name == consumerName).ToList();

            return _mapper.Map<List<CurrentTransformer>, List<CurrentTransformerViewModel>>(currentTransformers);
        }

        public async Task<List<ElectricityMeterViewModel>> GetElectricityMeterExpired()
        {
            var emList = await _electricityMeterRepo.GetListAsync();
            var emsExpired = emList.Where(em => em.CheckDate < DateTime.Now).ToList();

            return _mapper.Map<List<ElectricityMeter>, List<ElectricityMeterViewModel>>(emsExpired);
        }

        public async Task<List<VoltageTransformerViewModel>> GetVoltageTransformersByConsumer(string consumerName)
        {
            var vtList = await _voltageTransformerRepo.GetListAsync();
            var voltageTransformers = vtList.Where(vt => vt.MeterPoint.Consumer.Name == consumerName).ToList();

            return _mapper.Map<List<VoltageTransformer>, List<VoltageTransformerViewModel>>(voltageTransformers);
        }
    }
}
