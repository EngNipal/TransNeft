﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.Repositories;

namespace TransNeftTest.Services
{
    public class WebService : IWebService
    {
        private readonly IRepository<EObject> _eObjectRepo;
        private readonly IRepository<MeterPoint> _meterPointRepo;
        private readonly IElectricityMeterRepository _electricityMeterRepo;
        private readonly ICurrentTransformerRepository _currentTransformerRepo;
        private readonly IVoltageTransformerRepository _voltageTransformerRepo;
        private readonly ICalcMeterRepository _calcMeterRepo;



        public WebService(
            IRepository<EObject> eoRepo,
            IRepository<MeterPoint> mpRepo,
            IElectricityMeterRepository emRepo,
            ICurrentTransformerRepository ctRepo,
            IVoltageTransformerRepository vtRepo,
            ICalcMeterRepository cmRepo
            )
        {
            _eObjectRepo = eoRepo;
            _meterPointRepo = mpRepo;
            _electricityMeterRepo = emRepo;
            _currentTransformerRepo = ctRepo;
            _voltageTransformerRepo = vtRepo;
            _calcMeterRepo = cmRepo;
        }

        public async Task<IEnumerable<ElectricityMeterDto>> GetFreeElectricityMeters() =>
            await _electricityMeterRepo.GetFreeAsync();

        public async Task<IEnumerable<CurrentTransformerDto>> GetFreeCurrentTransformers() =>
            await _currentTransformerRepo.GetFreeAsync();

        public async Task<IEnumerable<VoltageTransformerDto>> GetFreeVoltageTransformers() =>
            await _voltageTransformerRepo.GetFreeAsync();

        // Создание новой точки измерения.
        public async Task CreateMeterPoint(MeterPointDto meterPointDto)
        {
            var meterPointEntity = new MeterPoint
            {
                Id = meterPointDto.Id,
                Name = meterPointDto.Name,
                ElectricityMeterId = meterPointDto.ElictricityMeterId,
                CurrentTransformerId = meterPointDto.CurrentTransformerId,
                VoltageTransformerId = meterPointDto.VoltageTransformerId,
                EObjectId = meterPointDto.EObjectId,
                CalcMeterId = meterPointDto.CalcMeterId
            };

            await _meterPointRepo.AddAsync(meterPointEntity);
        }

        // Получение расчётных приборов учёта по году.
        public async Task<IEnumerable<CalcMeterDto>> GetCalcMetersByYear(int year) =>
            await _calcMeterRepo.GetAllByYearAsync(year);

        // Проверка существования EObject с указанным Id.
        public async Task<bool> EObjectExists(int eObjectId) => await _eObjectRepo.GetAsync(eObjectId) != null;

        // Выбор счётчиков с истёкшим сроком поверки по указанному объекту потребления.
        public async Task<IEnumerable<ElectricityMeterDto>> GetElectricityMeterExpiredByEObject(int eObjectId) =>
            await _electricityMeterRepo.GetExpiredByEObjectIdAsync(eObjectId);

        // Выбор трансформаторов тока с истёкшим сроком поверки по указанному объекту потребления.
        public async Task<IEnumerable<CurrentTransformerDto>> GetCurrentTransformerExpiredByEObject(int eObjectId) => 
            await _currentTransformerRepo.GetExpiredByEObjectIdAsync(eObjectId);

        // Выбор трансформаторов напряжения с истёкшим сроком поверки по указанному объекту потребления.
        public async Task<IEnumerable<VoltageTransformerDto>> GetVoltageTransformerExpiredByEObject(int eObjectId) =>
            await _voltageTransformerRepo.GetExpiredByEObjectIdAsync(eObjectId);
    }
}