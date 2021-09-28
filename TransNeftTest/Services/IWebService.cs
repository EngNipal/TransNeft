using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IWebService
    {
        public Task<IEnumerable<ElectricityMeterDTO>> GetFreeElectricityMeters();
        public Task<IEnumerable<CurrentTransformerDTO>> GetFreeCurrentTransformers();
        public Task<IEnumerable<VoltageTransformerDTO>> GetFreeVoltageTransformers();

        public Task CreateMeterPoint(MeterPointDTO meterPointDto);
        public Task<IEnumerable<CalcMeterDTO>> GetCalcMetersByYear(int year);

        public Task<bool> EObjectExists(int eObjectId);
        public Task<IEnumerable<ElectricityMeterDTO>> GetEMExpiredByEObject(int eObjectId);
        public Task<IEnumerable<CurrentTransformerDTO>> GetCTExpiredByEObject(int eObjectId);
        public Task<IEnumerable<VoltageTransformerDTO>> GetVTExpiredByEObject(int eObjectId);
    }
}