﻿using AutoMapper;
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
    public class WebService : IWebService
    {
        private IMapper _mapper;
        
        private readonly IRepository<EObject> _eObjectRepo;
        private readonly IRepository<ElectricityMeter> _electricityMeterRepo;
        private readonly IRepository<CurrentTransformer> _currentTransformerRepo;
        private readonly IRepository<VoltageTransformer> _voltageTransformerRepo;
        private readonly IRepository<MeterPoint> _meterPointRepo;
        private readonly IRepository<CalcMeter> _calcMeterRepo;



        public WebService(
            IRepository<EObject> eoRepo,
            IRepository<ElectricityMeter> emRepo,
            IRepository<CurrentTransformer> ctRepo,
            IRepository<VoltageTransformer> vtRepo,
            IRepository<MeterPoint> mpRepo,
            IRepository<CalcMeter> cmRepo,
            IMapper mapper)
        {
            _eObjectRepo = eoRepo;
            _electricityMeterRepo = emRepo;
            _currentTransformerRepo = ctRepo;
            _voltageTransformerRepo = vtRepo;
            _meterPointRepo = mpRepo;
            _calcMeterRepo = cmRepo;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ElectricityMeterViewModel>>> GetFreeElectricityMeters()
        {
            var elMeters = await _electricityMeterRepo.GetList().Where(em => em.MeterPoint == null).ToListAsync();

            return _mapper.Map<IEnumerable<ElectricityMeter>, List<ElectricityMeterViewModel>>(elMeters);
        }

        public async Task<ActionResult<IEnumerable<CurrentTransformerViewModel>>> GetFreeCurrentTransformers()
        {
            var cTranses = await _currentTransformerRepo.GetList().Where(ct => ct.MeterPoint == null).ToListAsync();

            return _mapper.Map<IEnumerable<CurrentTransformer>, List<CurrentTransformerViewModel>>(cTranses);
        }

        public async Task<ActionResult<IEnumerable<VoltageTransformerViewModel>>> GetFreeVoltageTransformers()
        {
            var vTranses = await _voltageTransformerRepo.GetList().Where(vt => vt.MeterPoint == null).ToListAsync();

            return _mapper.Map<IEnumerable<VoltageTransformer>, List<VoltageTransformerViewModel>>(vTranses);
        }

        // Создание новой точки измерения.
        public async Task CreateMeterPoint(MeterPointDTO meterPointDto)
        {
            var meterPoint = _mapper.Map<MeterPointDTO, MeterPoint>(meterPointDto);
            await _meterPointRepo.AddAsync(meterPoint);
        }

        // Выбор расчётных приборов учёта по году.
        public async Task<ActionResult<IEnumerable<CalcMeterViewModel>>> GetCalcMetersByYear(int year)
        {
            var calcMeters = await _calcMeterRepo.GetList()
                                    .Where(cm => cm.StartDate.Year == year)
                                    .ToListAsync();

            return _mapper.Map<IEnumerable<CalcMeter>, List<CalcMeterViewModel>>(calcMeters);
        }

        // Проверка существования EObject-a с указанным id.
        public async Task<bool> EObjectExists(int eObjectId) => await _eObjectRepo.GetAsync(eObjectId) != null;

        // Выбор счётчиков без поверки по объекту потребления.
        public async Task<ActionResult<IEnumerable<ElectricityMeterViewModel>>> GetEMExpiredByEObject(int eObjectId)
        {
            var emsExpired = await _electricityMeterRepo.GetList()
                                    .Where(em => em.MeterPoint.EObjectId == eObjectId)
                                    .Where(em => em.CheckDate < DateTime.Now)
                                    .ToListAsync();

            return _mapper.Map<IEnumerable<ElectricityMeter>, List<ElectricityMeterViewModel>>(emsExpired);
        }

        // Выбор трансформаторов тока по объекту потребления.
        public async Task<ActionResult<IEnumerable<CurrentTransformerViewModel>>> GetCTExpiredByEObject(int eObjectId)
        {
            var currentTransformers = await _currentTransformerRepo.GetList()
                                            .Where(ct => ct.MeterPoint.EObjectId == eObjectId)
                                            .Where(ct => ct.CheckDate < DateTime.Now)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<CurrentTransformer>, List<CurrentTransformerViewModel>>(currentTransformers);
        }

        // Выбор трансформаторов напряжения по объекту потребления.
        public async Task<ActionResult<IEnumerable<VoltageTransformerViewModel>>> GetVTExpiredByEObject(int eObjectId)
        {
            var voltageTransformers = await _voltageTransformerRepo.GetList()
                                            .Where(vt => vt.MeterPoint.EObject.Id == eObjectId)
                                            .Where(vt => vt.CheckDate < DateTime.Now)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<VoltageTransformer>, List<VoltageTransformerViewModel>>(voltageTransformers);
        }
    }
}