using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IApiService
    {
        public Task<ActionResult<List<ElectricityMeterViewModel>>> GetFreeElectricityMeters();
        public Task<ActionResult<List<CurrentTransformerViewModel>>> GetFreeCurrentTransformers();
        public Task<ActionResult<List<VoltageTransformerViewModel>>> GetFreeVoltageTransformers();

        public Task CreateMeterPoint(MeterPointDTO meterPointDto);
        public Task<List<CalcMeterViewModel>> GetCalcMetersByYear(int year);
        public Task<List<ElectricityMeterViewModel>> GetEMExpiredByEObject(EObjectDTO eObjectDto);
        public Task<List<CurrentTransformerViewModel>> GetCTExpiredByEObject(EObjectDTO eObjectDto);
        public Task<List<VoltageTransformerViewModel>> GetVTExpiredByEObject(EObjectDTO eObjectDto);
    }
}