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
    public class WebService : IWebService
    {
        private IMapper _mapper;
        
        private readonly IRepository<EObject> _eObjectRepo;
        private readonly IEMRepository _electricityMeterRepo;
        private readonly IRepository<CurrentTransformer> _currentTransformerRepo;
        private readonly IRepository<VoltageTransformer> _voltageTransformerRepo;
        private readonly IRepository<MeterPointDTO> _meterPointRepo;
        private readonly IRepository<CalcMeter> _calcMeterRepo;



        public WebService(
            IRepository<EObject> eoRepo,
            IEMRepository emRepo,
            IRepository<CurrentTransformer> ctRepo,
            IRepository<VoltageTransformer> vtRepo,
            IRepository<MeterPointDTO> mpRepo,
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

        public async Task<IEnumerable<ElectricityMeterDTO>> GetFreeElectricityMeters() =>
            await _electricityMeterRepo.GetFreeAsync();

        public async Task<IEnumerable<CurrentTransformerDTO>> GetFreeCurrentTransformers()
        {
            var cTranses = await _currentTransformerRepo.GetList().Where(ct => ct.MeterPoint == null).ToListAsync();

            return _mapper.Map<IEnumerable<CurrentTransformer>, List<CurrentTransformerViewModel>>(cTranses);
        }

        public async Task<IEnumerable<VoltageTransformerDTO>> GetFreeVoltageTransformers()
        {
            var vTranses = await _voltageTransformerRepo.GetList().Where(vt => vt.MeterPoint == null).ToListAsync();

            return _mapper.Map<IEnumerable<VoltageTransformer>, List<VoltageTransformerViewModel>>(vTranses);
        }

        // Создание новой точки измерения.
        public async Task CreateMeterPoint(MeterPointDTO meterPointDto)
        {
            await _meterPointRepo.AddAsync(meterPointDto);
        }

        // Выбор расчётных приборов учёта по году.
        public async Task<IEnumerable<CalcMeterDTO>> GetCalcMetersByYear(int year)
        {
            var calcMeters = await _calcMeterRepo.GetList()
                                    .Where(cm => cm.StartDate.Year == year)
                                    .ToListAsync();

            return _mapper.Map<IEnumerable<CalcMeter>, List<CalcMeterViewModel>>(calcMeters);
        }

        // Проверка существования EObject-a с указанным id.
        public async Task<bool> EObjectExists(int eObjectId) => await _eObjectRepo.GetAsync(eObjectId) != null;

        // Выбор счётчиков без поверки по объекту потребления.
        public async Task<IEnumerable<ElectricityMeterDTO>> GetEMExpiredByEObject(int eObjectId)
        {
            var emsExpired = await _electricityMeterRepo.GetList()
                                    .Where(em => em.MeterPoint.EObjectId == eObjectId)
                                    .Where(em => em.CheckDate < DateTime.Now)
                                    .ToListAsync();

            return _mapper.Map<IEnumerable<ElectricityMeter>, List<ElectricityMeterViewModel>>(emsExpired);
        }

        // Выбор трансформаторов тока по объекту потребления.
        public async Task<IEnumerable<CurrentTransformerDTO>> GetCTExpiredByEObject(int eObjectId)
        {
            var currentTransformers = await _currentTransformerRepo.GetList()
                                            .Where(ct => ct.MeterPoint.EObjectId == eObjectId)
                                            .Where(ct => ct.CheckDate < DateTime.Now)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<CurrentTransformer>, List<CurrentTransformerViewModel>>(currentTransformers);
        }

        // Выбор трансформаторов напряжения по объекту потребления.
        public async Task<IEnumerable<VoltageTransformerDTO>> GetVTExpiredByEObject(int eObjectId)
        {
            var voltageTransformers = await _voltageTransformerRepo.GetList()
                                            .Where(vt => vt.MeterPoint.EObject.Id == eObjectId)
                                            .Where(vt => vt.CheckDate < DateTime.Now)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<VoltageTransformer>, List<VoltageTransformerViewModel>>(voltageTransformers);
        }
    }
}