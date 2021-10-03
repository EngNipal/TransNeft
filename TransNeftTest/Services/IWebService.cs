using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Services
{
    public interface IWebService
    {
        public Task<IEnumerable<ElectricityMeterDto>> GetFreeElectricityMeters();
        public Task<IEnumerable<CurrentTransformerDto>> GetFreeCurrentTransformers();
        public Task<IEnumerable<VoltageTransformerDto>> GetFreeVoltageTransformers();

        public Task CreateMeterPoint(MeterPointDto meterPointDto);
        public Task<IEnumerable<CalcMeterDto>> GetCalcMetersByYear(int year);

        public Task<bool> EObjectExists(int eObjectId);
        public Task<IEnumerable<ElectricityMeterDto>> GetElectricityMeterExpiredByEObject(int eObjectId);
        public Task<IEnumerable<CurrentTransformerDto>> GetCurrentTransformerExpiredByEObject(int eObjectId);
        public Task<IEnumerable<VoltageTransformerDto>> GetVoltageTransformerExpiredByEObject(int eObjectId);
    }
}