using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        
        private IRepository<ElectricityMeter> _electricityMeterRepo = default;
        private IRepository<CurrentTransformer> _currentTransformerRepo = default;
        private IRepository<VoltageTransformer> _voltageTransformerRepo = default;
        private IRepository<MeterPoint> _meterPointRepo = default;
        private IRepository<CalcMeter> _calcMeterRepo = default;

        public async Task<ActionResult<List<ElectricityMeterViewModel>>> GetFreeElectricityMeters()
        {
            var emList = await _electricityMeterRepo.GetListAsync();
            var elMeters = emList.Where(em => em.MeterPoint == null).ToList();

            return _mapper.Map<List<ElectricityMeter>, List<ElectricityMeterViewModel>>(elMeters);
        }

        public async Task<ActionResult<List<CurrentTransformerViewModel>>> GetFreeCurrentTransformers()
        {
            var ctList = await _currentTransformerRepo.GetListAsync();
            var cTranses = ctList.Where(ct => ct.MeterPoint == null).ToList();

            return _mapper.Map<List<CurrentTransformer>, List<CurrentTransformerViewModel>>(cTranses);
        }

        public async Task<ActionResult<List<VoltageTransformerViewModel>>> GetFreeVoltageTransformers()
        {
            var vtList = await _voltageTransformerRepo.GetListAsync();
            var vTranses = vtList.Where(vt => vt.MeterPoint == null).ToList();

            return _mapper.Map<List<VoltageTransformer>, List<VoltageTransformerViewModel>>(vTranses);
        }

        // 1111111111111111
        public async Task CreateMeterPoint(MeterPointDTO meterPointDto)
        {
            var meterPoint = _mapper.Map<MeterPointDTO, MeterPoint>(meterPointDto);
            await _meterPointRepo.AddAsync(meterPoint);
        }

        // 222222222222222
        public async Task<List<CalcMeterViewModel>> GetCalcMetersByYear(int year)
        {
            var cmList = await _calcMeterRepo.GetListAsync();
            var calcMeters = cmList.Where(cm => cm.StartDate.Year == year).ToList();

            return _mapper.Map<List<CalcMeter>, List<CalcMeterViewModel>>(calcMeters);
        }

        // 33333333333333
        public async Task<List<ElectricityMeterViewModel>> GetEMExpiredByConsumer(ConsumerDTO consumerDto)
        {
            var emList = await _electricityMeterRepo.GetListAsync();
            var emsExpired = emList.Where(em => em.MeterPoint.EObject.Id == consumerDto.Id)
                                   .Where(em => em.CheckDate < DateTime.Now)
                                   .ToList();

            return _mapper.Map<List<ElectricityMeter>, List<ElectricityMeterViewModel>>(emsExpired);
        }

        // 44444444444444
        public async Task<List<CurrentTransformerViewModel>> GetCTExpiredByConsumer(ConsumerDTO consumerDto)
        {
            var ctList = await _currentTransformerRepo.GetListAsync();
            var currentTransformers = ctList.Where(ct => ct.MeterPoint.EObject.Id == consumerDto.Id)
                                            .Where(ct => ct.CheckDate < DateTime.Now)
                                            .ToList();

            return _mapper.Map<List<CurrentTransformer>, List<CurrentTransformerViewModel>>(currentTransformers);
        }

        // 55555555555555555
        public async Task<List<VoltageTransformerViewModel>> GetVTExpiredByConsumer(ConsumerDTO consumerDto)
        {
            var vtList = await _voltageTransformerRepo.GetListAsync();
            var voltageTransformers = vtList.Where(vt => vt.MeterPoint.EObject.Id == consumerDto.Id)
                                            .Where(vt => vt.CheckDate < DateTime.Now)
                                            .ToList();

            return _mapper.Map<List<VoltageTransformer>, List<VoltageTransformerViewModel>>(voltageTransformers);
        }
    }
}
