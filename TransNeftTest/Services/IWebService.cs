using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IWebService
    {
        public Task<ActionResult<IEnumerable<ElectricityMeterViewModel>>> GetFreeElectricityMeters();
        public Task<ActionResult<IEnumerable<CurrentTransformerViewModel>>> GetFreeCurrentTransformers();
        public Task<ActionResult<IEnumerable<VoltageTransformerViewModel>>> GetFreeVoltageTransformers();

        public Task CreateMeterPoint(MeterPointDTO meterPointDto);
        public Task<ActionResult<IEnumerable<CalcMeterViewModel>>> GetCalcMetersByYear(int year);
        public Task<ActionResult<IEnumerable<ElectricityMeterViewModel>>> GetEMExpiredByEObject(EObjectDTO eObjectDto);
        public Task<ActionResult<IEnumerable<CurrentTransformerViewModel>>> GetCTExpiredByEObject(EObjectDTO eObjectDto);
        public Task<ActionResult<IEnumerable<VoltageTransformerViewModel>>> GetVTExpiredByEObject(EObjectDTO eObjectDto);
    }
}